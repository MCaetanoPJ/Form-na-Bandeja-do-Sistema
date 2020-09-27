using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iLabor_Printer_VS_Form_
{
    public partial class Form1 : Form
    {
        private bool allowVisible;
        private bool allowClose = false;

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = new Icon(GetType(), "Logo_iLabor.ico");
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            allowVisible = true;
            Show();
        }
    }
}
