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
    public partial class RetrievePassword : Form
    {
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");
        public RetrievePassword()
        {
            InitializeComponent();
            lbl1.Visible = false;
            lblName.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            
           
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            EditAccount edit = new EditAccount();
            edit.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
          
            cbSecurity.Text = ForgotUserPasswordcs.question;
            if(tbSecAnswer.Text == ForgotUserPasswordcs.answer)
            {
                lblPass.Text = ForgotUserPasswordcs.password;
                lblName.Text = ForgotUserPasswordcs.UserName;
                lbl1.Visible = true;
                lblName.Visible = true;
                lbl3.Visible = true;
                lbl4.Visible = true;
                btnLogin.Visible = true;
            }
            else 
            {
                MessageBox.Show("Oops ! Try again");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application refreshed");     
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
