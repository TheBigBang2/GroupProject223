using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GroupProject223
{
    public partial class OwnerRegistration : Form
    {
        private SqlConnection cnn;
        private DataTable table = new DataTable();
        private SqlDataAdapter adapter;
        private String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True";
        public OwnerRegistration()
        {
            InitializeComponent();
            lblIDNum.Visible = false;
            lblEmail.Visible = false;
            lblName.Visible = false;
            lblSurname.Visible = false;
            lblContactNr.Visible = false;
            lblSecAnswer.Visible = false;
            lblSecurityQues.Visible = false;
            lblPass.Visible = false;
            lblConPass.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbIDnumber.Text == "")
            {
                lblIDNum.Visible = true;
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
                lblPass.Visible = true;
                lblConPass.Visible = true;
            }
            else if (tbPassword.Text != tbConPassword.Text)
            {
                MessageBox.Show("OOPS ! The passwords you entered did not match");
            }
            if(cbSecurity.SelectedIndex.ToString() == "")
            {
                lblSecurityQues.Visible = true;
            }
            if(tbSecAnswer.Text == "")
            {
                lblSecAnswer.Visible = true;
            }

            //This is where the Database entry will be made
            string SystemID = tbOwnerID.Text;
            string IdNumber = tbIDnumber.Text;
            string email = tbEmail.Text;
            string name = tbName.Text;
            string surname = tbSurname.Text;
            string contactNR = tbContactNr.Text;
            string password = tbPassword.Text;
            string ConPassword = tbConPassword.Text;
            string SecQuestion = cbSecurity.SelectedItem.ToString();
            string SecAnswer = tbSecAnswer.Text;

            try
            {
                cnn = new SqlConnection(conString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Person (ID_Number, Email, Name ,Surname ,Contact_Nr ,Password, Security_Question, Security_Answer) VALUES ('"+IdNumber+"','"+email+"','"+name+"','"+surname+"','"+contactNR+"','"+password+"','"+SecQuestion+"','"+SecAnswer+"')", cnn);
                cmd.ExecuteNonQuery();
                adapter = new SqlDataAdapter("Select * From Person", cnn);
                adapter.Fill(table);
                MessageBoxButtons button = MessageBoxButtons.OK;
                if (table.Rows.Count != 0)                  
                {DialogResult result = MessageBox.Show("Thank you and Congratulions Mr/Mrs" + tbSurname.Text + " on your brand new sytem !" +
                    "***Remember that you should use ID = 00000 to acces this system as the owner*** ","Congratulations" ,button);     
                    if(result == DialogResult.OK)
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

        private void btnSetup_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
