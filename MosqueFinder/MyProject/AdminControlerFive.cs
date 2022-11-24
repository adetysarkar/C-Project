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
using System.IO;

namespace MyProject
{
    public partial class AdminControlerFive : UserControl
    {
        string cs = @"Data Source=DESKTOP-HITS2UT\SQLEXPRESS;Initial Catalog=Mosque_Finder;Integrated Security=True;";

        public AdminControlerFive()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; .bmp)|.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection c = new SqlConnection(cs);
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    //c.Open();
                    string queary = "update Admin_Profile set Email=@Email,Phone=@Phone,Address=@Address,District=@District,Area=@Area,Picture=@Picture where Name=@Name";
                    SqlCommand cmd = new SqlCommand(queary, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                    cmd.Parameters.AddWithValue("@District", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Area", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Picture", SavePhoto());
                    int a = cmd.ExecuteNonQuery();
                    // c.Close();



                    if (a > 0)
                    {
                        MessageBox.Show("Information updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView();
                        //ResetControl();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to update Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    

        void BindGridView()
        {
            //SqlConnection con = new SqlConnection(cs);
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "select * from Admin_Profile";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@Username", textBox5.Text);
                DataTable dataTable = new DataTable();
                //con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    dataTable.Load(sqlDataReader);
                    dataGridView1.DataSource = dataTable;
                }





                dataTable.Load(sqlDataReader);

                dataGridView1.DataSource = dataTable;
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 100;

            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void AdminControlerFive_Load(object sender, EventArgs e)
        {

        }
    }
}
