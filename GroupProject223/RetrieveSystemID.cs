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
    public partial class RetrieveSystemID : Form
    {
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");
        public RetrieveSystemID()
        {
            InitializeComponent();
 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RetrieveSystemID_Load(object sender, EventArgs e)
        {
            lblName.Text = ForgotUserPasswordcs.UserName;
            lblID.Text = ForgotUserPasswordcs.SystemID;
        }
    }
}
