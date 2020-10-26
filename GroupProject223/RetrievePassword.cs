using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject223
{
    public partial class RetrievePassword : Form
    {
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");
        public RetrievePassword()
        {
            InitializeComponent();
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            dataGridView1.Visible = false;
            btnLogin.Visible = false;
            btnChange.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            EditAccount edit = new EditAccount();
            edit.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            dataGridView1.Visible = true;
            btnLogin.Visible = true;
            btnChange.Visible = true;
            string command = "Select Password FROM Person ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);
            DataTable dt = new DataTable();
            adapter.Fill(ds);
            DataColumn dc = new DataColumn();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.RowHeadersVisible = false;                
           
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 200;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application refreshed");     
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
