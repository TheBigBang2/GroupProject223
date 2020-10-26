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
    public partial class ForgotUserPasswordcs : Form
    {
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");
        public ForgotUserPasswordcs()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            lblChoose.Visible = false;
            btnPassword.Visible = false;
            btnUsername.Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string command = "Select * FROM Person ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);
            DataTable dt = new DataTable();
            adapter.Fill(ds);
            DataColumn dc = new DataColumn();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["System_ID"].Visible = false;
            dataGridView1.Columns["Security_Question"].Visible = false;
            dataGridView1.Columns["Security_Answer"].Visible = false;
            dataGridView1.Columns["Contact_Nr"].Visible = false;
            dataGridView1.Columns["Email"].Visible = false;
            dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
            dataGridView1.Visible = true;
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Visible = true;
            lblChoose.Visible = true;
            btnPassword.Visible = true;
            btnUsername.Visible = true;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            RetrievePassword recover = new RetrievePassword();
            recover.Show();
            this.Close();

        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsername_Click(object sender, EventArgs e)
        {
            RetrieveSystemID recover2 = new RetrieveSystemID();
            recover2.Show();
            this.Close();
        }
    }
}
