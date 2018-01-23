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
        Events evts = new Events();

        public Event(EventsList _eventsList)
        {
            InitializeComponent();
            eventsList = _eventsList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save()
        {
            errorProvider.SetError(txtEvent, "");
            if (txtEvent.Text == "")
            {
                errorProvider.SetError(txtEvent, "You haven't enter event!");
                return;
            }

            StreamWriter sw = null;
            try
            {
                using (sw = File.AppendText("Events list.txt"))
                {
                    sw.WriteLine(evts);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            evts.NgayThang = dtpDate.Value;
            evts.TenSuKien = txtEvent.Text;
            eventsList.AddEvent(evts);
            Save();

            txtEvent.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
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