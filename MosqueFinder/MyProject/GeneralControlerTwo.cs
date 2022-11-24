using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace MyProject
{
    public partial class GeneralControlerTwo : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public GeneralControlerTwo()
        {
            InitializeComponent();
        }

        void GridView()
        {
            //Connection Between GridView & Database
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Nearby_Mosque where District = @District";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@District", comboBox2.Text);
            DataTable dataTable = new DataTable();
            con.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                dataTable.Load(sqlDataReader);
                dataGridView1.DataSource = dataTable;
            }

            //Data in GridView


            //Auto Size
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Nearby_Mosque where  Area=@Area";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@District", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Area", textBox1.Text);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                GridView();
            }
            else
            {
                MessageBox.Show("Data Not Found !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Nearby_Mosque where District=@District";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@District", comboBox2.Text);


            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                //SqlDataAdapter sda = new SqlDataAdapter(query, con);

                GridView();


                //Auto Size
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Data Not Found !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();

        }
    }
}
