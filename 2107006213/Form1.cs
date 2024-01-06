using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2107006213
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=restaurant;Uid=root;Pwd=;");
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            txtPass.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtID.Text;
            string pass = txtPass.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM login where username='" + txtID.Text + "' AND password='" + txtPass.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (txtID.Text == "admin")
                {
                    Form2 fr2 = new Form2();
                    this.Visible = false;
                    fr2.ShowDialog();
                    this.Visible = true;
                }
                else 
                {
                    Form3 fr3 = new Form3();
                    this.Visible = false;
                    fr3.ShowDialog();
                    this.Visible = true;
                }

            }
            else
            {
                MessageBox.Show("Incorrect username or password entered.");
            }
            con.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Visible = false;
            fr2.ShowDialog();
            this.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            this.Visible = false;
            fr3.ShowDialog();
            this.Visible = true;
        }
    }

}
