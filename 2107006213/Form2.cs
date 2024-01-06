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
using Org.BouncyCastle.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2107006213
{
    public partial class Form2 : Form
    {
        private int lastSelectedRowIndex = -1;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        DataTable dt;
        public Form2()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=restaurant;Uid=root;Pwd=;");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tab1.SelectedIndex = 0;
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT * FROM staff", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            tab1.SelectedIndex = 1;
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT stock_id,item,quantity_kg FROM stock", con);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tab1.SelectedIndex = 2;
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT * FROM expense", con);
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "INSERT INTO staff(name, surname, gender, date_of_birth, salary) VALUES (@name, @surname, @gender, @dob, @salary)";
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@surname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@dob", dob1.Value);
                cmd.Parameters.AddWithValue("@salary", txtsalary.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                string selectQuery = "SELECT staff_id, name, surname, gender, date_of_birth, salary FROM staff";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int selectedID = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["staff_id"].Value);
                string deleteQuery = "DELETE FROM staff WHERE staff_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string selectQuery = "SELECT staff_id, name, surname, gender, date_of_birth, salary FROM staff";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string updatedName = update_name.Text;
                string updatedSurname = update_surname.Text;
                string updatedGender = comboBox2.SelectedItem?.ToString();
                DateTime updatedDof = dob2.Value;
                string updatedSalary = update_salary.Text;

                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int selectedID = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["staff_id"].Value);

                string setQuery = "SET ";
                bool setUsed = false;

                if (!string.IsNullOrWhiteSpace(updatedName))
                {
                    setQuery += $"name = @name";
                    setUsed = true;
                }

                if (!string.IsNullOrWhiteSpace(updatedSurname))
                {
                    if (setUsed) setQuery += ", ";
                    setQuery += $"surname = @surname";
                    setUsed = true;
                }

                if (!string.IsNullOrWhiteSpace(updatedGender))
                {
                    if (setUsed) setQuery += ", ";
                    setQuery += $"gender = @gender";
                    setUsed = true;
                }

                if (updatedDof != DateTime.MinValue)
                {
                    if (setUsed) setQuery += ", ";
                    setQuery += $"date_of_birth = @dob";
                    setUsed = true;
                }

                if (!string.IsNullOrWhiteSpace(updatedSalary))
                {
                    if (setUsed) setQuery += ", ";
                    setQuery += $"salary = @salary";
                    setUsed = true;
                }

                if (setUsed)
                {
                    string updateQuery = $"UPDATE staff {setQuery} WHERE staff_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@name", updatedName);
                        cmd.Parameters.AddWithValue("@surname", updatedSurname);
                        cmd.Parameters.AddWithValue("@gender", updatedGender);
                        cmd.Parameters.AddWithValue("@dob", updatedDof);
                        cmd.Parameters.AddWithValue("@salary", updatedSalary);
                        cmd.Parameters.AddWithValue("@id", selectedID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    if (lastSelectedRowIndex != -1 && lastSelectedRowIndex < dataGridView1.Rows.Count)
                    {
                        dataGridView1.Rows[lastSelectedRowIndex].Selected = true;
                    }

                    string selectQuery = "SELECT staff_id, name, surname, gender, date_of_birth, salary FROM staff";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in at least one field to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectQuery = "SELECT staff_id, name, surname, gender, date_of_birth, salary FROM staff";

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT * FROM staff", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                string updatedQuantityKg = textBox1.Text;

                if (!string.IsNullOrWhiteSpace(updatedQuantityKg))
                {
                    int selectedIndex = dataGridView2.SelectedRows[0].Index;
                    int selectedID = Convert.ToInt32(dataGridView2.Rows[selectedIndex].Cells["stock_id"].Value);

                    string updateQuery = $"UPDATE stock SET quantity_kg = quantity_kg + @quantityToAdd WHERE stock_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@quantityToAdd", updatedQuantityKg);
                        cmd.Parameters.AddWithValue("@id", selectedID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    string selectQuery = "SELECT stock_id, item, quantity_kg FROM stock";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a value to add to the quantity_kg.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                string updatedQuantityKg = textBox2.Text;

                if (!string.IsNullOrWhiteSpace(updatedQuantityKg))
                {
                    int selectedIndex = dataGridView2.SelectedRows[0].Index;
                    int selectedID = Convert.ToInt32(dataGridView2.Rows[selectedIndex].Cells["stock_id"].Value);

                    string updateQuery = $"UPDATE stock SET quantity_kg = quantity_kg - @quantityToAdd WHERE stock_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@quantityToAdd", updatedQuantityKg);
                        cmd.Parameters.AddWithValue("@id", selectedID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    string selectQuery = "SELECT stock_id, item, quantity_kg FROM stock";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a value to add to the quantity_kg.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = "SELECT SUM(monthly_expense) FROM expense WHERE expense_id = 21";
                MySqlCommand cmd = new MySqlCommand(query, con);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    decimal monthlyExpenseSum = Convert.ToDecimal(result);
                    lblMonthlyExpense.Text = "Monthly Expense (Sum): " + monthlyExpenseSum.ToString();

                    // 21 numaralı expense_id için monthly_expense değerini güncelle
                    string updateQuery = "UPDATE expense SET monthly_expense = @monthlyExpenseSum WHERE expense_id = 21";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@monthlyExpenseSum", monthlyExpenseSum);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    lblMonthlyExpense.Text = "Monthly Expense not found for expense_id = 21";
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void button11_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            this.Visible = false;
            fr3.ShowDialog();
            this.Visible = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
