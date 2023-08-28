namespace BackUpOven
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dt_Start = new DateTimePicker();
            btn_ConnectDb = new Button();
            label7 = new Label();
            btn_Exit = new Button();
            lbl_Loading = new Label();
            progressBar1 = new ProgressBar();
            lbl_dbTo = new Label();
            clb_Oven = new CheckedListBox();
            lbl_dbFrom = new Label();
            label6 = new Label();
            btn_InputFile = new Button();
            cb_SelectAll = new CheckBox();
            btn_Filter = new Button();
            label3 = new Label();
            label2 = new Label();
            dt_End = new DateTimePicker();
            btn_Backup = new Button();
            label5 = new Label();
            label4 = new Label();
            btn_Refresh = new Button();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            dgv_Data = new DataGridView();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Data).BeginInit();
            SuspendLayout();
            // 
            // dt_Start
            // 
            dt_Start.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dt_Start.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dt_Start.Format = DateTimePickerFormat.Custom;
            dt_Start.Location = new Point(125, 44);
            dt_Start.Name = "dt_Start";
            dt_Start.Size = new Size(214, 33);
            dt_Start.TabIndex = 1;
            // 
            // btn_ConnectDb
            // 
            btn_ConnectDb.Enabled = false;
            btn_ConnectDb.Image = (Image)resources.GetObject("btn_ConnectDb.Image");
            btn_ConnectDb.ImageAlign = ContentAlignment.MiddleLeft;
            btn_ConnectDb.Location = new Point(450, 45);
            btn_ConnectDb.Name = "btn_ConnectDb";
            btn_ConnectDb.Size = new Size(178, 35);
            btn_ConnectDb.TabIndex = 21;
            btn_ConnectDb.Text = "Chọn DataBase";
            btn_ConnectDb.TextAlign = ContentAlignment.MiddleRight;
            btn_ConnectDb.UseVisualStyleBackColor = true;
            btn_ConnectDb.Click += btn_ConnectDb_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(353, 50);
            label7.Name = "label7";
            label7.Size = new Size(91, 25);
            label7.TabIndex = 20;
            label7.Text = "File đích: ";
            // 
            // btn_Exit
            // 
            btn_Exit.Image = (Image)resources.GetObject("btn_Exit.Image");
            btn_Exit.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Exit.Location = new Point(525, 238);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(103, 35);
            btn_Exit.TabIndex = 19;
            btn_Exit.Text = "Thoát";
            btn_Exit.TextAlign = ContentAlignment.MiddleRight;
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // lbl_Loading
            // 
            lbl_Loading.AutoSize = true;
            lbl_Loading.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Loading.Location = new Point(267, 154);
            lbl_Loading.Name = "lbl_Loading";
            lbl_Loading.Size = new Size(135, 25);
            lbl_Loading.TabIndex = 18;
            lbl_Loading.Text = "Loading: 100%";
            lbl_Loading.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(28, 182);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(600, 41);
            progressBar1.TabIndex = 17;
            // 
            // lbl_dbTo
            // 
            lbl_dbTo.AutoSize = true;
            lbl_dbTo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_dbTo.Location = new Point(82, 121);
            lbl_dbTo.Name = "lbl_dbTo";
            lbl_dbTo.Size = new Size(0, 25);
            lbl_dbTo.TabIndex = 15;
            // 
            // clb_Oven
            // 
            clb_Oven.FormattingEnabled = true;
            clb_Oven.Location = new Point(125, 107);
            clb_Oven.Name = "clb_Oven";
            clb_Oven.Size = new Size(495, 116);
            clb_Oven.TabIndex = 4;
            // 
            // lbl_dbFrom
            // 
            lbl_dbFrom.AutoSize = true;
            lbl_dbFrom.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_dbFrom.Location = new Point(82, 86);
            lbl_dbFrom.Name = "lbl_dbFrom";
            lbl_dbFrom.Size = new Size(0, 25);
            lbl_dbFrom.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(28, 50);
            label6.Name = "label6";
            label6.Size = new Size(116, 25);
            label6.TabIndex = 0;
            label6.Text = "File backup: ";
            // 
            // btn_InputFile
            // 
            btn_InputFile.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btn_InputFile.Image = (Image)resources.GetObject("btn_InputFile.Image");
            btn_InputFile.ImageAlign = ContentAlignment.MiddleLeft;
            btn_InputFile.Location = new Point(155, 45);
            btn_InputFile.Name = "btn_InputFile";
            btn_InputFile.Size = new Size(135, 35);
            btn_InputFile.TabIndex = 10;
            btn_InputFile.Text = "Chọn tệp";
            btn_InputFile.TextAlign = ContentAlignment.MiddleRight;
            btn_InputFile.UseVisualStyleBackColor = true;
            btn_InputFile.Click += btn_InputFile_Click;
            // 
            // cb_SelectAll
            // 
            cb_SelectAll.AutoSize = true;
            cb_SelectAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cb_SelectAll.Location = new Point(125, 226);
            cb_SelectAll.Name = "cb_SelectAll";
            cb_SelectAll.Size = new Size(69, 25);
            cb_SelectAll.TabIndex = 9;
            cb_SelectAll.Text = "Tất cả";
            cb_SelectAll.UseVisualStyleBackColor = true;
            cb_SelectAll.CheckedChanged += cb_SelectAll_CheckedChanged;
            // 
            // btn_Filter
            // 
            btn_Filter.Image = (Image)resources.GetObject("btn_Filter.Image");
            btn_Filter.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Filter.Location = new Point(514, 238);
            btn_Filter.Name = "btn_Filter";
            btn_Filter.Size = new Size(106, 35);
            btn_Filter.TabIndex = 6;
            btn_Filter.Text = "Bộ Lọc";
            btn_Filter.TextAlign = ContentAlignment.MiddleRight;
            btn_Filter.UseVisualStyleBackColor = true;
            btn_Filter.Click += btn_Filter_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 154);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 5;
            label3.Text = "Chọn lò";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(361, 45);
            label2.Name = "label2";
            label2.Size = new Size(28, 25);
            label2.TabIndex = 3;
            label2.Text = "--";
            // 
            // dt_End
            // 
            dt_End.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dt_End.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dt_End.Format = DateTimePickerFormat.Custom;
            dt_End.Location = new Point(406, 44);
            dt_End.Name = "dt_End";
            dt_End.Size = new Size(214, 33);
            dt_End.TabIndex = 2;
            // 
            // btn_Backup
            // 
            btn_Backup.Enabled = false;
            btn_Backup.Image = (Image)resources.GetObject("btn_Backup.Image");
            btn_Backup.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Backup.Location = new Point(251, 238);
            btn_Backup.Name = "btn_Backup";
            btn_Backup.Size = new Size(111, 35);
            btn_Backup.TabIndex = 14;
            btn_Backup.Text = "Sao Lưu";
            btn_Backup.TextAlign = ContentAlignment.MiddleRight;
            btn_Backup.UseVisualStyleBackColor = true;
            btn_Backup.Click += btn_Backup_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(28, 121);
            label5.Name = "label5";
            label5.Size = new Size(60, 25);
            label5.TabIndex = 13;
            label5.Text = "Đến : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(28, 86);
            label4.Name = "label4";
            label4.Size = new Size(37, 25);
            label4.TabIndex = 12;
            label4.Text = "Từ:";
            // 
            // btn_Refresh
            // 
            btn_Refresh.Enabled = false;
            btn_Refresh.Image = (Image)resources.GetObject("btn_Refresh.Image");
            btn_Refresh.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Refresh.Location = new Point(395, 238);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(106, 35);
            btn_Refresh.TabIndex = 7;
            btn_Refresh.Text = "Tải Lại";
            btn_Refresh.TextAlign = ContentAlignment.MiddleRight;
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_ConnectDb);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btn_Exit);
            groupBox2.Controls.Add(lbl_Loading);
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Controls.Add(lbl_dbFrom);
            groupBox2.Controls.Add(lbl_dbTo);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btn_InputFile);
            groupBox2.Controls.Add(btn_Backup);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btn_Refresh);
            groupBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(860, 522);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(634, 279);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Khu vực BackUp";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cb_SelectAll);
            groupBox1.Controls.Add(btn_Filter);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(clb_Oven);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dt_End);
            groupBox1.Controls.Add(dt_Start);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 522);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(653, 279);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức Năng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 50);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 0;
            label1.Text = "Thời gian";
            // 
            // dgv_Data
            // 
            dgv_Data.BackgroundColor = SystemColors.ControlLightLight;
            dgv_Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Data.Location = new Point(12, 12);
            dgv_Data.Name = "dgv_Data";
            dgv_Data.RowTemplate.Height = 25;
            dgv_Data.Size = new Size(1482, 501);
            dgv_Data.TabIndex = 19;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 807);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgv_Data);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Data).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dt_Start;
        private Button btn_ConnectDb;
        private Label label7;
        private Button btn_Exit;
        private Label lbl_Loading;
        private ProgressBar progressBar1;
        private Label lbl_dbTo;
        private CheckedListBox clb_Oven;
        private Label lbl_dbFrom;
        private Label label6;
        private Button btn_InputFile;
        private CheckBox cb_SelectAll;
        private Button btn_Filter;
        private Label label3;
        private Label label2;
        private DateTimePicker dt_End;
        private Button btn_Backup;
        private Label label5;
        private Label label4;
        private Button btn_Refresh;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label1;
        private DataGridView dgv_Data;
    }
}