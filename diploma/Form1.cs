using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MaterialSkin;
using MaterialSkin.Controls;
using static MaterialSkin.MaterialSkinManager;
using System.Data.SqlClient;

namespace diploma
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			

			DataClasses1DataContext db = new DataClasses1DataContext();
			var query = db.GetTable<orders>();

			listBox1.Items.Clear();
		
			foreach (var b in query)
			{
				listBox1.Items.Add(b);
			}
				DataClasses1DataContext db1 = new DataClasses1DataContext();
			var query2 = db1.GetTable<completeorders>();

			listBox2.Items.Clear();
		
			foreach (var b in query2)
			{
				listBox2.Items.Add(b);
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			DataClasses1DataContext db = new DataClasses1DataContext();
			var query = db.GetTable<orders>();
			DataClasses1DataContext db1 = new DataClasses1DataContext();
			var query2 = db1.GetTable<completeorders>();

			DateTime time= DateTime.Now;
			
			var res2 = from c in query
					   where c.ordernumber == Convert.ToInt32(textBox1.Text)
					   select c;

			res2.FirstOrDefault();
			try
			{
				if (res2.FirstOrDefault().ordernumber == Convert.ToInt32(textBox1.Text))
				{

					foreach (var item in res2)
					{
						query2.InsertOnSubmit(new completeorders(res2.FirstOrDefault().bookname, res2.FirstOrDefault().price, time));
						db1.SubmitChanges();
					}
					query.DeleteAllOnSubmit(res2);
					db.SubmitChanges();



				}
				else { MessageBox.Show($"  вы ввели неверные данные "); }
			}
			catch { MessageBox.Show($"  вы ввели неверные данные "); }
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

		private void button2_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();

			DataClasses1DataContext db = new DataClasses1DataContext();
			var query = db.GetTable<orders>();
			DataClasses1DataContext db1 = new DataClasses1DataContext();
			var query2 = db1.GetTable<completeorders>();

			DateTime time = DateTime.Now;

			var res2 = from c in query
					   where c.ordernumber == Convert.ToInt32(textBox1.Text)
					   select c;

			res2.FirstOrDefault();

						foreach (var b in query)
						{
						if (b.ordernumber == Convert.ToInt32(textBox1.Text)) {
							listBox1.Items.Add(b); }
						}

		}
		public void form2show()
		{
			Form2 newform2 = new Form2();
			newform2.ShowDialog();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			form2show();
		}

        private void button4_Click(object sender, EventArgs e)

        {
			try
			{
				string cs = "Data Source=DESKTOP-OFJ100G\\SQLEXPRESS;Database=bookstore; User=sa; Password=123;";

				SqlConnection con = new SqlConnection(cs);
				con.Open();
				SqlCommand cmd = new SqlCommand();

				cmd = new SqlCommand($"UPDATE orders SET orderstatus ='{textBox2.Text}' WHERE ordernumber='{Convert.ToInt32(textBox1.Text)}';", con);
				cmd.ExecuteNonQuery();
				DataClasses1DataContext db = new DataClasses1DataContext();
				var query = db.GetTable<orders>();

				listBox1.Items.Clear();

				foreach (var b in query)
				{
					listBox1.Items.Add(b);
				}
			}catch(Exception ex) { MessageBox.Show("поле не должно быть пустым"); }
        }
    }
}
