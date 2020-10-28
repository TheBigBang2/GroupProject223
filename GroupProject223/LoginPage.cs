using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace GroupProject223
{
    public partial class LoginPage : Form
    {
        public static string SetValueForUserID = "";
        public static string SetValueForPassword = "";
        public static string SetValueForEmail = "";
        public static string SetValueForName = "";
        public static string SetValueForSurname = "";
        public static string SetValueForContactNumber = "";
        public static string SetValueForSecQuestion = "";
        public static string SetValueForSeqAnswer = "";
        private DataTable table = new DataTable();
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");


        public LoginPage()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            string command = "Select * FROM Person ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter2 = new SqlDataAdapter(command, cnn);
            adapter2.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ReqID.Visible = false;
            ReqPassword.Visible = false;
            ReqConPassword.Visible = false;

            //saving values and refreshing on pageload

            // check if person dbs is empty
            cnn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Person", cnn);
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                OwnerRegistration or = new OwnerRegistration();
                or.ShowDialog();
                cnn.Close();
            }
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void refreshPage()
        {
            tbConfirmPassword.Text = "";
            tbPassword.Text = "";
            tbUserID.Text = "";

        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //Values are assigned at login button press : 
            SetValueForUserID = tbUserID.Text;
            SetValueForPassword = tbPassword.Text;
     
            //Before
            if (tbUserID.Text == "" || tbPassword.Text == "" || tbConfirmPassword.Text == "")
            {
                MessageBox.Show("Please ensure all required fields are selected :","Required Fields", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                ReqID.Visible = true;
                ReqPassword.Visible = true;
                ReqConPassword.Visible = true;
                refreshPage();
            }
            else if (tbConfirmPassword.Text != tbPassword.Text)
            {
                MessageBox.Show("OOPS ! The passwords you entered did not match","Incorrect Password",MessageBoxButtons.RetryCancel,MessageBoxIcon.Information);
                refreshPage();
            }
            else
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string testUsername = row.Cells[0].Value.ToString();
                    string testPassword = row.Cells[6].Value.ToString();
                    if (tbUserID.Text == testUsername)
                    { 
                        if (row.Cells[6].Value.ToString().Contains(tbPassword.Text) )
                        {
                            DialogResult result = MessageBox.Show("Succesfully Logged In ", "Login Succesfull !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) ;
                            if (result == DialogResult.OK)
                            {
                         
                                //Open first form after Member login
                                refreshPage();
                                break;
                            }
                        }
                        else
                        {
                            DialogResult result4 = MessageBox.Show("Password you have entered does not exist", "Unsuccesfull Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (result4 == DialogResult.OK)
                            {
                                refreshPage();
                                break;
                            }

                        }             
                    }                                   
                    else 
                    {
                        DialogResult result2 = MessageBox.Show("The System ID or Password you have entered does not exist","Unsuccesfull Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if(result2 == DialogResult.OK)
                        {
                            refreshPage();
                            break;
                        }
                        
                       
                    }
                }

            }
                
            
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration register = new Registration();
            refreshPage();
            register.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help form = new Help();
            refreshPage();
            form.Show();
        }

        private void clickForget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotUserPasswordcs forget = new ForgotUserPasswordcs();
            refreshPage();
            forget.Show();
        }

        private void UpdateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tbUserID.Text == ""|| tbPassword.Text == "" || tbConfirmPassword.Text == "")
            {
                MessageBox.Show("Please fill in all the required fields !", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //      string testUsername = row.Cells[0].Value.ToString();
                    //      string testPassword = row.Cells[6].Value.ToString();
                    try
                    {

                        if (tbUserID.Text == row.Cells[0].Value.ToString())
                        {
                            if (row.Cells[6].Value.ToString().Contains(tbPassword.Text))
                            {
                                SetValueForUserID = tbUserID.Text;
                                DialogResult result = MessageBox.Show("Your account details are currently saved as the following :", "Success ! Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (result == DialogResult.OK)
                                {
                                    EditAccount edit = new EditAccount();                                 
                                    edit.Show();
                                    refreshPage();
                                    break;
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                            else
                            {
                                DialogResult result4 = MessageBox.Show("Please enter a Valid Account to edit or refer to the forgot ID or forgot Password link", "Unsuccesfull, Access Denied", MessageBoxButtons.RetryCancel);
                                if (result4 == DialogResult.Retry)
                                {
                                    tbUserID.Focus();
                                    break;
                                }
                                if (result4 == DialogResult.Cancel)
                                {
                                    refreshPage();
                                }
                            }
                        }


                        else
                        {
                            DialogResult result2 = MessageBox.Show("The System ID or Password you have entered does not exist", "Unsuccesfull Login", MessageBoxButtons.OK);
                            if (result2 == DialogResult.OK)
                            {
                                break;
                            }
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        System.NullReferenceException nullex = new System.NullReferenceException("Account not found");
                        throw nullex;
                    }
                }             
            }
            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {      
        Registration form = new Registration();
            refreshPage();
            form.Show();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string value = e.Value as string;
            if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))
            {
                e.Value = e.CellStyle.NullValue;
                e.FormattingApplied = true;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
        }

        private void btnExxit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

    }
}