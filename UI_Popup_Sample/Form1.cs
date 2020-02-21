using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Popup_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Alert(string msg, Form2.enmType type)
        {
            Form2 frm = new Form2();
            frm.showAlert(msg, type);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Alert("TEST MESSAGE", Form2.enmType.Success);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Alert("TEST MESSAGE", Form2.enmType.Warning);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Alert("TEST MESSAGE", Form2.enmType.Info);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Alert("TEST MESSAGE", Form2.enmType.Error);
        }


    }
}
