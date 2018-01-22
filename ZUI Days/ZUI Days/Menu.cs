using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ZUI_Days
{
    public partial class Menu : Form
    {
        Thread thread;

        public Menu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Close();
            thread = new Thread(Start);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void Start()
        {
            Application.Run(new ListEvents());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}