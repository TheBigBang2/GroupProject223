using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GroupProject223
{
    public partial class Select_Meal : Form
    {
        string email,mName;
        public string conStr, str;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmm = new SqlCommand();
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlDataReader read;
        DataSet ds;
        int company,mealID,bookID,price;
        public Select_Meal()
        {
            InitializeComponent();
        }

        private void Select_Meal_Load(object sender, EventArgs e)
        {
            try
            {
                conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ruang\Source\Repos\TheBigBang2\GroupProject223\GroupProject223\Airline.mdf;Integrated Security=True";
                conn = new SqlConnection(conStr);
                conn.Open();
                label5.Text = "Connected!";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex);
                Application.Exit();
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter valid email.");
            }
            else
            {
                conn.Open();
                email = textBox1.Text;
                str = @"SELECT * FROM CLIENTS WHERE CLIENT_EMAIL='" + email + "'";
                cmm = new SqlCommand(str, conn);
                int clientID = 0;
                read = cmm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read() && read.HasRows)
                    {

                        clientID = (int)read["ID"];
                    }
                    read.Close();
                }
                company = 0;

                str = @"SELECT * FROM BOOKINGS WHERE CLIENT_ID='" + clientID + "'";
                cmm = new SqlCommand(str, conn);
                read = cmm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read() && read.HasRows)
                    {
                        bookID = (int)read["BOOKING_ID"];
                        company = (int)read["COMPANY_ID"];
                    }
                    read.Close();
                }
                string companyName = "";

                str = @"SELECT * FROM COMPANIES WHERE COMPANY_ID='" + company + "'";
                cmm = new SqlCommand(str, conn);
                read.Close();
                read = cmm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read() && read.HasRows)
                    {
                        companyName = (read["COMPANY_NAME"].ToString());
                    }
                    read.Close();
                }
                textBox2.Text = companyName;


                cmm = new SqlCommand();
                string sql;
                adapt = new SqlDataAdapter();
                sql = @"Select MEAL_NAME FROM IN_FLIGHT_MENU WHERE COMPANY_ID='" + company + "'";
                read.Close();
                cmm = new SqlCommand(sql, conn);
                DataSet ds = new DataSet();
                adapt.SelectCommand = cmm;
                adapt.Fill(ds, "IN_FLIGHT_MENU");
                comboBox1.DisplayMember = "MEAL_NAME";
                comboBox1.ValueMember = "MEAL_NAME";
                comboBox1.DataSource = ds.Tables["IN_FLIGHT_MENU"];



                conn.Close();
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            conn.Close();

            string mDes = "";
            price = 0;
            listBox1.Items.Clear();
            conn.Open();
            str = @"SELECT * FROM IN_FLIGHT_MENU WHERE Meal_Name='" + comboBox1.Text + "'";

            cmm = new SqlCommand(str, conn);
            read.Close();
            read = cmm.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read() && read.HasRows)
                {
                    mDes = (read["Meal_Description"].ToString());
                    price = (int)read["MEAL_PRICE"];
                    mealID= (int)(read["Meal_ID"]);
                }
                read.Close();
            }
            listBox1.Items.Add("Meal description:");
            listBox1.Items.Add(mDes);
            listBox1.Items.Add("Price(R):");
            listBox1.Items.Add(price.ToString());


            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mName = comboBox1.Text;
            int fprice = 0;
            conn.Open();

            str = @"SELECT * FROM BOOKINGS WHERE BOOKING_ID='" + bookID + "'";

            cmm = new SqlCommand(str, conn);
            read.Close();
            read = cmm.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read() && read.HasRows)
                {
                    fprice = (int)read["AMOUNT_PAID"];
                }
                read.Close();
            }

            price = price + fprice;
            str = "UPDATE BOOKINGS SET AMOUNT_PAID='"+price+"', Meal_ID='" +mealID + "'WHERE BOOKING_ID='" +bookID + "'";
            cmm = new SqlCommand(str, conn);
            ds = new DataSet();

            adapt = new SqlDataAdapter();
            adapt.UpdateCommand = cmm;
            adapt.UpdateCommand.ExecuteNonQuery();
            listBox1.Items.Add("MEAL ADDED TO BILL:"+mName);

            conn.Close();
        }
    }
}
