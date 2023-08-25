using backup.Models;
using DemoWithEF.Models;
using SQLitePCL;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace backup
{
    public partial class Form1 : Form
    {
        private SQLiteContext _sqliteDb;
        private SQLServerContext _sqlServerDb;
        private List<string> _ovenCheckedList = new List<string>();//ds các cột trong db tương ứng với số lò được chọn
        private List<string> _unitNoList = new List<string>();//ds tất cả các unitNo của lò
        private List<string> _unitNoChecked = new List<string>();//ds tất cả các unitNo của lò được chọn
        private string csSqlite;
        private string csSqlserver;
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
                lbl_dbFrom.Text = filePath;
                csSqlite = $"Data Source={filePath};";
                _sqliteDb = new SQLiteContext(csSqlite);
                btn_Refresh.Enabled = true;
                btn_ConnectDb.Enabled = true;
                btn_Filter.Enabled = true;
                LoadData();
            }
        }

        private void btn_ConnectDb_Click(object sender, EventArgs e)
        {
            FormConnect fConnect = new FormConnect();
            DialogResult result = fConnect.ShowDialog();
            if (result == DialogResult.OK)
            {
                csSqlserver = fConnect.csSqlServer;
                _sqlServerDb = new SQLServerContext(csSqlserver);
                lbl_dbTo.Text = fConnect.dbName;
                if (csSqlite != null)
                {
                    btn_Copy.Enabled = true;
                }
            }
        }

        private void LoadData()
        {
            dgv_Data.DataSource = null;
            for (int i = 0; i < clb_Oven.Items.Count; i++)
            {
                clb_Oven.SetItemChecked(i, false);
            }
            cb_SelectAll.Checked = false;

            try
            {
                var query = (from data in _sqliteDb.DataLogger1
                             where data.In_Temp1 != null && data.Plat_Temp1 != null &&
                             data.In_Temp35 != null && data.Plat_Temp35 != null &&
                             data.In_Temp36 != null && data.Plat_Temp36 != null &&
                             data.In_Temp40 != null && data.Plat_Temp40 != null &&
                             data.In_Temp41 != null && data.Plat_Temp41 != null &&
                             data.In_Temp42 != null && data.Plat_Temp42 != null &&
                             data.In_Temp43 != null && data.Plat_Temp43 != null &&
                             data.In_Temp44 != null && data.Plat_Temp44 != null &&
                             data.In_Temp49 != null && data.Plat_Temp49 != null &&
                             data.In_Temp50 != null && data.Plat_Temp50 != null &&
                             data.In_Temp51 != null && data.Plat_Temp51 != null &&
                             data.In_Temp52 != null && data.Plat_Temp52 != null &&
                             data.In_Temp53 != null && data.Plat_Temp53 != null &&
                             data.In_Temp54 != null && data.Plat_Temp54 != null &&
                             data.In_Temp55 != null && data.Plat_Temp55 != null &&
                             data.In_Temp56 != null && data.Plat_Temp56 != null
                             select data).ToList();
                dgv_Data.DataSource = query;
                btn_InputFile.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Vui lòng chọn lại file !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var propertyNames = from prop in typeof(DataLogger1).GetProperties()
                                where prop.Name.StartsWith("In") || prop.Name.StartsWith("Plat")
                                select prop.Name;

            foreach (var propertyname in propertyNames)
            {
                var replaceOvenNumber = propertyname.Replace("In_Temp", "").Replace("Plat_Temp", "");
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
                if (!_unitNoList.Contains(unitNo))
                {
                    _unitNoList.Add(unitNo);
                    clb_Oven.Items.Add(unitNo);
                }
            }

            dgv_Data.Columns["Time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss.fff";
            dt_Start.Value = DateTime.Now;
            dt_End.Value = DateTime.Now;
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            if (dt_Start.Value < dt_End.Value)
            {

                if (clb_Oven.CheckedItems.Count == 0)
                {
                    var query = from data in _sqliteDb.DataLogger1
                                where data.Time >= dt_Start.Value && data.Time <= dt_End.Value &&
                            data.In_Temp1 != null && data.Plat_Temp1 != null &&
                            data.In_Temp35 != null && data.Plat_Temp35 != null &&
                            data.In_Temp36 != null && data.Plat_Temp36 != null &&
                            data.In_Temp40 != null && data.Plat_Temp40 != null &&
                            data.In_Temp41 != null && data.Plat_Temp41 != null &&
                            data.In_Temp42 != null && data.Plat_Temp42 != null &&
                            data.In_Temp43 != null && data.Plat_Temp43 != null &&
                            data.In_Temp44 != null && data.Plat_Temp44 != null &&
                            data.In_Temp49 != null && data.Plat_Temp49 != null &&
                            data.In_Temp50 != null && data.Plat_Temp50 != null &&
                            data.In_Temp51 != null && data.Plat_Temp51 != null &&
                            data.In_Temp52 != null && data.Plat_Temp52 != null &&
                            data.In_Temp53 != null && data.Plat_Temp53 != null &&
                            data.In_Temp54 != null && data.Plat_Temp54 != null &&
                            data.In_Temp55 != null && data.Plat_Temp55 != null &&
                            data.In_Temp56 != null && data.Plat_Temp56 != null
                                select data;//query
                    if (query.ToList().Count == 0)
                    {
                        MessageBox.Show("Không tồn tại bản ghi phù hợp");
                    }
                    else
                    {
                        dgv_Data.DataSource = query.ToList();
                    }

                }
                else
                {
                    _unitNoChecked.Clear();
                    //lấy ds UnitNo được chọn
                    foreach (var unitnoChecked in clb_Oven.CheckedItems)
                    {
                        _unitNoChecked.Add(unitnoChecked.ToString());
                    }

                    foreach (var ovenChecked in _unitNoChecked)
                    {
                        //tách lấy số lò từ UnitNo được chọn
                        if (ovenChecked.ToString().StartsWith("OVEN") && ovenChecked.ToString().Length > 4 &&
                            int.TryParse(ovenChecked.ToString().Substring(4), out int number))
                        {
                            string columnIn = "In_Temp" + number;
                            string columnPlat = "Plat_Temp" + number;

                            _ovenCheckedList.Add(columnIn);
                            _ovenCheckedList.Add(columnPlat);
                        }
                    }

                    var getalldata = (from data in _sqliteDb.DataLogger1
                                      where data.Time >= dt_Start.Value && data.Time <= dt_End.Value &&
                                  data.In_Temp1 != null && data.Plat_Temp1 != null &&
                                  data.In_Temp35 != null && data.Plat_Temp35 != null &&
                                  data.In_Temp36 != null && data.Plat_Temp36 != null &&
                                  data.In_Temp40 != null && data.Plat_Temp40 != null &&
                                  data.In_Temp41 != null && data.Plat_Temp41 != null &&
                                  data.In_Temp42 != null && data.Plat_Temp42 != null &&
                                  data.In_Temp43 != null && data.Plat_Temp43 != null &&
                                  data.In_Temp44 != null && data.Plat_Temp44 != null &&
                                  data.In_Temp49 != null && data.Plat_Temp49 != null &&
                                  data.In_Temp50 != null && data.Plat_Temp50 != null &&
                                  data.In_Temp51 != null && data.Plat_Temp51 != null &&
                                  data.In_Temp52 != null && data.Plat_Temp52 != null &&
                                  data.In_Temp53 != null && data.Plat_Temp53 != null &&
                                  data.In_Temp54 != null && data.Plat_Temp54 != null &&
                                  data.In_Temp55 != null && data.Plat_Temp55 != null &&
                                  data.In_Temp56 != null && data.Plat_Temp56 != null
                                      select data).ToList();//query

                    DataTable dataTableChecked = new DataTable();

                    dataTableChecked.Columns.Add("Id", typeof(int));
                    dataTableChecked.Columns.Add("Time", typeof(DateTime));
                    //thêm các cột trong ds lò được chọn vào datatable
                    foreach (var columnName in _ovenCheckedList)
                    {
                        if (!dataTableChecked.Columns.Contains(columnName))
                        {
                            dataTableChecked.Columns.Add(columnName);
                        }
                    }
                    foreach (var record in getalldata)
                    {
                        var row = dataTableChecked.NewRow();
                        row["Id"] = record.Id;
                        row["Time"] = record.Time;

                        //duyệt từ ds các cột được chọn VD: In_Temp1,Plat_Temp1....
                        foreach (var columnName in _ovenCheckedList)
                        {
                            var propertyInfo = record.GetType().GetProperty(columnName);
                            if (propertyInfo != null)
                            {
                                var propertyValue = propertyInfo.GetValue(record);
                                row[columnName] = propertyValue;
                            }
                        }

                        dataTableChecked.Rows.Add(row);
                    }

                    if (dataTableChecked.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại bản ghi nào!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dgv_Data.DataSource = dataTableChecked;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn lại mốc thời gian!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BackupData()
        {
            List<Thistory> backupData = new List<Thistory>();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dgv_Data.Rows.Count;
            progressBar1.Value = 0;

            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                DateTime time = Convert.ToDateTime(row.Cells["Time"].Value);

                foreach (var unitNo in _unitNoChecked)
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
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có muốn back up data?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                BackupData();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_SelectAll_Click(object sender, EventArgs e)
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
    }
}