using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GroupProject223
{
    public partial class MaintainMenu : Form
    {
        public string conStr, str;
        SqlConnection conn = new SqlConnection();
        string compstr;
        SqlCommand cmm = new SqlCommand();
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlDataReader read;
        DataSet ds;
        public MaintainMenu()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void update()
        {
            str = @"SELECT * FROM IN_FLIGHT_MENU";
            cmm = new SqlCommand(str, conn);
            ds = new DataSet();
            adapt.SelectCommand = cmm;
            adapt.Fill(ds, "IN_FLIGHT_MENU");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "IN_FLIGHT_MENU";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string des = textBox2.Text;
                if (string.IsNullOrEmpty(textBox1.Text) | string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Enter valid values.");
                }
                else
                {
                    double price = Convert.ToDouble(textBox3.Text);
                    conn.Open();
                    compstr = "SELECT * FROM COMPANIES WHERE COMPANY_NAME='" + comboBox1.Text + "'";
                    int compID = 0;

                    cmm = new SqlCommand(compstr, conn);
                    read = cmm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read() && read.HasRows)
                        {

                            compID = (int)read["Company_ID"];
                        }
                        read.Close();
                    }

                    str = "INSERT INTO IN_FLIGHT_MENU VALUES('" + name + "','" + des + "','" + price + "','" + compID + "')";
                    //str = "INSERT INTO CLIENTS VALUES('301111111111','r','r','r')";
                    adapt = new SqlDataAdapter();
                    cmm = new SqlCommand(str, conn);
                    cmm.ExecuteNonQuery();
                    this.update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: MENU ID(" + textBox1.Text + ") already exists" + ex.Message);
                conn.Close();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox4.Text);
            string name = textBox8.Text;
            string des = textBox6.Text;
            if (string.IsNullOrEmpty(textBox1.Text) | string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Enter valid values.");
            }
            else
            {
                double price = Convert.ToDouble(textBox10.Text);

                conn.Open();

                str = "UPDATE IN_FLIGHT_MENU SET MEAL_NAME='" + name + "',MEAL_DESCRIPTION='" + des +
                        "',MEAL_PRICE='" + price + "'WHERE MEAL_ID='" + id + "'";
                cmm = new SqlCommand(str, conn);
                ds = new DataSet();

                adapt = new SqlDataAdapter();
                adapt.DeleteCommand = cmm;
                adapt.DeleteCommand.ExecuteNonQuery();
                this.update();
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox11.Text;
            conn.Open();
            Name = textBox11.Text;
            str = @"DELETE FROM IN_FLIGHT_MENU WHERE MEAL_id='" + name + "'";
            cmm = new SqlCommand(str, conn);
            ds = new DataSet();

            adapt = new SqlDataAdapter();
            adapt.DeleteCommand = cmm;
            adapt.DeleteCommand.ExecuteNonQuery();
            this.update();
            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            string stre = "SELECT * FROM IN_FLIGHT_MENU WHERE Meal_ID LIKE '%" + textBox4.Text + "%'";
            adapt = new SqlDataAdapter(stre, conn);
            DataSet ds1 = new DataSet();
            adapt.Fill(ds1,"IN_FLIGHT_MENU");
            dataGridView1.DataSource = ds1;
            dataGridView1.DataMember = "IN_FLIGHT_MENU";
            if ((textBox4.Text != null) && (textBox4.Text != ""))
            {
                string str2 = "SELECT * FROM IN_FLIGHT_MENU WHERE Meal_ID='" + textBox4.Text + "'";
                cmm = new SqlCommand(str2, conn);
                read = cmm.ExecuteReader();
                if (read.HasRows)
                {
                    int t = 0;
                    while (read.Read()&&read.HasRows)
                    { t = t++;

                        textBox8.Text = (read["Meal_Name"].ToString());
                        textBox6.Text = (read["Meal_Description"].ToString());
                        textBox10.Text = (read["MEAL_PRICE"].ToString());

                    }
                }
            }
            conn.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        private void MaintainMenu_Load_1(object sender, EventArgs e)
        {

        }

        private void MaintainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ruang\source\repos\GroupProject223\GroupProject223\Airline.mdf;Integrated Security=True";
                conn = new SqlConnection(conStr);
                conn.Open();

                cmm=new SqlCommand();
                string sql;
                adapt = new SqlDataAdapter();
                sql = @"Select COMPANY_NAME FROM COMPANIES";
                cmm = new SqlCommand(sql, conn);
                DataSet ds = new DataSet();
                adapt.SelectCommand = cmm;
                adapt.Fill(ds, "COMPANIES");
                comboBox1.DisplayMember = "COMPANY_NAME";
                comboBox1.ValueMember = "COMPANY_NAME";
                comboBox1.DataSource = ds.Tables["COMPANIES"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex);
                Application.Exit();
            }

            str = @"SELECT * FROM IN_FLIGHT_MENU";
            cmm = new SqlCommand(str, conn);
            ds = new DataSet();
            adapt.SelectCommand = cmm;
            adapt.Fill(ds, "IN_FLIGHT_MENU");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "IN_FLIGHT_MENU";
            conn.Close();
        }
    }
}
