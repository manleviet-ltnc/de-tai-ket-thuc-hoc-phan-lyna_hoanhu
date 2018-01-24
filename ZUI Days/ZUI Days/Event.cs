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
    public partial class Event : Form
    {
        EventsList eventsList;
        public List<Events> evts = new List<Events>();   // Danh sách sự kiện vừa được thêm

        public Event(EventsList _eventsList)
        {
            InitializeComponent();
            eventsList = _eventsList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtEvent, "");
            if (txtEvent.Text == "")
            {
                errorProvider.SetError(txtEvent, "You haven't enter event!");
                return;
            }

            Events events = new Events();

            events.TenSuKien = txtEvent.Text;
            events.NgayThang = dtpDate.Value;
            evts.Add(events);

            eventsList.AddEvent(events);
            txtEvent.Text = "";
        }

        private void Save()
        {
            StreamWriter sw = null;
            try
            {
                using (sw = File.AppendText("Events list.txt"))
                {
                    foreach (Events ev in evts)
                        sw.WriteLine(ev);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Save();
            if (txtEvent.Text != "")
            {
                DialogResult result = MessageBox.Show("Are you want to close?", "",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    e.Cancel = false;
                else if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}