namespace BackUpOven
{
    partial class FormConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label5 = new Label();
            btn_Connect = new Button();
            btn_Test = new Button();
            cbb_Database = new ComboBox();
            tb_Password = new TextBox();
            tb_UserId = new TextBox();
            tb_SeverName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(126, 33);
            label5.Name = "label5";
            label5.Size = new Size(235, 37);
            label5.TabIndex = 32;
            label5.Text = "Kết nối SQL Server";
            // 
            // btn_Connect
            // 
            btn_Connect.Enabled = false;
            btn_Connect.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Connect.Location = new Point(346, 369);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(105, 40);
            btn_Connect.TabIndex = 31;
            btn_Connect.Text = "Kết nối";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // btn_Test
            // 
            btn_Test.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Test.Location = new Point(17, 369);
            btn_Test.Name = "btn_Test";
            btn_Test.Size = new Size(105, 40);
            btn_Test.TabIndex = 30;
            btn_Test.Text = "Kiểm Tra";
            btn_Test.UseVisualStyleBackColor = true;
            btn_Test.Click += btn_Test_Click;
            // 
            // cbb_Database
            // 
            cbb_Database.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_Database.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbb_Database.FormattingEnabled = true;
            cbb_Database.Location = new Point(144, 247);
            cbb_Database.Name = "cbb_Database";
            cbb_Database.Size = new Size(307, 33);
            cbb_Database.TabIndex = 29;
            // 
            // tb_Password
            // 
            tb_Password.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_Password.Location = new Point(144, 195);
            tb_Password.Name = "tb_Password";
            tb_Password.PasswordChar = '*';
            tb_Password.Size = new Size(307, 33);
            tb_Password.TabIndex = 28;
            tb_Password.Text = "Daco@2016";
            // 
            // tb_UserId
            // 
            tb_UserId.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_UserId.Location = new Point(144, 147);
            tb_UserId.Name = "tb_UserId";
            tb_UserId.Size = new Size(307, 33);
            tb_UserId.TabIndex = 27;
            tb_UserId.Text = "inoue";
            // 
            // tb_SeverName
            // 
            tb_SeverName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_SeverName.Location = new Point(143, 95);
            tb_SeverName.Name = "tb_SeverName";
            tb_SeverName.Size = new Size(308, 33);
            tb_SeverName.TabIndex = 26;
            tb_SeverName.Text = "14.248.94.171\\SQL2022DEV,59322";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(17, 250);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 25;
            label4.Text = "Database";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(17, 198);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 24;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(17, 150);
            label2.Name = "label2";
            label2.Size = new Size(73, 25);
            label2.TabIndex = 23;
            label2.Text = "User ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(17, 98);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 22;
            label1.Text = "Server Name";
            // 
            // FormConnect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(467, 424);
            Controls.Add(label5);
            Controls.Add(btn_Connect);
            Controls.Add(btn_Test);
            Controls.Add(cbb_Database);
            Controls.Add(tb_Password);
            Controls.Add(tb_UserId);
            Controls.Add(tb_SeverName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormConnect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormConnect";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Button btn_Connect;
        private Button btn_Test;
        private ComboBox cbb_Database;
        private TextBox tb_Password;
        private TextBox tb_UserId;
        private TextBox tb_SeverName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}