namespace FormQLMayTinh
{
    partial class UCQuanLyDonHang
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMaDH = new System.Windows.Forms.LinkLabel();
            this.lblTrangThai = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNgayTaoDon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTenKhachHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMaKH = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(107)))), ((int)(((byte)(186)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.lblMaDH);
            this.guna2Panel1.Controls.Add(this.lblTrangThai);
            this.guna2Panel1.Controls.Add(this.lblTien);
            this.guna2Panel1.Controls.Add(this.lblNgayTaoDon);
            this.guna2Panel1.Controls.Add(this.lblTenKhachHang);
            this.guna2Panel1.Controls.Add(this.lblMaKH);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(107)))), ((int)(((byte)(186)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1255, 54);
            this.guna2Panel1.TabIndex = 1;
            // 
            // lblMaDH
            // 
            this.lblMaDH.AutoSize = true;
            this.lblMaDH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(107)))), ((int)(((byte)(186)))));
            this.lblMaDH.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDH.ForeColor = System.Drawing.Color.White;
            this.lblMaDH.LinkColor = System.Drawing.Color.White;
            this.lblMaDH.Location = new System.Drawing.Point(29, 15);
            this.lblMaDH.Name = "lblMaDH";
            this.lblMaDH.Size = new System.Drawing.Size(119, 25);
            this.lblMaDH.TabIndex = 110;
            this.lblMaDH.TabStop = true;
            this.lblMaDH.Text = "Mã đơn hàng";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai.Location = new System.Drawing.Point(1052, 15);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(164, 27);
            this.lblTrangThai.TabIndex = 108;
            this.lblTrangThai.Text = "Trạng thái đơn hàng";
            // 
            // lblTien
            // 
            this.lblTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTien.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTien.ForeColor = System.Drawing.Color.White;
            this.lblTien.Location = new System.Drawing.Point(882, 15);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(78, 27);
            this.lblTien.TabIndex = 107;
            this.lblTien.Text = "Tổng tiền";
            // 
            // lblNgayTaoDon
            // 
            this.lblNgayTaoDon.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayTaoDon.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayTaoDon.ForeColor = System.Drawing.Color.White;
            this.lblNgayTaoDon.Location = new System.Drawing.Point(667, 15);
            this.lblNgayTaoDon.Name = "lblNgayTaoDon";
            this.lblNgayTaoDon.Size = new System.Drawing.Size(113, 27);
            this.lblNgayTaoDon.TabIndex = 106;
            this.lblNgayTaoDon.Text = "Ngày tạo đơn ";
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.lblTenKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKhachHang.ForeColor = System.Drawing.Color.White;
            this.lblTenKhachHang.Location = new System.Drawing.Point(458, 15);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(127, 27);
            this.lblTenKhachHang.TabIndex = 104;
            this.lblTenKhachHang.Text = "Tên khách hàng";
            // 
            // lblMaKH
            // 
            this.lblMaKH.BackColor = System.Drawing.Color.Transparent;
            this.lblMaKH.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.ForeColor = System.Drawing.Color.White;
            this.lblMaKH.Location = new System.Drawing.Point(225, 15);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(124, 27);
            this.lblMaKH.TabIndex = 103;
            this.lblMaKH.Text = "Mã khách hàng";
            // 
            // UCQuanLyDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UCQuanLyDonHang";
            this.Size = new System.Drawing.Size(1255, 54);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.LinkLabel lblMaDH;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblTrangThai;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblTien;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblNgayTaoDon;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblTenKhachHang;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblMaKH;
    }
}
