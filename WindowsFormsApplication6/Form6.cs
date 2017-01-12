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
    public partial class Form6 : Form
    {
        
        
        public Form6()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "data source=puneeth;initial catalog=sai;integrated security=true";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string s = "select * from mybank where acno="+textBox1.Text;
            SqlCommand cmd1 = new SqlCommand(s, con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            string s1 = dr.GetString(1);
            if (s1.Trim()==textBox2.Text)
            {
                dr.Close();
                string se = "insert into log123 values(@login,@password,@acname,@acno)";
                SqlCommand cmd = new SqlCommand(se, con);

                cmd.Parameters.AddWithValue("login", textBox3.Text);
                cmd.Parameters.AddWithValue("password", textBox4.Text);
                cmd.Parameters.AddWithValue("acname", textBox2.Text);
                cmd.Parameters.AddWithValue("acno", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("e-bank is created");
                Form7 f7 = new Form7(Convert.ToInt32(textBox1.Text));
                this.Hide();
                f7.ShowDialog();
            }
            else
            {
                MessageBox.Show("sorry");
                
            }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.ShowDialog();
        }
    }
}
