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
        private SqlConnection cnn;
        private DataTable table = new DataTable();
        private SqlDataAdapter adapter;
        private String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True";
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
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbIDNum.Text == "")
            {
                lblID.Visible = true;
            }
            if (tbEmail.Text == "")
            {
                lblEmail.Visible = true;
            }
            if (tbName.Text == "")
            {
                lblName.Visible = true;
            }
            if (tbSurname.Text == "")
            {
                lblSurname.Visible = true;
            }
            if (tbContactNr.Text == "")
            {
                lblContactNr.Visible = true;
            }
            if (tbPassword.Text == "" || tbConPassword.Text == "")
            {
                lblPassword.Visible = true;
                lblConPassword.Visible = true;
            }
            else if (tbPassword.Text != tbConPassword.Text)
            {
                MessageBox.Show("OOPS ! The passwords you entered did not match");
            }

            //This is where the Database entry will be made
            tbSystemID.Text = "00001";
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
            try
            {
                cnn = new SqlConnection(conString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Person (System_ID, ID_Number, Email, Name ,Surname ,Contact_Nr ,Password, Security_Question, Security_Answer) VALUES ('" + SystemID + "','" + IdNumber + "','" + email + "','" + name + "','" + surname + "','" + contactNR + "','" + password + "','"+secQuestion+"','"+secAnswer+"')", cnn);
                cmd.ExecuteNonQuery();
                adapter = new SqlDataAdapter("Select * From Person", cnn);
                adapter.Fill(table);
                MessageBoxButtons button = MessageBoxButtons.OK;
                if (table.Rows.Count != 0)
                {
                    DialogResult result = MessageBox.Show("Thank you and Congratulions Mr/Mrs" + tbSurname.Text + " on your new account !" +
                       ""+ "\n" +"***Remember that you should use ID = '" + tbSystemID.Text+"'*** ", "Congratulations", button);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                        LoginPage page = new LoginPage();
                        page.Show();
                    }
                }
                else
                {
                    MessageBox.Show("The Registration was not succesfull. System Error. Please contact the system Creators.");
                }
                cnn.Close();

            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
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
    }
}

