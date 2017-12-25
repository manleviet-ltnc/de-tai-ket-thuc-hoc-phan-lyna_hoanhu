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
        EventsList eventsList = new EventsList();
        Events evts = new Events();

        public Event()
        {
            InitializeComponent();
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
                    sw.WriteLine(evts.NgayThang + ":" + evts.TenSuKien);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            evts.NgayThang = dtpDate.Value.ToString("MM-dd-yyyy");
            evts.TenSuKien = txtEvent.Text;
            eventsList.AddEvent(evts);
            Save();
        }
    }
}
