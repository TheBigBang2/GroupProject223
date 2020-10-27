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
            string command = "SELECT * WHERE System_ID = '" + tbSystemID.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);
            DataTable dt = new DataTable();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            tbSystemID.Text = LoginPage.SetValueForUserID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
