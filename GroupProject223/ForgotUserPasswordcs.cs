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
    public partial class ForgotUserPasswordcs : Form
    {
        private SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\GroupProject223\GroupProject223\Person.mdf;Integrated Security=True");
        public ForgotUserPasswordcs()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            lblChoose.Visible = false;
            btnPassword.Visible = false;
            btnUsername.Visible = false;
            lblOption.Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
           
                string searchValue = tbSearch.Text;
                dataGridView1.Visible = true;
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {                   
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Equals(searchValue))
                        {
                            int rowIndex = row.Index;
                            dataGridView1.Rows[rowIndex].Cells. ToString() = true;
                            
                            MessageBox.Show(""+ dataGridView1.Rows[rowIndex].Selected.ToString());
                            break;
                        }
                    }





                    /*
                    if (tbSearch.Text == idnum)
                    {
                        DialogResult result = MessageBox.Show("Found");
                        if (result == DialogResult.OK)
                        {
                            dataGridView1.Visible = true;
                            rowIndex = row.Index;
                           
                            break;
                        }


                    }
                    else if (searchValue == nr)
                    {
                        DialogResult result = MessageBox.Show("Found");
                        if (result == DialogResult.OK)
                        {
                            dataGridView1.Visible = true;
                            rowIndex = row.Index;
                   
                            break;
                        }
                        
                        
                        
                    }
                    else if (searchValue == name)
                    {
                        DialogResult result = MessageBox.Show("Found");
                        if (result == DialogResult.OK)
                        {
                            dataGridView1.Visible = true;
                            rowIndex = row.Index;
                          
                            break;
                        }




                    }
                    else if (searchValue == surname)
                    {
                        DialogResult result = MessageBox.Show("Found");
                        if (result == DialogResult.OK)
                        {
                            dataGridView1.Visible = true;                           
                  
                            break;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Not found");
                    }
                    */
                }
                //     SqlCommand cmd = new SqlCommand("Select * from Person Where ID_Number ='" + tbSearch.Text + "' , Contact_Nr ='" + tbSearch.Text + "' , Name ='" + tbSearch.Text + "' , Surname ='" + tbSearch.Text + "' ", cnn);              
              //  dataGridView1.Rows[rowIndex].Selected = true;

            }
            else
            {
                MessageBox.Show("The search term : " + tbSearch.Text + " was not found. Please try again", "Account not found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                tbSearch.Focus();
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            RetrievePassword recover = new RetrievePassword();
            recover.Show();         
            this.Close();

        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsername_Click(object sender, EventArgs e)
        {
            RetrieveSystemID recover2 = new RetrieveSystemID();
            recover2.Show();
            this.Close();
        }

        private void ForgotUserPasswordcs_Load(object sender, EventArgs e)
        {
            string command = "Select * FROM Person ";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command, cnn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        //   dataGridView1.Columns["System_ID"].Visible = false;
         //   dataGridView1.Columns["Security_Question"].Visible = false;
       //     dataGridView1.Columns["Security_Answer"].Visible = false;
      //      dataGridView1.Columns["Contact_Nr"].Visible = false;
    //        dataGridView1.Columns["Email"].Visible = false;
    //        dataGridView1.Columns["Password"].Visible = false;
     //       dataGridView1.Columns[0].DefaultCellStyle.BackColor = System.Drawing.Color.Green;

            this.dataGridView1.AllowUserToAddRows = false;
           
            lblChoose.Visible = true;
            btnPassword.Visible = true;
            btnUsername.Visible = true;
            lblOption.Visible = true;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //       SqlCommand cmd = new SqlCommand("Select * from Person WHERE ID_Number LIKE '" + tbSearch.Text + "' AND Contact_Nr LIKE '" + tbSearch.Text + "'AND Name LIKE '" + tbSearch.Text + "'AND Surname LIKE'" + tbSearch.Text + "'", cnn);
            //         DataTable dt = new DataTable();
            //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //       adapter.Fill(dt);
            //         dataGridView1.DataSource = dt;
        }
    }
}
