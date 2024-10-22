namespace FormQLMayTinh
{
    partial class UCHoaDonThanhToan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl1 = new Guna.UI2.WinForms.Guna2Panel();
            this.linkchon = new System.Windows.Forms.LinkLabel();
            this.txtChonVoucher = new Guna.UI2.WinForms.Guna2TextBox();
            this.picXoa = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblSoLuong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGiaTien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTenSP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMaSanPham = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picXoa)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.White;
            this.pnl1.BorderColor = System.Drawing.Color.Black;
            this.pnl1.BorderRadius = 7;
            this.pnl1.BorderThickness = 1;
            this.pnl1.Controls.Add(this.linkchon);
            this.pnl1.Controls.Add(this.txtChonVoucher);
            this.pnl1.Controls.Add(this.picXoa);
            this.pnl1.Controls.Add(this.lblSoLuong);
            this.pnl1.Controls.Add(this.lblGiaTien);
            this.pnl1.Controls.Add(this.lblTenSP);
            this.pnl1.Controls.Add(this.lblMaSanPham);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(664, 43);
            this.pnl1.TabIndex = 2;
            // 
            // linkchon
            // 
            this.linkchon.AutoSize = true;
            this.linkchon.Location = new System.Drawing.Point(552, 15);
            this.linkchon.Name = "linkchon";
            this.linkchon.Size = new System.Drawing.Size(38, 16);
            this.linkchon.TabIndex = 117;
            this.linkchon.TabStop = true;
            this.linkchon.Text = "Chọn";
            this.linkchon.Click += new System.EventHandler(this.linkchon_Click);
            // 
            // txtChonVoucher
            // 
            this.txtChonVoucher.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChonVoucher.DefaultText = "";
            this.txtChonVoucher.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtChonVoucher.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtChonVoucher.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChonVoucher.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChonVoucher.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChonVoucher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtChonVoucher.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChonVoucher.Location = new System.Drawing.Point(466, 6);
            this.txtChonVoucher.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChonVoucher.Name = "txtChonVoucher";
            this.txtChonVoucher.PasswordChar = '\0';
            this.txtChonVoucher.PlaceholderText = "";
            this.txtChonVoucher.SelectedText = "";
            this.txtChonVoucher.Size = new System.Drawing.Size(131, 31);
            this.txtChonVoucher.TabIndex = 116;
            // 
            // picXoa
            // 
            this.picXoa.BackColor = System.Drawing.Color.Transparent;
            this.picXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picXoa.Image = global::FormQLMayTinh.Properties.Resources.delete_1;
            this.picXoa.ImageRotate = 0F;
            this.picXoa.Location = new System.Drawing.Point(619, 8);
            this.picXoa.Name = "picXoa";
            this.picXoa.Size = new System.Drawing.Size(32, 25);
            this.picXoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picXoa.TabIndex = 115;
            this.picXoa.TabStop = false;
            this.picXoa.Click += new System.EventHandler(this.picXoa_Click);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuong.Location = new System.Drawing.Point(439, 8);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(21, 27);
            this.lblSoLuong.TabIndex = 114;
            this.lblSoLuong.Text = "SL";
            // 
            // lblGiaTien
            // 
            this.lblGiaTien.BackColor = System.Drawing.Color.Transparent;
            this.lblGiaTien.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTien.ForeColor = System.Drawing.Color.Black;
            this.lblGiaTien.Location = new System.Drawing.Point(332, 10);
            this.lblGiaTien.Name = "lblGiaTien";
            this.lblGiaTien.Size = new System.Drawing.Size(62, 27);
            this.lblGiaTien.TabIndex = 113;
            this.lblGiaTien.Text = "Giá tiền";
            // 
            // lblTenSP
            // 
            this.lblTenSP.BackColor = System.Drawing.Color.Transparent;
            this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.ForeColor = System.Drawing.Color.Black;
            this.lblTenSP.Location = new System.Drawing.Point(167, 8);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(114, 27);
            this.lblTenSP.TabIndex = 112;
            this.lblTenSP.Text = "Tên sản phẩm";
            // 
            // lblMaSanPham
            // 
            this.lblMaSanPham.BackColor = System.Drawing.Color.Transparent;
            this.lblMaSanPham.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSanPham.ForeColor = System.Drawing.Color.Black;
            this.lblMaSanPham.Location = new System.Drawing.Point(23, 8);
            this.lblMaSanPham.Name = "lblMaSanPham";
            this.lblMaSanPham.Size = new System.Drawing.Size(111, 27);
            this.lblMaSanPham.TabIndex = 111;
            this.lblMaSanPham.Text = "Mã sản phẩm";
            // 
            // UCHoaDonThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl1);
            this.Name = "UCHoaDonThanhToan";
            this.Size = new System.Drawing.Size(664, 43);
            this.Load += new System.EventHandler(this.UCHoaDonThanhToan_Load);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picXoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel pnl1;
        public Guna.UI2.WinForms.Guna2PictureBox picXoa;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblSoLuong;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblGiaTien;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblTenSP;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblMaSanPham;
        public Guna.UI2.WinForms.Guna2TextBox txtChonVoucher;
        public System.Windows.Forms.LinkLabel linkchon;
    }
}
