using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ZUI_Days
{
    public partial class ListEvents : Form
    {
        Thread thread;
        EventsList eventsList = new EventsList();
        int quantity = 0;   // Số lượng sự kiện trong danh sách sự kiện

        public ListEvents()
        {
            InitializeComponent();
        }

        private void ListEvents_Load(object sender, EventArgs e)
        {
            StreamReader sr = null;
            try
            {
                using (sr = new StreamReader("Events list.txt"))
                {
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Dựa vào dấu 2 chấm để chia dòng đọc được thành các phần đưa vào các chỉ số input
                        string[] inputs = line.Split(':');
                        DateTime dt = DateTime.Parse(inputs[0], System.Globalization.CultureInfo.InvariantCulture);
                        eventsList.events.Add(new Events(inputs[1], dt));
                        gridEventsList.Rows.Add(eventsList.events[quantity].TenSuKien, eventsList.events[quantity].NgayThang.ToString("MM-dd-yyyy"));
                        quantity++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            string[] d = new string[3];
            for (int i = 0; i < gridEventsList.RowCount; i++)
            {
                d = gridEventsList.Rows[i].Cells[1].Value.ToString().Split('-');
                int month = int.Parse(d[0]);
                int day = int.Parse(d[1]);
                gridEventsList.Rows[i].Cells[2].Value = DaysBetween(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year,
                                                                    month, day, (month > DateTime.Now.Month) ? DateTime.Now.Year : DateTime.Now.Year + 1);
            }
            
            SortDayRemaining();
            gridEventsList.CurrentCell = gridEventsList.Rows[0].Cells[0];
        }

        private void SortDayRemaining()
        {
            // Sắp xếp số ngày còn lại theo thứ tự tăng dần
            gridEventsList.Sort(gridEventsList.Columns[2], ListSortDirection.Ascending);
        }

        private int DaysBetween(int month, int day, int year, int m, int d, int y)
        {
            // Tính số ngày tuyệt đối
            int absoluteDay1 = DayNumber(month, day, year) + 365 * (year - 1)
                               + (year - 1) / 4 - (year - 1) / 100 + (year - 1) / 400;

            int absoluteDay2 = DayNumber(m, d, y) + 365 * (y - 1)
                               + (y - 1) / 4 - (y - 1) / 100 + (y - 1) / 400;

            return Math.Abs(absoluteDay1 - absoluteDay2);
        }

        private int DayNumber(int month, int day, int year)
        {
            // Tính số ngày từ ngày đầu tiên trong năm đến ngày cần tính
            int dayNumber = (month - 1) * 31 + day;
            if (month > 2)
            {
                dayNumber -= (4 * month + 23) / 10;
                if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
                    dayNumber++;
            }

            return dayNumber;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Event ev = new Event(eventsList);
            ev.ShowDialog();
            List<Events> events = new List<Events>();
            events = ev.evts;

            for (int i = eventsList.events.Count - events.Count; i < eventsList.events.Count; i++)
            {
                // Thêm dòng chứa sự kiện mới
                gridEventsList.Rows.Add(eventsList.events[i].TenSuKien, eventsList.events[i].NgayThang.ToString("MM-dd-yyyy"));

                // Tính số ngày còn lại đến lần tiếp theo của sự kiện
                gridEventsList.Rows[gridEventsList.RowCount - 1].Cells[2].Value = DaysBetween(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year,
                                                                                              eventsList.events[i].NgayThang.Month, eventsList.events[i].NgayThang.Day, (eventsList.events[i].NgayThang.Month > DateTime.Now.Month) ? DateTime.Now.Year : DateTime.Now.Year + 1);
                SortDayRemaining();
                gridEventsList.CurrentCell = gridEventsList.Rows[gridEventsList.RowCount - 1].Cells[0];
            }
        }

        private void UpdateEventsList()
        {
            for (int i = 0; i < eventsList.events.Count; i++)
            {
                StreamWriter sw = null;
                if (i == 0)
                {
                    // Ghi lại file
                    sw = new StreamWriter("Events list.txt");
                    sw.WriteLine(eventsList.events[i]);
                }
                else
                {
                    // Ghi các dòng tiếp theo trong file
                    sw = File.AppendText("Events list.txt");
                    sw.WriteLine(eventsList.events[i]);
                }

                sw.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = gridEventsList.CurrentCell.RowIndex;
            EditEvent edit = new EditEvent(eventsList.events[rowIndex]);
            edit.ShowDialog();

            // Gán lại tên sự kiện ở dòng được chọn
            gridEventsList.Rows[rowIndex].Cells[0].Value = eventsList.events[rowIndex].TenSuKien;

            // Gán lại ngày tháng ở dòng được chọn
            gridEventsList.Rows[rowIndex].Cells[1].Value = eventsList.events[rowIndex].NgayThang.ToString("MM-dd-yyyy");

            // Cập nhật lại số ngày còn lại cho sự kiện vừa thay đổi ở dòng được chọn
            gridEventsList.Rows[rowIndex].Cells[2].Value = DaysBetween(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year,
                                                                       eventsList.events[rowIndex].NgayThang.Month, eventsList.events[rowIndex].NgayThang.Day, (eventsList.events[rowIndex].NgayThang.Month > DateTime.Now.Month) ? DateTime.Now.Year : DateTime.Now.Year + 1);
            // Cập nhật sự kiện
            UpdateEventsList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to remove this event?", "",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Danh sách những dòng được chọn trong DataGridView
                List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in gridEventsList.SelectedRows)
                    selectedRows.Add(row);

                // Xoá những sự kiện được chọn
                foreach (DataGridViewRow row in selectedRows)
                {
                    eventsList.events.RemoveAt(row.Index);
                    gridEventsList.Rows.Remove(row);
                }

                // Cập nhật danh sách sự kiện
                UpdateEventsList();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            thread = new Thread(ReturnMenu);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void ReturnMenu()
        {
            Application.Run(new Menu());
        }
    }
}