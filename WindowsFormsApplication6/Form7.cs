using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication6
{
    public partial class Form7 : Form
    {
        static string str = "data source=puneeth;initial catalog=sai;integrated security=true";
        SqlConnection con = new SqlConnection(str);
        public Form7(int x)
        {
            InitializeComponent();
            textBox1.Text = x.ToString();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            con.Open();
            string se = "select * from mybank where acno= "+textBox1.Text;
            SqlCommand cmd = new SqlCommand(se, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                byte[] img = (byte[])dr["pic"];
                textBox2.Text = dr.GetValue(1).ToString();
                textBox3.Text = dr.GetValue(3).ToString();
                textBox4.Text = dr.GetValue(2).ToString();
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
            }
            else
            {
                MessageBox.Show("enter acount no.");
              
            }
            con.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("are u sure?","signout",MessageBoxButtons.YesNo);
                if(r==DialogResult.Yes)
                {
                    Application.Exit();
                }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int b1 = Convert.ToInt32(textBox5.Text);
            int b2 = Convert.ToInt32(textBox4.Text);
            b2 = b1 + b2;
            con.Open();
            textBox4.Text = b2.ToString();
            DateTime dt = DateTime.Now;
           
            string se = "insert into drcr values(@acno,@dr,@cr,@date)";
            SqlCommand cmd = new SqlCommand(se, con);
            
            cmd.Parameters.AddWithValue("acno", textBox1.Text);
            cmd.Parameters.AddWithValue("dr", textBox6.Text);
            cmd.Parameters.AddWithValue("cr", textBox5.Text);
            cmd.Parameters.AddWithValue("date", dt);
            cmd.ExecuteNonQuery();
            con.Close();
            
           
            Form8 f8 = new Form8(textBox1.Text, textBox4.Text);
            this.Hide();
            f8.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int b1 = Convert.ToInt32(textBox6.Text);
            int b2 = Convert.ToInt32(textBox4.Text);
            b2 = b1 - b2;
            con.Open();
            textBox4.Text = b2.ToString();
            DateTime dt = DateTime.Now;
           
            string se = "insert into drcr values(@acno,@dr,@cr,@date);";
            SqlCommand cmd = new SqlCommand(se, con);
            cmd.Parameters.AddWithValue("acno", textBox1.Text);
            cmd.Parameters.AddWithValue("dr", textBox6.Text);
            cmd.Parameters.AddWithValue("cr", textBox5.Text);
            cmd.Parameters.AddWithValue("date", dt);
            cmd.ExecuteNonQuery();
            
            con.Close();
            Form8 f8 = new Form8(textBox1.Text, textBox4.Text);
            this.Hide();
            f8.ShowDialog();
        }

    }
}
