using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject223
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, EventArgs e)
        {

        }

        //if one way selected
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label4.Visible = true;
                dateTimePicker1.Visible = true;
                label3.Visible = false;
                dateTimePicker2.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label4.Visible = true;
                dateTimePicker1.Visible = true;
                label3.Visible = true;
                dateTimePicker2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //load data to listbox

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

        }
    }
}
