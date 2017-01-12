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
    public partial class Form5 : Form
    {
        
         
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string st = "data source=puneeth;initial catalog=sai;integrated security=true";
            SqlConnection con = new SqlConnection(st);
            con.Open();
            string str = "select * from log123 where login='"+textBox1.Text+"'and password='"+textBox2.Text+"'";
            SqlCommand cmd = new SqlCommand(str,con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                int a = Convert.ToInt32(dr.GetValue(3));
                Form7 f7 = new Form7(a);
                this.Hide();
                f7.ShowDialog();
               
            }
            else 
            {
                MessageBox.Show("invalid user");
                con.Close();
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

       

       

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 f6= new Form6();
            this.Hide();
            f6.ShowDialog();
        }

       
    }
}
