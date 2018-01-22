using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ZUI_Days
{
    public partial class EditEvent : Form
    {
        Events evt;

        public EditEvent(Events _evt)
        {
            InitializeComponent();
            txtEvent.Text = _evt.TenSuKien;
            evt = _evt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtEvent, "");
            if (txtEvent.Text == "")
            {
                errorProvider.SetError(txtEvent, "You haven't enter event!");
                return;
            }

            evt.NgayThang = dtpDate.Value;
            evt.TenSuKien = txtEvent.Text;
            Close();
        }
    }
}