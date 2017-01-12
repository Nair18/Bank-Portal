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
    public partial class Form8 : Form
    {
        public Form8(string a,string b)
        {
            InitializeComponent();
            textBox1.Text = a;
            textBox2.Text = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("are u sure?","signout",MessageBoxButtons.YesNo);
                if(r==DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "data source=puneeth;initial catalog=sai;integrated security=true";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string se = "select * from drcr where acno="+textBox1.Text;
            SqlCommand cmd = new SqlCommand(se,con);
            SqlDataReader dr = cmd.ExecuteReader();
            dataGridView1.Visible = true;
            DataTable d = new DataTable();
            d.Load(dr);
            dataGridView1.DataSource = d;


 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(Convert.ToInt32(textBox1.Text));
            this.Hide();
            f7.ShowDialog();
        }

       
    }
}
