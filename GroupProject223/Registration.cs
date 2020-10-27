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
    public partial class Registration : Form
    {
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");
        private DataTable table = new DataTable();
        private SqlDataAdapter adapter;
        // private String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True";
        public Registration()
        {
            InitializeComponent();
            lblID.Visible = false;
            lblEmail.Visible = false;
            lblName.Visible = false;
            lblSurname.Visible = false;
            lblContactNr.Visible = false;
            lblPassword.Visible = false;
            lblConPassword.Visible = false;
            lblSecurityQues.Visible = false;
            lblSecAnswer.Visible = false;
            dataGridView1.Visible = false;
            lblValid.Visible = false;
            cbSecurity.SelectedIndex = 0;

            cnn.Open();
            string command = "Select Name FROM Person ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter2 = new SqlDataAdapter(command, cnn);
            DataTable dt = new DataTable();
            adapter2.Fill(ds);
            DataColumn dc = new DataColumn();
            dataGridView1.DataSource = ds.Tables[0];
            int numRows = dataGridView1.Rows.Count - 1;
            tbSystemID.Text = " " + numRows;
            cnn.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string SystemID = tbSystemID.Text;
            string IdNumber = tbIDNum.Text;
            string email = tbEmail.Text;
            string name = tbName.Text;
            string surname = tbSurname.Text;
            string contactNR = tbContactNr.Text;
            string password = tbPassword.Text;
            string ConPassword = tbConPassword.Text;
            string secQuestion = cbSecurity.SelectedItem.ToString();
            string secAnswer = tbSecAnswer.Text;
            //FOR LOOP EMAIL VALIDATION
            if (IsValidEmail(email) == false)
            {
                lblValid.Visible = true;
                tbEmail.Focus();
            }
           
     
            //check id is 13
            if (tbIDNum.Text.Length != 13)
            {
                DialogResult result = MessageBox.Show("Your ID Number is invalid.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    tbIDNum.Focus();
                }
            }

            if (tbIDNum.Text == "" || tbEmail.Text == "" || tbName.Text == "" || tbSurname.Text == "" || tbContactNr.Text == "" || tbPassword.Text == "" || tbConPassword.Text == "")
            {
                MessageBox.Show("Please enter all Required Fields and try again", "Required Fields", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                lblID.Visible = true;
                lblEmail.Visible = true;
                lblName.Visible = true;
                lblSurname.Visible = true;
                lblContactNr.Visible = true;
                lblPassword.Visible = true;
                lblConPassword.Visible = true;
                lblSecurityQues.Visible = true;
                lblSecAnswer.Visible = true;
              
            }   
            else if (tbPassword.Text != tbConPassword.Text)
            {
                MessageBox.Show("OOPS ! The passwords you entered did not match");
            }
            //This is where the Database entry will be made
            else 
            {
                try
                {

                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into Person (ID_Number, Email,Contact_Nr, Name , Surname, Password, Security_Question, Security_Answer) VALUES ('" + IdNumber + "','" + email + "','" + contactNR + "','" + name + "','" + surname + "','" + password + "','" + secQuestion + "','" + secAnswer + "')", cnn);
                    cmd.ExecuteNonQuery();
                    DataTable entry = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * From Person", cnn);
                    adapter.Fill(entry);                   
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    cnn.Close();
                    if (entry.Rows.Count != 0)
                    {
                        DialogResult result = MessageBox.Show("Registratiion was Successfully Processed","Registration Successfull", button, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            this.Close();
                            LoginPage page = new LoginPage();
                            page.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Registration was not succesfull. System Error.", "Registration Unsuccessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    

                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message);
                }
            }

       
      
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}

