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
    public partial class MaintainBooking : Form
    {
        public string conStr, str;
        Int64 id;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmm = new SqlCommand();
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlDataReader read;
        DataSet ds;
        public MaintainBooking()
        {
            InitializeComponent();
        }

        private void update()
        {
            str = @"SELECT * FROM BOOKINGS";
            cmm = new SqlCommand(str, conn);
            ds = new DataSet();
            adapt.SelectCommand = cmm;
            adapt.Fill(ds, "BOOKINGS");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "BOOKINGS";
        }

        private void button1_Click(object sender, EventArgs e)
        {
          try
            {
                DateTime date= dateTimePicker1.Value;
                string paymentMethod = comboBox1.Text;



                double paid = double.Parse(textBox3.Text);
                conn.Open();
                string compstr = "SELECT * FROM CLIENTS WHERE CLIENT_ID='" + comboBox4.Text + "'";
                int clientID = 0;

                cmm = new SqlCommand(compstr, conn);
                read = cmm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read() && read.HasRows)
                    {

                        clientID = (int)read["ID"];
                    }
                    read.Close();
                }

                int compID = 0;

                compstr = "SELECT * FROM COMPANIES WHERE COMPANY_NAME='" + comboBox5.Text + "'";
                cmm = new SqlCommand(compstr, conn);
                read = cmm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read() && read.HasRows)
                    {

                        compID = (int)read["COMPANY_ID"];
                    }
                    read.Close();
                }

                int mealID = 0;
              
                 compstr = "SELECT * FROM IN_FLIGHT_MENU WHERE Meal_Name='" + comboBox6.Text + "'";

                cmm = new SqlCommand(compstr, conn);
                read = cmm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read() && read.HasRows)
                    {

                        clientID = (int)read["Meal_ID"];
                    }
                    read.Close();
                }

                int destinationID = 0;
                compstr = "SELECT * FROM DESTINATIONS WHERE DESTINATION_LOCATION='" + comboBox7.Text + "'";

                cmm = new SqlCommand(compstr, conn);
                read = cmm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read() && read.HasRows)
                    {

                        destinationID = (int)read["DESTINATION_ID"];
                    }
                    read.Close();
                }

                str = "INSERT INTO BOOKINGS VALUES('" + date+ "','" + paymentMethod + "','" + paid + "','" + clientID  +"','" + compID  +"','" + mealID  +"','" + destinationID + "')";
                //str = "INSERT INTO CLIENTS VALUES('301111111111','r','r','r')";
                adapt = new SqlDataAdapter();
                cmm = new SqlCommand(str, conn);
                cmm.ExecuteNonQuery();
                this.update();

            }
           catch (Exception ex)
            {
                MessageBox.Show("ERROR: BOOKING already exists");
                conn.Close();
            }
            conn.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            string stre = "SELECT * FROM BOOKINGS WHERE BOOKING_ID LIKE '%" + textBox8.Text + "%'";
            adapt = new SqlDataAdapter(stre, conn);
            DataSet ds1 = new DataSet();
            adapt.Fill(ds1, "BOOKINGS");
            dataGridView1.DataSource = ds1;
            dataGridView1.DataMember = "BOOKINGS";
            if ((textBox8.Text != null) && (textBox8.Text != ""))
            {
                string str2 = "SELECT * FROM BOOKINGS WHERE BOOKING_ID='" + textBox8.Text + "'";
                cmm = new SqlCommand(str2, conn);
                read = cmm.ExecuteReader();
                while (read.Read())
                {
                    dateTimePicker2.Text = (read["BOOKING_DATE"].ToString());
                    comboBox2.Text = (read["PAYMENT_METHOD"].ToString());
                    textBox1.Text = (read["AMOUNT_PAID"].ToString());

                }
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker2.Value;
            string pMethod = comboBox2.Text;
            double amount = double.Parse(textBox1.Text);

            conn.Open();
          int  id = int.Parse(textBox8.Text);
            str = "UPDATE BOOKINGS SET BOOKING_DATE='" + date + "',PAYMENT_METHOD='" + pMethod +
                    "',AMOUNT_PAID='" + amount + "'WHERE BOOKING_ID='" + id + "'";
            cmm = new SqlCommand(str, conn);
            ds = new DataSet();

            adapt = new SqlDataAdapter();
            adapt.UpdateCommand = cmm;
            adapt.UpdateCommand.ExecuteNonQuery();
            this.update();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            id = Int64.Parse(textBox11.Text);
            str = @"DELETE FROM BOOKINGS WHERE BOOKING_ID='" + id + "'";
            cmm = new SqlCommand(str, conn);
            ds = new DataSet();

            adapt = new SqlDataAdapter();
            adapt.DeleteCommand = cmm;
            adapt.DeleteCommand.ExecuteNonQuery();
            this.update();
            conn.Close();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MaintainBooking_Load(object sender, EventArgs e)
        {
            try
            {
                conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ruang\Source\Repos\TheBigBang2\GroupProject223\GroupProject223\Airline.mdf;Integrated Security=True";
                conn = new SqlConnection(conStr);
                conn.Open();

                cmm = new SqlCommand();
                string sql;
                adapt = new SqlDataAdapter();
                sql = @"Select CLIENT_ID FROM CLIENTS";
                cmm = new SqlCommand(sql, conn);
                DataSet ds = new DataSet();
                adapt.SelectCommand = cmm;
                adapt.Fill(ds, "CLIENTS");
                comboBox4.DisplayMember = "CLIENT_ID";
                comboBox4.ValueMember = "CLIENT_ID";
                comboBox4.DataSource = ds.Tables["CLIENTS"];

                cmm = new SqlCommand();
                adapt = new SqlDataAdapter();
                sql = @"Select COMPANY_NAME FROM COMPANIES";
                cmm = new SqlCommand(sql, conn);
                ds = new DataSet();
                adapt.SelectCommand = cmm;
                adapt.Fill(ds, "COMPANIES");
                comboBox5.DisplayMember = "COMPANY_NAME";
                comboBox5.ValueMember = "COMPANY_NAME";
                comboBox5.DataSource = ds.Tables["COMPANIES"];

                cmm = new SqlCommand();
                adapt = new SqlDataAdapter();
                sql = @"Select Meal_Name FROM IN_FLIGHT_MENU";
                cmm = new SqlCommand(sql, conn);
                ds = new DataSet();
                adapt.SelectCommand = cmm;
                adapt.Fill(ds, "IN_FLIGHT_MENU");
                comboBox6.DisplayMember = "Meal_Name";
                comboBox6.ValueMember = "Meal_Name";
                comboBox6.DataSource = ds.Tables["IN_FLIGHT_MENU"];

                cmm = new SqlCommand();
                adapt = new SqlDataAdapter();
                sql = @"Select DESTINATION_LOCATION FROM DESTINATIONS";
                cmm = new SqlCommand(sql, conn);
                ds = new DataSet();
                adapt.SelectCommand = cmm;
                adapt.Fill(ds, "DESTINATIONS");
                comboBox7.DisplayMember = "DESTINATION_LOCATION";
                comboBox7.ValueMember = "DESTINATION_LOCATION";
                comboBox7.DataSource = ds.Tables["DESTINATIONS"];
         
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex);
                Application.Exit();
            }

            str = @"SELECT * FROM BOOKINGS";
            cmm = new SqlCommand(str, conn);
            ds = new DataSet();
            adapt.SelectCommand = cmm;
            adapt.Fill(ds, "BOOKINGS");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "BOOKINGS";
            conn.Close();
        }
    }
}
