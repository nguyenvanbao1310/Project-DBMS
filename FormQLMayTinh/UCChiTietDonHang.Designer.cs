namespace FormQLMayTinh
{
    partial class UCChiTietDonHang
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
            this.lblMaSanPham = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTenSP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGiaTien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoLuong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnl1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
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
            // lblSoLuong
            // 
            this.lblSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuong.Location = new System.Drawing.Point(444, 10);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(21, 27);
            this.lblSoLuong.TabIndex = 114;
            this.lblSoLuong.Text = "SL";
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.White;
            this.pnl1.BorderColor = System.Drawing.Color.Black;
            this.pnl1.BorderRadius = 7;
            this.pnl1.BorderThickness = 1;
            this.pnl1.Controls.Add(this.lblSoLuong);
            this.pnl1.Controls.Add(this.lblGiaTien);
            this.pnl1.Controls.Add(this.lblTenSP);
            this.pnl1.Controls.Add(this.lblMaSanPham);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(509, 43);
            this.pnl1.TabIndex = 1;
            // 
            // UCChiTietDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl1);
            this.Name = "UCChiTietDonHang";
            this.Size = new System.Drawing.Size(509, 43);
            this.Load += new System.EventHandler(this.UCChiTietDonHang_Load);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel lblMaSanPham;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblTenSP;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblGiaTien;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblSoLuong;
        public Guna.UI2.WinForms.Guna2Panel pnl1;
    }
}
