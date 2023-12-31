﻿using BackUpOven.Models;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BackUpOven
{
    public partial class Form1 : Form
    {
        private string csSqlite;
        private string csSqlServer;
        private SQLServerContext _sqlServerDb;
        private List<string> _listColumnName = new List<string>();
        private List<string> _listUnitNo = new List<string>();
        private List<string> _listUnitNoChecked = new List<string>();
        private List<string> _listColumnNameChecked = new List<string>();

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
            btn_Backup.Enabled = false;

            _listColumnName.Clear();
            _listColumnNameChecked.Clear();
            _listUnitNo.Clear();
            clb_Oven.Items.Clear();

            m_prefix = string.Empty;

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
                        btn_Refresh.Enabled = true;
                        dgv_Data.DataSource = dataTable;
                    }

                    string queryGetColumns = $"SELECT name FROM pragma_table_info('DataLogger1') WHERE name LIKE '%In_Temp%' OR name LIKE '%Plat_Temp%'";

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
                            if (columnName.StartsWith("Log") && string.IsNullOrEmpty(m_prefix))
                                m_prefix = "Log_";

                            var replaceOvenNumber = columnName.Replace("Log_In_Temp", "").Replace("Log_Plat_Temp", "").Replace("In_Temp", "").Replace("Plat_Temp", "");
                            if (int.TryParse(replaceOvenNumber, out int number))
                            {
                                if (number < 10)
                                {
                                    replaceOvenNumber = $"00{number}";
                                }
                                else if (number < 100 && number >= 10)
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

        string m_prefix = string.Empty;

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
                            for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
                            {
                                for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; columnIndex++)
                                {
                                    if (dataTable.Rows[rowIndex][columnIndex] == DBNull.Value)
                                    {
                                        dataTable.Rows[rowIndex][columnIndex] = 0;
                                    }
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
                        string columnIn = string.IsNullOrEmpty(m_prefix) ? "In_Temp" + number : m_prefix + "In_Temp" + number;
                        string columnPlat = string.IsNullOrEmpty(m_prefix) ? "Plat_Temp" + number : m_prefix + "Plat_Temp" + number;

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
                        for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
                        {
                            for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; columnIndex++)
                            {
                                if (dataTable.Rows[rowIndex][columnIndex] == DBNull.Value)
                                {
                                    dataTable.Rows[rowIndex][columnIndex] = 0;
                                }
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
            DateTime startTime = dt_Start.Value;
            DateTime endTime = dt_End.Value;

            List<Thistory> backupData = new List<Thistory>();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dgv_Data.Rows.Count;
            progressBar1.Value = 0;


            List<string> _listOvennumSelected = new List<string>();

            _listOvennumSelected.Clear();

            foreach (var unitNo in _listUnitNoChecked)
            {
                int ovenId = GetOvenIdFromUnitNo(unitNo).GetValueOrDefault();
                _listOvennumSelected.Add(ovenId.ToString());

                var dataToDelete = from data in _sqlServerDb.Thistory
                                   where data.Time >= startTime && data.Time <= endTime &&
                                         data.OvenId == ovenId
                                   select data;

                _sqlServerDb.Thistory.RemoveRange(dataToDelete);
            }

            _sqlServerDb.SaveChanges();
            progressBar1.Visible = true;

            try
            {
                int batchSize = 5000; // Số lượng bản ghi mỗi lần lưu
                int recordCount = 0; // Biến đếm số lượng bản ghi đã xử lý

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
                            string inColumnName = string.IsNullOrEmpty(m_prefix) ? "In_Temp" + number : m_prefix + "In_Temp" + number;
                            string platColumnName = string.IsNullOrEmpty(m_prefix) ? "Plat_Temp" + number : m_prefix + "Plat_Temp" + number;

                            //string inColumnName = "In_Temp" + number;
                            //string platColumnName = "Plat_Temp" + number;

                            if (row.Cells[inColumnName].Value != null || row.Cells[platColumnName].Value != null)
                            {
                                float inTemp = (float)Convert.ToDouble(row.Cells[inColumnName].Value);
                                float platTemp = (float)Convert.ToDouble(row.Cells[platColumnName].Value);

                                if (inTemp != 0.0f || platTemp != 0.0f)
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
                    // Tăng biến đếm bản ghi đã xử lý
                    recordCount++;

                    // Kiểm tra xem đã đạt đủ số lượng bản ghi để lưu
                    if (recordCount >= batchSize)
                    {
                        _sqlServerDb.Thistory.AddRange(backupData); // Thêm ds backupdata vào Thistory
                        _sqlServerDb.SaveChanges(); // Lưu dữ liệu vào cơ sở dữ liệu
                        backupData.Clear(); // Xóa dữ liệu đã sao lưu
                        recordCount = 0; // Đặt lại biến đếm
                    }

                    // Cập nhật thanh tiến trình và hiển thị thông tin
                    progressBar1.Value++;
                    progressBar1.Visible = true;
                    lbl_Loading.Visible = true;
                    int loading = (int)((double)progressBar1.Value / progressBar1.Maximum * 100);
                    lbl_Loading.Text = "Loading: " + loading.ToString() + "%";
                    Application.DoEvents();
                }

                // Lưu các bản ghi còn lại (nếu còn)
                if (backupData.Count > 0)
                {
                    _sqlServerDb.Thistory.AddRange(backupData);
                    _sqlServerDb.SaveChanges();
                }

                MessageBox.Show("Hoàn thành sao lưu!");
                lbl_Loading.Visible = false;
                progressBar1.Visible = false;
                btn_Backup.Enabled = false;

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message);
                else
                    MessageBox.Show(ex.Message);
            }

        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            if (!DataGridViewHasValues(dgv_Data))
            {
                MessageBox.Show("Không có giá trị trong DataGridView để backup.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Không thực hiện backup nếu DataGridView trống
            }

            var rs = MessageBox.Show("Hành động này sẽ xóa data trong khoảng thời gian đã chọn để backup. Bạn có muốn tiếp tục ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                processBackup();
            }
        }

        private bool DataGridViewHasValues(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        return true; // Có giá trị, không trống
                    }
                }
            }
            return false; // Không có giá trị
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
            var rs = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
