using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting;
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
            string command = "Select * FROM Person ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter2 = new SqlDataAdapter(command, cnn);
            DataTable dt = new DataTable();
            adapter2.Fill(ds);
            DataColumn dc = new DataColumn();
            dataGridView1.DataSource = ds.Tables[0];
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString() == null)
                {
                    MessageBox.Show("The System ID you have entered does not exist");
                }
                else if (row.Cells[0].Value.ToString().Contains(tbUserID.Text))
                {
                    MessageBox.Show("The System ID you have entered does not exist");
                }
                else
                {
                    MessageBox.Show("The System ID you have entered does not exist");
                }
               
            }
            //Before
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
            Help form = new Help();
            form.Show();
        }

        private void clickForget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotUserPasswordcs forget = new ForgotUserPasswordcs();
            forget.Show();
        }

        private void UpdateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tbUserID.Text == ""|| tbPassword.Text == "" || tbConfirmPassword.Text == "")
            {
                MessageBox.Show("Please fill in all the required fields !", "Required Fields", MessageBoxButtons.OK);
                ReqID.Visible = true;
                ReqPassword.Visible = true;
                ReqConPassword.Visible = true;
            }
            else if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("Oops ! The passwords you have entered did not match");
            }
            else
            {
                EditAccount edit = new EditAccount();
                edit.Show();
            }
            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {      
        Registration form = new Registration();
        form.Show();
        }
    }
}