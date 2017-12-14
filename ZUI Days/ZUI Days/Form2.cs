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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Events evts = new Events();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save()
        {
            StreamWriter write = null;
            try
            {
                write = new StreamWriter("danhsachsukien.txt");
                write.WriteLine(evts);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (write != null)
                    write.Close();
            }

          
            
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            evts.TenSuKien = tbxEvents.Text;
            Save();
        }
       

       
    }
}
