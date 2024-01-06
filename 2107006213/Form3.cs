using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2107006213
{
    public partial class Form3 : Form
    {
        private int lastSelectedRowIndex = -1;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        DataTable dt;

        public Form3()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=restaurant;Uid=root;Pwd=;");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tab1.SelectedIndex = 0;
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 1", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        string query = "SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 1";

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    int selectedOrderId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["OrderID"].Value);

                    string deleteQuery = "DELETE FROM orders  WHERE OrderID = " + selectedOrderId;
                    
                }
                else
                {
                    MessageBox.Show("Lütfen silinecek bir ürün seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tab1.SelectedIndex = 1;
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 2", con);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Hamburger', 1, 50, 1)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 1", con);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Pasta', 1, 30, 1)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 1", con);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Pizza', 1, 45, 1)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 1", con);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int selectedID = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["OrderID"].Value);
                string deleteQuery = "DELETE FROM orders WHERE OrderID = @id";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string selectQuery = "SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 1";
                DataTable dt = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                {
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                int totalPrice = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TotalPrice"] != DBNull.Value)
                    {
                        totalPrice += Convert.ToInt32(row["TotalPrice"]);
                    }
                }
                lblTotalPrice.Text = "Sum: " + totalPrice.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Hamburger', 1, 50, 2)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 2", con);
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice2.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Pasta', 1, 30, 2)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 2", con);
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice2.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Pizza', 1, 45, 2)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 2", con);
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice2.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView2.SelectedRows[0].Index;
                int selectedID = Convert.ToInt32(dataGridView2.Rows[selectedIndex].Cells["OrderID"].Value);
                string deleteQuery = "DELETE FROM orders WHERE OrderID = @id";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string selectQuery = "SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 2";
                DataTable dt2 = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                {
                    adapter.Fill(dt2);
                    dataGridView2.DataSource = dt2;
                }

                int totalPrice2 = 0;
                foreach (DataRow row in dt2.Rows)
                {
                    if (row["TotalPrice"] != DBNull.Value)
                    {
                        totalPrice2 += Convert.ToInt32(row["TotalPrice"]);
                    }
                }
                lblTotalPrice2.Text = "Sum: " + totalPrice2.ToString();
            }

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string selectTotalPriceQuery = "SELECT SUM(TotalPrice) AS TotalPriceSum FROM orders WHERE TableName = 1";
                MySqlCommand totalPriceCmd = new MySqlCommand(selectTotalPriceQuery, con);
                object result = totalPriceCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    decimal totalPriceSum = Convert.ToDecimal(result);
                    string updateIncomesQuery = "UPDATE income SET incomes = incomes + @totalPriceSum";
                    MySqlCommand updateIncomesCmd = new MySqlCommand(updateIncomesQuery, con);
                    updateIncomesCmd.Parameters.AddWithValue("@totalPriceSum", totalPriceSum);
                    int affectedRows = updateIncomesCmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        string deleteOrdersQuery = "DELETE FROM orders WHERE TableName = 1";
                        MySqlCommand deleteOrdersCmd = new MySqlCommand(deleteOrdersQuery, con);
                        deleteOrdersCmd.ExecuteNonQuery();
                        string updateTotalQuery = "UPDATE income SET total = (incomes - (SELECT monthly_expense FROM expense WHERE expense_id = 21))";
                        MySqlCommand updateTotalCmd = new MySqlCommand(updateTotalQuery, con);
                        updateTotalCmd.ExecuteNonQuery();
                        dt = new DataTable();
                        adapter = new MySqlDataAdapter("SELECT OrderID, ProductName FROM orders WHERE TableName = 1", con);
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Update();
                        dataGridView1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void lblTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string selectTotalPriceQuery = "SELECT SUM(TotalPrice) AS TotalPriceSum FROM orders WHERE TableName = 2";
                MySqlCommand totalPriceCmd = new MySqlCommand(selectTotalPriceQuery, con);
                object result = totalPriceCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    decimal totalPriceSum = Convert.ToDecimal(result);
                    string updateIncomesQuery = "UPDATE income SET incomes = incomes + @totalPriceSum";
                    MySqlCommand updateIncomesCmd = new MySqlCommand(updateIncomesQuery, con);
                    updateIncomesCmd.Parameters.AddWithValue("@totalPriceSum", totalPriceSum);
                    int affectedRows = updateIncomesCmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        string deleteOrdersQuery = "DELETE FROM orders WHERE TableName = 2";
                        MySqlCommand deleteOrdersCmd = new MySqlCommand(deleteOrdersQuery, con);
                        deleteOrdersCmd.ExecuteNonQuery();
                        string updateTotalQuery = "UPDATE income SET total = (incomes - (SELECT monthly_expense FROM expense WHERE expense_id = 21))";
                        MySqlCommand updateTotalCmd = new MySqlCommand(updateTotalQuery, con);
                        updateTotalCmd.ExecuteNonQuery();
                        dt = new DataTable();
                        adapter = new MySqlDataAdapter("SELECT OrderID, ProductName FROM orders WHERE TableName = 2", con);
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt;
                        dataGridView2.Update();
                        dataGridView2.Refresh();
                        int totalPrice = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["TotalPrice"] != DBNull.Value)
                            {
                                totalPrice += Convert.ToInt32(row["TotalPrice"]);
                            }
                        }
                        lblTotalPrice2.Text = "Sum: " + totalPrice.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tab1.SelectedIndex = 2;
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 3", con);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tab1.SelectedIndex = 3;
            dt = new DataTable();
            con.Open();
            adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 4", con);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Hamburger', 1, 50, 3)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 3", con);
                    adapter.Fill(dt);
                    dataGridView3.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice3.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Pasta', 1, 30, 3)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 3", con);
                    adapter.Fill(dt);
                    dataGridView3.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice3.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Pizza', 1, 45, 3)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 3", con);
                    adapter.Fill(dt);
                    dataGridView3.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice3.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView3.SelectedRows[0].Index;
                int selectedID = Convert.ToInt32(dataGridView3.Rows[selectedIndex].Cells["OrderID"].Value);
                string deleteQuery = "DELETE FROM orders WHERE OrderID = @id";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string selectQuery = "SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 3";
                DataTable dt = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                {
                    adapter.Fill(dt);
                    dataGridView3.DataSource = dt;
                }

                int totalPrice = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TotalPrice"] != DBNull.Value)
                    {
                        totalPrice += Convert.ToInt32(row["TotalPrice"]);
                    }
                }
                lblTotalPrice3.Text = "Sum: " + totalPrice.ToString();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string selectTotalPriceQuery = "SELECT SUM(TotalPrice) AS TotalPriceSum FROM orders WHERE TableName = 3";
                MySqlCommand totalPriceCmd = new MySqlCommand(selectTotalPriceQuery, con);
                object result = totalPriceCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    decimal totalPriceSum = Convert.ToDecimal(result);
                    string updateIncomesQuery = "UPDATE income SET incomes = incomes + @totalPriceSum";
                    MySqlCommand updateIncomesCmd = new MySqlCommand(updateIncomesQuery, con);
                    updateIncomesCmd.Parameters.AddWithValue("@totalPriceSum", totalPriceSum);
                    int affectedRows = updateIncomesCmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        string deleteOrdersQuery = "DELETE FROM orders WHERE TableName = 3";
                        MySqlCommand deleteOrdersCmd = new MySqlCommand(deleteOrdersQuery, con);
                        deleteOrdersCmd.ExecuteNonQuery();
                        string updateTotalQuery = "UPDATE income SET total = (incomes - (SELECT monthly_expense FROM expense WHERE expense_id = 21))";
                        MySqlCommand updateTotalCmd = new MySqlCommand(updateTotalQuery, con);
                        updateTotalCmd.ExecuteNonQuery();
                        dt = new DataTable();
                        adapter = new MySqlDataAdapter("SELECT OrderID, ProductName FROM orders WHERE TableName = 3", con);
                        adapter.Fill(dt);
                        dataGridView3.DataSource = dt;
                        dataGridView3.Update();
                        dataGridView3.Refresh();
                        int totalPrice = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["TotalPrice"] != DBNull.Value)
                            {
                                totalPrice += Convert.ToInt32(row["TotalPrice"]);
                            }
                        }
                        lblTotalPrice3.Text = "Sum: " + totalPrice.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Hamburger', 1, 50, 4)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 4", con);
                    adapter.Fill(dt);
                    dataGridView4.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice4.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Pasta', 1, 30, 4)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 4", con);
                    adapter.Fill(dt);
                    dataGridView4.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice4.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insertQuery = "INSERT INTO orders (ProductName, Quantity, TotalPrice, TableName) VALUES ('Pizza', 1, 45, 4)";

                cmd = new MySqlCommand(insertQuery, con);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    dt = new DataTable();
                    adapter = new MySqlDataAdapter("SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 4", con);
                    adapter.Fill(dt);
                    dataGridView4.DataSource = dt;

                    int totalPrice = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            totalPrice += Convert.ToInt32(row["TotalPrice"]);
                        }
                    }
                    lblTotalPrice4.Text = "Sum: " + totalPrice.ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView4.SelectedRows[0].Index;
                int selectedID = Convert.ToInt32(dataGridView4.Rows[selectedIndex].Cells["OrderID"].Value);
                string deleteQuery = "DELETE FROM orders WHERE OrderID = @id";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string selectQuery = "SELECT OrderID, ProductName, TotalPrice FROM orders WHERE TableName = 4";
                DataTable dt = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, con))
                {
                    adapter.Fill(dt);
                    dataGridView4.DataSource = dt;
                }

                int totalPrice = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TotalPrice"] != DBNull.Value)
                    {
                        totalPrice += Convert.ToInt32(row["TotalPrice"]);
                    }
                }
                lblTotalPrice4.Text = "Sum: " + totalPrice.ToString();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string selectTotalPriceQuery = "SELECT SUM(TotalPrice) AS TotalPriceSum FROM orders WHERE TableName = 4";
                MySqlCommand totalPriceCmd = new MySqlCommand(selectTotalPriceQuery, con);
                object result = totalPriceCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    decimal totalPriceSum = Convert.ToDecimal(result);
                    string updateIncomesQuery = "UPDATE income SET incomes = incomes + @totalPriceSum";
                    MySqlCommand updateIncomesCmd = new MySqlCommand(updateIncomesQuery, con);
                    updateIncomesCmd.Parameters.AddWithValue("@totalPriceSum", totalPriceSum);
                    int affectedRows = updateIncomesCmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        string deleteOrdersQuery = "DELETE FROM orders WHERE TableName = 4";
                        MySqlCommand deleteOrdersCmd = new MySqlCommand(deleteOrdersQuery, con);
                        deleteOrdersCmd.ExecuteNonQuery();
                        string updateTotalQuery = "UPDATE income SET total = (incomes - (SELECT monthly_expense FROM expense WHERE expense_id = 21))";
                        MySqlCommand updateTotalCmd = new MySqlCommand(updateTotalQuery, con);
                        updateTotalCmd.ExecuteNonQuery();
                        dt = new DataTable();
                        adapter = new MySqlDataAdapter("SELECT OrderID, ProductName FROM orders WHERE TableName = 4", con);
                        adapter.Fill(dt);
                        dataGridView4.DataSource = dt;
                        dataGridView4.Update();
                        dataGridView4.Refresh();
                        int totalPrice = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["TotalPrice"] != DBNull.Value)
                            {
                                totalPrice += Convert.ToInt32(row["TotalPrice"]);
                            }
                        }
                        lblTotalPrice4.Text = "Sum: " + totalPrice.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
