using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GroupProject223
{
    public partial class LoginPage : Form
    {       
       
        private DataTable table = new DataTable();
        private SqlDataAdapter adapter;
     //   private String conString = ;
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");
        public LoginPage()
        {
            InitializeComponent();
            ReqID.Visible = false;
            ReqPassword.Visible = false;
            ReqConPassword.Visible = false;

            // check if person dbs is empty
          //  cnn = new SqlConnection(conString);
            cnn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Person", cnn);
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {               
                OwnerRegistration or = new OwnerRegistration();
                or.ShowDialog();
            }
            cnn.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
           
            if (tbUserID.Text == "")
            {
                ReqID.Visible = true;
            }
            if (tbPassword.Text == "")
            {
                ReqPassword.Visible = true;
            }
            if (tbConfirmPassword.Text == "")
            {
                ReqConPassword.Visible = true;
            }
            if (tbConfirmPassword.Text != tbPassword.Text)
            {
                MessageBox.Show("OOPS ! The passwords you entered did not match");
            }
            string command = "Select * FROM Person ";         
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);
            DataTable dt = new DataTable();
            adapter.Fill(ds);
            DataColumn dc = new DataColumn;
            dataGridView1.DataSource = ds.Tables[0];
            dc = dataGridView1.Columns.Contains.;
            try
            {
             //   cnn = new SqlConnection(conString);
                cnn.Open();
                string SystemID = tbUserID.Text; 
                string Password = tbPassword.Text;
                SqlCommand cmd = new SqlCommand("SELECT System_ID,Password From Person Where System_ID ='" + SystemID + "' and Password ='" + Password + "'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);                                   
                da.Fill(table);
               
                
                if (table.Rows.Count == 1)

                    {
                    MessageBox.Show("Success");
                    
                }               
                else
                {
                    MessageBox.Show("OOPS ! Seems like this username does not exist");   
                }
                cnn.Close();
            }
            catch (SqlException es)
            { 
            }
         
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration register = new Registration();
            register.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
//  Registration form = new Registration();
//form.Show();