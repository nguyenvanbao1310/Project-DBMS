namespace FormQLMayTinh
{
    partial class FDanhThu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTongTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNam = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpThang = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.rdbNam = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdbThang = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdbNgay = new Guna.UI2.WinForms.Guna2RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDoanhThu = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.Transparent;
            this.txtTongTien.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTongTien.BorderRadius = 10;
            this.txtTongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongTien.DefaultText = "";
            this.txtTongTien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTongTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTongTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongTien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongTien.FillColor = System.Drawing.SystemColors.Control;
            this.txtTongTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongTien.Location = new System.Drawing.Point(698, 475);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.PasswordChar = '\0';
            this.txtTongTien.PlaceholderText = "";
            this.txtTongTien.SelectedText = "";
            this.txtTongTien.Size = new System.Drawing.Size(254, 47);
            this.txtTongTien.TabIndex = 20;
            // 
            // dtpNam
            // 
            this.dtpNam.Checked = true;
            this.dtpNam.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpNam.CustomFormat = "yyyy";
            this.dtpNam.FillColor = System.Drawing.Color.White;
            this.dtpNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNam.Location = new System.Drawing.Point(12, 343);
            this.dtpNam.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNam.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNam.Name = "dtpNam";
            this.dtpNam.ShowUpDown = true;
            this.dtpNam.Size = new System.Drawing.Size(152, 36);
            this.dtpNam.TabIndex = 19;
            this.dtpNam.Value = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            this.dtpNam.ValueChanged += new System.EventHandler(this.dtpNam_ValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(548, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 39);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tổng thu:";
            // 
            // dtpThang
            // 
            this.dtpThang.Checked = true;
            this.dtpThang.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.FillColor = System.Drawing.Color.White;
            this.dtpThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(12, 248);
            this.dtpThang.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpThang.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.ShowUpDown = true;
            this.dtpThang.Size = new System.Drawing.Size(152, 36);
            this.dtpThang.TabIndex = 17;
            this.dtpThang.Value = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            this.dtpThang.ValueChanged += new System.EventHandler(this.dtpThang_ValueChanged);
            // 
            // dtpNgay
            // 
            this.dtpNgay.Checked = true;
            this.dtpNgay.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpNgay.FillColor = System.Drawing.Color.White;
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(12, 148);
            this.dtpNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(152, 36);
            this.dtpNgay.TabIndex = 16;
            this.dtpNgay.Value = new System.DateTime(2024, 11, 11, 17, 7, 9, 272);
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbNam.CheckedState.BorderThickness = 0;
            this.rdbNam.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbNam.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbNam.CheckedState.InnerOffset = -4;
            this.rdbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNam.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdbNam.Location = new System.Drawing.Point(17, 302);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Size = new System.Drawing.Size(97, 20);
            this.rdbNam.TabIndex = 15;
            this.rdbNam.Text = "Theo năm";
            this.rdbNam.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbNam.UncheckedState.BorderThickness = 2;
            this.rdbNam.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbNam.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbNam.CheckedChanged += new System.EventHandler(this.rdbNgay_CheckedChanged);
            // 
            // rdbThang
            // 
            this.rdbThang.AutoSize = true;
            this.rdbThang.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbThang.CheckedState.BorderThickness = 0;
            this.rdbThang.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbThang.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbThang.CheckedState.InnerOffset = -4;
            this.rdbThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbThang.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdbThang.Location = new System.Drawing.Point(17, 207);
            this.rdbThang.Name = "rdbThang";
            this.rdbThang.Size = new System.Drawing.Size(106, 20);
            this.rdbThang.TabIndex = 14;
            this.rdbThang.Text = "Theo tháng";
            this.rdbThang.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbThang.UncheckedState.BorderThickness = 2;
            this.rdbThang.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbThang.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbThang.CheckedChanged += new System.EventHandler(this.rdbNgay_CheckedChanged);
            // 
            // rdbNgay
            // 
            this.rdbNgay.AutoSize = true;
            this.rdbNgay.Checked = true;
            this.rdbNgay.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbNgay.CheckedState.BorderThickness = 0;
            this.rdbNgay.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbNgay.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbNgay.CheckedState.InnerOffset = -4;
            this.rdbNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNgay.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdbNgay.Location = new System.Drawing.Point(17, 113);
            this.rdbNgay.Name = "rdbNgay";
            this.rdbNgay.Size = new System.Drawing.Size(102, 20);
            this.rdbNgay.TabIndex = 13;
            this.rdbNgay.TabStop = true;
            this.rdbNgay.Text = "Theo ngày";
            this.rdbNgay.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbNgay.UncheckedState.BorderThickness = 2;
            this.rdbNgay.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbNgay.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbNgay.CheckedChanged += new System.EventHandler(this.rdbNgay_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 39);
            this.label1.TabIndex = 12;
            this.label1.Text = "THỜI GIAN";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AllowUserToResizeColumns = false;
            this.dgvDoanhThu.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvDoanhThu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDoanhThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDoanhThu.ColumnHeadersHeight = 40;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDoanhThu.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDoanhThu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDoanhThu.Location = new System.Drawing.Point(175, 18);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersVisible = false;
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 50;
            this.dgvDoanhThu.Size = new System.Drawing.Size(778, 448);
            this.dgvDoanhThu.TabIndex = 11;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDoanhThu.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDoanhThu.ThemeStyle.ReadOnly = true;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDoanhThu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDoanhThu.ThemeStyle.RowsStyle.Height = 50;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDoanhThu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FDanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 540);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.dtpNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpThang);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.rdbNam);
            this.Controls.Add(this.rdbThang);
            this.Controls.Add(this.rdbNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDoanhThu);
            this.Name = "FDanhThu";
            this.Text = "FDanhThu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTongTien;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNam;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpThang;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgay;
        private Guna.UI2.WinForms.Guna2RadioButton rdbNam;
        private Guna.UI2.WinForms.Guna2RadioButton rdbThang;
        private Guna.UI2.WinForms.Guna2RadioButton rdbNgay;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDoanhThu;
    }
}