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
            lblID.Visible = false;
            lblEmail.Visible = false;
            lblName.Visible = false;
            lblSurname.Visible = false;
            lblContact.Visible = false;
            lblPassword.Visible = false;
            lblConPassword.Visible = false;
            lblSecurityQues.Visible = false;
            lblSecAnswer.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {           
            lblView.Visible = true;
            dataGridView1.Visible = true;
            string SystemID = tbSystemID.Text;
            string IdNumber = tbID.Text;
            string email = tbEmail.Text;
            string name = tbName.Text;
            string surname = tbSurname.Text;
            string contactNR = tbContact.Text;
            string password = tbPassword.Text;
            string secQuestion = cbSecurity.Text;
            string secAnswer = tbSecAnswer.Text;
            //FOR LOOP EMAIL VALIDATION
            if (IsValidEmail(email) == false)
            {
                lblValid.Visible = true;
                tbEmail.Focus();
            }
            //check id is 13
            if (tbID.Text.Length != 13)
            {
                DialogResult result = MessageBox.Show("Your ID Number is invalid.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    tbID.Focus();
                }
            }
            if (tbID.Text == "" || tbEmail.Text == "" || tbName.Text == "" || tbSurname.Text == "" || tbContact.Text == "" || tbPassword.Text == "" || tbConfirmPassword.Text == "")
            {
                MessageBox.Show("Please enter all Required Fields and try again", "Required Fields", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                lblID.Visible = true;
                lblEmail.Visible = true;
                lblName.Visible = true;
                lblSurname.Visible = true;
                lblContact.Visible = true;
                lblPassword.Visible = true;
                lblConPassword.Visible = true;
                lblSecurityQues.Visible = true;
                lblSecAnswer.Visible = true;
            }
            else if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("OOPS ! The passwords you entered did not match");
            }
            //This is where the Database entry will be made
            else
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand ("UPDATE Person SET ID_Number = '" + IdNumber + "', Email = '" + email + "', Contact_Nr = '" + contactNR + "' , Name ='" + name + "' , Surname = '" + surname + "' , Password = '" + password + "', Security_Question = '" + secQuestion + "' , Security_Answer ='" + secAnswer + "'  WHERE System_ID LIKE '" + tbSystemID.Text+"'", cnn);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adapter2 = new SqlDataAdapter(cmd);
                    DataTable entry = new DataTable();
                    adapter2.Fill(entry);
                    MessageBoxButtons button = MessageBoxButtons.OK;               

                        DialogResult result = MessageBox.Show("Update Successfully Processed. Details Updated to the following :", "Update Successfull", button, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            string command = "SELECT * FROM Person WHERE System_ID LIKE '" + tbSystemID.Text + "'";                      
                            DataSet update = new DataSet();
                            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);
                            adapter.Fill(update);
                            dataGridView1.DataSource = update.Tables[0];
                        }
                    cnn.Close();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }
        private void EditAccount_Load(object sender, EventArgs e)
        {
            tbSystemID.Text = LoginPage.SetValueForUserID;
            string command = "SELECT * FROM Person WHERE System_ID LIKE '" + tbSystemID.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);          
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            tbID.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            cbSecurity.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            tbSecAnswer.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
            tbContact.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            tbEmail.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            tbPassword.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            tbConfirmPassword.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            tbName.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            tbSurname.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 150;
            this.dataGridView1.AllowUserToAddRows = false;
            
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
