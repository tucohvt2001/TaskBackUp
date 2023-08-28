using BackUpOven.Models;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BackUpOven
{
    public partial class Form1 : Form
    {
        private string csSqlite;
        private string csSqlServer;
        private List<string> _listColumnName = new List<string>();
        private List<string> _listUnitNo = new List<string>();
        private List<string> _listUnitNoChecked = new List<string>();
        private List<string> _listColumnNameChecked = new List<string>();
        private SQLServerContext _sqlServerDb;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_InputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "SQLite Database Files (*.db;*.sqlite;*.db3;*.sqlite3)|*.db;*.sqlite;*.db3;*.sqlite3|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                csSqlite = $"Data Source={filePath};Version=3;";

                lbl_dbFrom.Text = filePath;

                btn_ConnectDb.Enabled = true;

                LoadData();
            }
        }

        private void btn_ConnectDb_Click(object sender, EventArgs e)
        {
            FormConnect fConnect = new FormConnect();
            DialogResult result = fConnect.ShowDialog();
            if (result == DialogResult.OK)
            {
                csSqlServer = fConnect.csSqlServer;
                _sqlServerDb = new SQLServerContext(csSqlServer);
                lbl_dbTo.Text = fConnect.dbName;
            }
        }

        private void LoadData()
        {
            _listColumnName.Clear();
            _listUnitNo.Clear();
            clb_Oven.Items.Clear();

            dt_Start.Value = DateTime.Now;
            dt_End.Value = DateTime.Now;
            using (SQLiteConnection connection = new SQLiteConnection(csSqlite))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM DataLogger1";
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        //loại bỏ các dòng null
                        for (int rowIndex = dataTable.Rows.Count - 1; rowIndex >= 0; rowIndex--)
                        {
                            DataRow row = dataTable.Rows[rowIndex];
                            bool hasNullValue = false;

                            foreach (DataColumn column in dataTable.Columns)
                            {
                                if (row[column] == DBNull.Value)
                                {
                                    hasNullValue = true;
                                    break;
                                }
                            }

                            if (hasNullValue)
                            {
                                dataTable.Rows.RemoveAt(rowIndex);
                            }
                        }

                        dgv_Data.DataSource = dataTable;
                    }

                    string queryGetColumns = $"SELECT name FROM pragma_table_info('DataLogger1') WHERE name LIKE 'In_Temp%' OR name LIKE 'Plat_Temp%'";

                    using (SQLiteDataAdapter adapterGetColumns = new SQLiteDataAdapter(queryGetColumns, connection))
                    {
                        DataTable columnTable = new DataTable();

                        adapterGetColumns.Fill(columnTable);

                        foreach (DataRow row in columnTable.Rows)
                        {
                            _listColumnName.Add(row["name"].ToString());
                        }

                        foreach (string columnName in _listColumnName)
                        {
                            var replaceOvenNumber = columnName.Replace("In_Temp", "").Replace("Plat_Temp", "");
                            if (int.TryParse(replaceOvenNumber, out int number))
                            {
                                if (number < 10)
                                {
                                    replaceOvenNumber = $"00{number}";
                                }
                                else if (number < 100 && number > 10)
                                {
                                    replaceOvenNumber = $"0{number}";
                                }
                            }

                            var unitNo = $"{"OVEN"}{replaceOvenNumber}";
                            if (!_listUnitNo.Contains(unitNo))
                            {
                                _listUnitNo.Add(unitNo);
                                clb_Oven.Items.Add(unitNo);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            DateTime startTime = dt_Start.Value;
            DateTime endTime = dt_End.Value;

            int result = DateTime.Compare(startTime, endTime);

            if (csSqlite == null)
            {
                MessageBox.Show("Vui lòng import file!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (result > 0)
            {
                MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc!", "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (clb_Oven.CheckedItems.Count == 0)
            {
                using (SQLiteConnection connection = new SQLiteConnection(csSqlite))
                {
                    try
                    {
                        connection.Open();

                        string query = $"SELECT * FROM DataLogger1 " +
                        $"WHERE Time BETWEEN '{startTime:yyyy-MM-dd HH:mm:ss.fff}' AND '{endTime:yyyy-MM-dd HH:mm:ss.fff} '";
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            for (int rowIndex = dataTable.Rows.Count - 1; rowIndex >= 0; rowIndex--)
                            {
                                DataRow row = dataTable.Rows[rowIndex];
                                bool hasNullValue = false;

                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    if (row[column] == DBNull.Value)
                                    {
                                        hasNullValue = true;
                                        break;
                                    }
                                }

                                if (hasNullValue)
                                {
                                    dataTable.Rows.RemoveAt(rowIndex);
                                }
                            }
                            dgv_Data.DataSource = dataTable;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else
            {
                if (csSqlServer != null)
                {
                    btn_Backup.Enabled = true;
                }
                _listColumnName.Clear();
                _listColumnNameChecked.Clear();
                _listUnitNoChecked.Clear();
                //lấy ds UnitNo được chọn
                foreach (var unitnoChecked in clb_Oven.CheckedItems)
                {
                    _listUnitNoChecked.Add(unitnoChecked.ToString());
                }

                foreach (var ovenChecked in _listUnitNoChecked)
                {
                    //tách lấy số lò từ UnitNo được chọn
                    if (ovenChecked.ToString().StartsWith("OVEN") && ovenChecked.ToString().Length > 4 &&
                        int.TryParse(ovenChecked.ToString().Substring(4), out int number))
                    {
                        string columnIn = "In_Temp" + number;
                        string columnPlat = "Plat_Temp" + number;

                        _listColumnNameChecked.Add(columnIn);
                        _listColumnNameChecked.Add(columnPlat);
                    }
                }

                using (SQLiteConnection connection = new SQLiteConnection(csSqlite))
                {
                    connection.Open();

                    string selectedColumns = string.Join(", ", _listColumnNameChecked);

                    string query = $"SELECT Id, Time, {selectedColumns} FROM DataLogger1 " +
                        $"WHERE Time BETWEEN '{startTime:yyyy-MM-dd HH:mm:ss.fff}' AND '{endTime:yyyy-MM-dd HH:mm:ss.fff}'";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Clear();
                        adapter.Fill(dataTable);
                        for (int rowIndex = dataTable.Rows.Count - 1; rowIndex >= 0; rowIndex--)
                        {
                            DataRow row = dataTable.Rows[rowIndex];
                            bool hasNullValue = false;

                            foreach (DataColumn column in dataTable.Columns)
                            {
                                if (row[column] == DBNull.Value)
                                {
                                    hasNullValue = true;
                                    break;
                                }
                            }

                            if (hasNullValue)
                            {
                                dataTable.Rows.RemoveAt(rowIndex);
                            }
                        }
                        dgv_Data.DataSource = dataTable;
                    }
                }
            }
        }
        private int? GetOvenIdFromUnitNo(string unitNo)
        {
            try
            {
                var oven = (from o in _sqlServerDb.Ovens
                            where o.UnitNo == unitNo
                            select o).FirstOrDefault();
                if (oven != null)
                {
                    return oven.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormConnect form = new FormConnect();
                form.ShowDialog();

            }
            return null;
        }

        private void processBackup()
        {
            List<Thistory> backupData = new List<Thistory>();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dgv_Data.Rows.Count;
            progressBar1.Value = 0;

            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                DateTime time = Convert.ToDateTime(row.Cells["Time"].Value);

                foreach (var unitNo in _listUnitNoChecked)
                {
                    int ovenId = GetOvenIdFromUnitNo(unitNo).GetValueOrDefault();

                    if (unitNo.ToString().StartsWith("OVEN") && unitNo.ToString().Length > 4 &&
                        int.TryParse(unitNo.ToString().Substring(4), out int number))
                    {
                        //lấy tên cột tách từ UnitNo của các máy được chọn
                        string inColumnName = "In_Temp" + number;
                        string platColumnName = "Plat_Temp" + number;

                        if (row.Cells[inColumnName].Value != null || row.Cells[platColumnName].Value != null)
                        {
                            float inTemp = (float)Convert.ToDouble(row.Cells[inColumnName].Value);
                            float platTemp = (float)Convert.ToDouble(row.Cells[platColumnName].Value);

                            // Check bản ghi trùng
                            bool isExisting = (from data in _sqlServerDb.Thistory
                                               where data.Time == time && data.OvenId == ovenId
                                               select data).Any();

                            if (inTemp != 0.0f || platTemp != 0.0f)
                            {
                                if (!isExisting)
                                {
                                    backupData.Add(new Thistory
                                    {
                                        Time = time,
                                        OvenId = ovenId,
                                        InTemp = inTemp,
                                        PlatTemp = platTemp
                                    });
                                }
                            }
                        }
                    }
                }
                //cộng value mỗi khi thêm mới 1 bản ghi
                progressBar1.Value++;
                progressBar1.Visible = true;
                lbl_Loading.Visible = true;
                //lấy value chia tổng số  bản ghi
                int loading = (int)((double)progressBar1.Value / progressBar1.Maximum * 100);
                lbl_Loading.Text = "Loading: " + loading.ToString() + "%";
                Application.DoEvents();
            }

            _sqlServerDb.Thistory.AddRange(backupData); // Thêm ds backupdata vào Thistory
            _sqlServerDb.SaveChanges(); // Lưu dữ liệu vào cơ sở dữ liệu
            MessageBox.Show("Hoàn thành sao lưu!");
            lbl_Loading.Visible = false;
            progressBar1.Visible = false;
            btn_Backup.Enabled = false;
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            if (clb_Oven.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vì lượng data quá lớn, vui lòng chọn những máy cần backup !");
            }
            var rss = MessageBox.Show("Bạn có muốn backup data trên?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rss == DialogResult.OK)
            {
                processBackup();
            }
        }

        private void cb_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_SelectAll.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < clb_Oven.Items.Count; i++)
                {
                    clb_Oven.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < clb_Oven.Items.Count; i++)
                {
                    clb_Oven.SetItemChecked(i, false);
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}