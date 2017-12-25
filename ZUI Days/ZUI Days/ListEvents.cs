using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ZUI_Days
{
    public partial class ListEvents : Form
    {
        public ListEvents()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Event ev = new Event();
            ev.ShowDialog();

            gridEventsList.Rows.Clear();
            ListEvents_Load(sender, e);
            gridEventsList.CurrentCell = gridEventsList.Rows[gridEventsList.RowCount - 1].Cells[0];
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
                        string[] inputs = line.Split(':');
                        gridEventsList.Rows.Add(inputs[0], inputs[1]);
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Events evt = new Events();
            EditEvent edit = new EditEvent(evt);
            edit.ShowDialog();

            int rowIndex = gridEventsList.CurrentCell.RowIndex;
            gridEventsList.Rows[rowIndex].Cells[0].Value = evt.NgayThang;
            gridEventsList.Rows[rowIndex].Cells[1].Value = evt.TenSuKien;

            string[] date = new string[gridEventsList.RowCount];
            string[] eventName = new string[gridEventsList.RowCount];
            for (int i = 0; i < gridEventsList.RowCount; i++)
            {
                date[i] = gridEventsList.Rows[i].Cells[0].Value.ToString();
                eventName[i] = gridEventsList.Rows[i].Cells[1].Value.ToString();
            }

            gridEventsList.Rows.Clear();
            for (int i = 0; i < date.Length; i++)
            {
                StreamWriter sw = null;
                try
                {
                    if (i == 0)
                    {
                        sw = new StreamWriter("Events List.txt");
                        sw.WriteLine(date[i] + ":" + eventName[i]);
                    }
                    else
                    {
                        using (sw = File.AppendText("Events List.txt"))
                        {
                            sw.WriteLine(date[i] + ":" + eventName[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }

            ListEvents_Load(sender, e);
            gridEventsList.CurrentCell = gridEventsList.Rows[rowIndex].Cells[0];
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = gridEventsList.CurrentCell.RowIndex;
            gridEventsList.Rows.RemoveAt(rowIndex);

            for (int i = 0; i < gridEventsList.RowCount; i++)
            {
                StreamWriter sw = null;
                try
                {
                    if (i == 0)
                    {
                        sw = new StreamWriter("Events List.txt");
                        sw.WriteLine(gridEventsList.Rows[i].Cells[0].Value + ":" + gridEventsList.Rows[i].Cells[1].Value);
                    }
                    else
                    {
                        using (sw = File.AppendText("Events List.txt"))
                        {
                            sw.WriteLine(gridEventsList.Rows[i].Cells[0].Value + ":" + gridEventsList.Rows[i].Cells[1].Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
        }
    }
}