using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApplication6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "data source=puneeth;initial catalog=sai;integrated security=true";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string se="select * from logadm where login='"+textBox1.Text+"' and password='"+textBox2.Text+"'";
            SqlCommand cmd=new SqlCommand(se,con);
            SqlDataReader dr=cmd.ExecuteReader();
            if(dr.HasRows)
            { Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();

            }
            else
            {
                MessageBox.Show("invalid user");
            }
            



           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();

        }

       

       
    }
}
