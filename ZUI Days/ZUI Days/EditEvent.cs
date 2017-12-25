using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZUI_Days
{
    public partial class EditEvent : Form
    {
        public Events _evt;

        public EditEvent(Events evt)
        {
            InitializeComponent();
            _evt = evt;
            txtEvent.Text = _evt.TenSuKien;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtEvent, "");
            if (txtEvent.Text == "")
            {
                errorProvider.SetError(txtEvent, "You haven't enter event!");
                return;
            }

            _evt.NgayThang = dtpDate.Value.ToString("MM-dd-yyyy");
            _evt.TenSuKien = txtEvent.Text;
            Close();
        }
    }
}
