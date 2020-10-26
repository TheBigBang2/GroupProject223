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
    public partial class EditAccount : Form
    {
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");
        public EditAccount()
        {
            
            InitializeComponent();
            lblView.Visible = false;
           dataGridView1.Visible = false;
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {           
            lblView.Visible = true;
            dataGridView1.Visible = true;
            string command = "Select * FROM Person ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);
            DataTable dt = new DataTable();
            adapter.Fill(ds);
            DataColumn dc = new DataColumn();
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void SetFirstRowSelected()
        {
            string command = "Select * FROM Person ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);
            DataTable dt = new DataTable();
            adapter.Fill(ds);
            DataColumn dc = new DataColumn();
            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.Rows.Count > 0)
            {
                var row = dataGridView1.Rows[0];

                tbID.Text = row.Cells[1].Value.ToString();
                tbEmail.Text = row.Cells[2].Value.ToString();
                tbContact.Text = row.Cells[3].Value.ToString();
                tbName.Text = row.Cells[4].Value.ToString();
                tbSurname.Text = row.Cells[5].Value.ToString();              
            }
        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            SetFirstRowSelected();       
            
        }
    }
}
