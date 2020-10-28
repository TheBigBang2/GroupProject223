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
    public partial class Booking : Form
    {
        public string conStr, str,sql;

        SqlConnection conn = new SqlConnection();
        SqlCommand cmm = new SqlCommand();
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlDataReader read;
        DataSet ds;
        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ruang\source\repos\GroupProject223\GroupProject223\Airline.mdf;Integrated Security=True";
            conn = new SqlConnection(conStr);
            conn.Open();
            cmm = new SqlCommand();
            adapt = new SqlDataAdapter();
            sql = @"Select DEPARTURE_LOCATION FROM DESTINATIONS";
            cmm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adapt.SelectCommand = cmm;
            adapt.Fill(ds, "DESTINATIONS");
            comboBox1.DisplayMember = "DEPARTURE_LOCATION";
            comboBox1.ValueMember = "DEPARTURE_LOCATION";
            comboBox1.DataSource = ds.Tables["DESTINATIONS"];
            listBox1.Items.Clear();
            sql = @"Select COMPANY_NAME FROM COMPANIES";
            cmm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adapt.SelectCommand = cmm;
            adapt.Fill(ds, "COMPANIES");
            comboBox4.DisplayMember = "COMPANY_NAME";
            comboBox4.ValueMember = "COMPANY_NAME";
            comboBox4.DataSource = ds.Tables["COMPANIES"];
            listBox1.Items.Clear();







            conn.Close();
        }

        //if one way selected
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        DateTime ret,go;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string compstr = "SELECT FLIGHT_DATE FROM DESTINATIONS WHERE DESTINATION_LOCATION='" + comboBox2.Text + "'";


            cmm = new SqlCommand(compstr, conn);
            read = cmm.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read() && read.HasRows)
                {

                    dateTimePicker1.Value = (DateTime)read["FLIGHT_DATE"];
                }
                read.Close();
            }
            conn.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string compstr = "SELECT * FROM CLIENTS WHERE CLIENT_EMAIL='" + textBox1.Text + "'";
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
            int mealID = 0;
            compstr = "SELECT * FROM COMPANIES WHERE COMPANY_NAME='" + comboBox4.Text + "'";
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

            int destinationID = 0;
            compstr = "SELECT * FROM DESTINATIONS WHERE DESTINATION_LOCATION='" + comboBox2.Text + "'";

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






            int paid = 750;
            str = "INSERT INTO BOOKINGS VALUES('" + go + "','" + comboBox3.Text + "','" + paid + "','" + clientID + "','" + compID + "','" + mealID + "','" + destinationID + "')";
            //str = "INSERT INTO CLIENTS VALUES('301111111111','r','r','r')";
            adapt = new SqlDataAdapter();
            cmm = new SqlCommand(str, conn);
            cmm.ExecuteNonQuery();
            MessageBox.Show("BOOKING MADE");
            button4.Enabled = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Select_Meal s1 = new Select_Meal();
            s1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            sql = @"Select DESTINATION_LOCATION FROM DESTINATIONS WHERE DEPARTURE_LOCATION='" + comboBox1.Text + "'";
            cmm = new SqlCommand(sql, conn);
            ds = new DataSet();
            adapt.SelectCommand = cmm;
            adapt.Fill(ds, "DESTINATIONS");
            comboBox2.DisplayMember = "DESTINATION_LOCATION";
            comboBox2.ValueMember = "DESTINATION_LOCATION";
            comboBox2.DataSource = ds.Tables["DESTINATIONS"];

        

            conn.Close();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            go = dateTimePicker1.Value;

            listBox1.Items.Add("Client email:");
            listBox1.Items.Add(textBox1.Text);
            listBox1.Items.Add("Destination:");
            listBox1.Items.Add(comboBox2.Text);
            listBox1.Items.Add("Departure Location:");
            listBox1.Items.Add(comboBox1.Text);
            listBox1.Items.Add("Flight Date:");
            listBox1.Items.Add(go.ToString());
            listBox1.Items.Add("Payment method:");
            listBox1.Items.Add(comboBox3.Text);
            conn.Close();
            conn.Open();
           
            conn.Close();


            //load data to listbox

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
            listBox1.Items.Clear();

        }
    }
}
