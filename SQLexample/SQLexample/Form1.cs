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

namespace SQLexample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stationaryDBDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.stationaryDBDataSet.Product);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            string CN = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=StationaryDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(CN);
            command.Connection = connection;
            connection.Open();
            command.CommandText = "INSERT INTO Product (ID, Name, UnitPrice, QuantityInStock) VALUES (5, 'Pins', 5, 500)";
            int totalRowsAffected = command.ExecuteNonQuery();
            MessageBox.Show("Total Rows Inserted = " + totalRowsAffected);
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            string CN = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=StationaryDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(CN);
            command.Connection = connection;
            connection.Open();
            command.CommandText = "DELETE FROM Product WHERE Name = 'Pins'";
            int totalRowsAffected = (int)command.ExecuteNonQuery();
            MessageBox.Show("Total Rows Deleted = " + totalRowsAffected);
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string CN = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=StationaryDB;Integrated Security=True";
            string Query = "SELECT * FROM Product";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, CN);
            DataSet set = new DataSet();
            adapter.Fill(set, "Product");
            dataGridView2.DataSource = set.Tables["Product"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            string CN = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=StationaryDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(CN);
            command.Connection = connection;
            connection.Open();
            command.CommandText = "UPDATE Product SET QuantityInStock = 0 WHERE Name = 'Scale'";
            int totalRowsAffected = (int)command.ExecuteNonQuery();
            MessageBox.Show("Total Rows Updated = " + totalRowsAffected);
            connection.Close();
        }
    }
}
