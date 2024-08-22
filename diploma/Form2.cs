using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using static MaterialSkin.MaterialSkinManager;
using System.Data.SQLite;
using System.IO;
using Microsoft.Identity.Client;
using System.Data.SqlClient;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Collections;

namespace diploma
{
	public partial class Form2 :Form
	{
        string imagepath;
        string imagepath1;

		
        public Form2()
		{
			

			InitializeComponent();
			
			DataClasses1DataContext db = new DataClasses1DataContext();
			var query = db.GetTable<webbookstore>();
            var query2 = db.GetTable<genres>();

            listBox1.Items.Clear();

			foreach (var b in query)
			{
				listBox1.Items.Add(b);
			}

            listBox2.Items.Clear();

            foreach (var b in query2)
            {
                listBox2.Items.Add(b);
            }
        }
	


		private void button1_Click(object sender, EventArgs e)
		{
	
			
			


			DataClasses1DataContext db = new DataClasses1DataContext();
			var query = db.GetTable<webbookstore>();
            File.Copy(imagepath, Path.Combine(@"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\img", Path.GetFileName(imagepath)), true);

            
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.14,49170;Database=bookstore; User id=sa; Password=123;");
            conn.Open();
          
            SqlCommand cmd = new SqlCommand($"INSERT INTO webbookstore ([bookname],[price],[descrip],[genre],[stock],[releasedate],[imagename])SELECT '{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}',{Convert.ToInt32(textBox6.Text)},'{Convert.ToDateTime(textBox9.Text)}', BulkColumn FROM OPENROWSET(BULK 'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS\\MSSQL\\img\\{imagepath1}', SINGLE_BLOB) AS imagename;", conn);
            cmd.ExecuteNonQuery();


			listBox1.Items.Clear();

			foreach (var b in query)
			{
				listBox1.Items.Add(b);
			}

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;)|*.jpg;*.jpeg;*.gif;*.bmp;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    imagepath = open.FileName;


                    pictureBox1.Image = new Bitmap(open.FileName);

                    imagepath1 = imagepath;
                    imagepath1 = imagepath1.Substring(imagepath1.LastIndexOf("\\"));
                    imagepath1 = imagepath1.Remove(0, 1);

                    textBox5.Text = imagepath1;
                }
            }
            catch { MessageBox.Show("с картинкой возникла проблема пожалуйста выбер те другую картинку"); }   

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=DESKTOP-OFJ100G\\SQLEXPRESS;Database=bookstore; User=sa; Password=123;";

            SqlConnection con = new SqlConnection(cs);
			con.Open();
			SqlCommand cmd = new SqlCommand();
			cmd = new SqlCommand($"UPDATE webbookstore SET stock = {Convert.ToInt32(textBox7.Text)} WHERE bookname = '{textBox8.Text}'; ", con);

			cmd.ExecuteNonQuery();
			DataClasses1DataContext db = new DataClasses1DataContext();
            var query = db.GetTable<webbookstore>();

            listBox1.Items.Clear();

            foreach (var b in query)
            {
                listBox1.Items.Add(b);
            }
            con.Close();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.14,49170;Database=bookstore; User id=sa; Password=123;");
            conn.Open();

            SqlCommand cmd = new SqlCommand($"INSERT INTO genres VALUES ('{textBox4.Text}')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            DataClasses1DataContext db = new DataClasses1DataContext();
           
            var query2 = db.GetTable<genres>();


            listBox2.Items.Clear();

            foreach (var b in query2)
            {
                listBox2.Items.Add(b);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.14,49170;Database=bookstore; User id=sa; Password=123;");
            conn.Open();

            SqlCommand cmd = new SqlCommand($"DELETE FROM  genres WHERE genrename='{textBox11.Text}'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            DataClasses1DataContext db = new DataClasses1DataContext();

            var query2 = db.GetTable<genres>();


            listBox2.Items.Clear();

            foreach (var b in query2)
            {
                listBox2.Items.Add(b);
            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.14,49170;Database=bookstore; User id=sa; Password=123;");
            conn.Open();

            SqlCommand cmd = new SqlCommand($"DELETE  FROM webbookstore WHERE bookname='{textBox10.Text}'", conn);
            cmd.ExecuteNonQuery();
          

            DataClasses1DataContext db = new DataClasses1DataContext();

            var query = db.GetTable<webbookstore>();
          
            

            foreach (var b in query)
            {
                listBox1.Items.Add(b);
            }

            conn.Close();
        }
    }
}
