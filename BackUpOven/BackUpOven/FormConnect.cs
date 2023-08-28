using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackUpOven
{
    public partial class FormConnect : Form
    {
        public string csSqlServer { get; private set; }
        public string dbName { get; private set; }
        public FormConnect()
        {
            InitializeComponent();
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = tb_SeverName.Text;

            if (!string.IsNullOrWhiteSpace(tb_UserId.Text))
            {
                builder.UserID = tb_UserId.Text;
                builder.Password = tb_Password.Text;
            }

            string connectionString = builder.ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cbb_Database.Items.Clear();

                    while (reader.Read())
                    {
                        cbb_Database.Items.Add(reader[0]);
                    }

                    reader.Close();
                    btn_Connect.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối hoặc truy vấn: " + ex.Message);
                }
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            csSqlServer = "Data Source=" + tb_SeverName.Text + "; Initial Catalog=" + cbb_Database.Text + "; User ID=" + tb_UserId.Text + "; Password=" + tb_Password.Text + ";";
            dbName = cbb_Database.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
