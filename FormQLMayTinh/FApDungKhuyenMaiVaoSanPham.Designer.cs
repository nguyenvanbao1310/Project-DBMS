namespace FormQLMayTinh
{
    partial class FApDungKhuyenMaiVaoSanPham
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ctrol1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ctrol2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ctrol3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblDonHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(107)))), ((int)(((byte)(186)))));
            this.guna2Panel1.Controls.Add(this.ctrol1);
            this.guna2Panel1.Controls.Add(this.ctrol2);
            this.guna2Panel1.Controls.Add(this.ctrol3);
            this.guna2Panel1.Controls.Add(this.lblDonHang);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(982, 59);
            this.guna2Panel1.TabIndex = 31;
            // 
            // ctrol1
            // 
            this.ctrol1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrol1.BackColor = System.Drawing.Color.Transparent;
            this.ctrol1.BorderThickness = 1;
            this.ctrol1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.ctrol1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.ctrol1.IconColor = System.Drawing.Color.Black;
            this.ctrol1.Location = new System.Drawing.Point(877, 0);
            this.ctrol1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrol1.Name = "ctrol1";
            this.ctrol1.Size = new System.Drawing.Size(35, 40);
            this.ctrol1.TabIndex = 137;
            // 
            // ctrol2
            // 
            this.ctrol2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrol2.BackColor = System.Drawing.Color.Transparent;
            this.ctrol2.BorderThickness = 1;
            this.ctrol2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.ctrol2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.ctrol2.IconColor = System.Drawing.Color.Black;
            this.ctrol2.Location = new System.Drawing.Point(912, 0);
            this.ctrol2.Margin = new System.Windows.Forms.Padding(4);
            this.ctrol2.Name = "ctrol2";
            this.ctrol2.Size = new System.Drawing.Size(35, 40);
            this.ctrol2.TabIndex = 136;
            // 
            // ctrol3
            // 
            this.ctrol3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrol3.BackColor = System.Drawing.Color.Transparent;
            this.ctrol3.BorderThickness = 1;
            this.ctrol3.FillColor = System.Drawing.Color.WhiteSmoke;
            this.ctrol3.IconColor = System.Drawing.Color.Black;
            this.ctrol3.Location = new System.Drawing.Point(947, 0);
            this.ctrol3.Margin = new System.Windows.Forms.Padding(4);
            this.ctrol3.Name = "ctrol3";
            this.ctrol3.Size = new System.Drawing.Size(35, 40);
            this.ctrol3.TabIndex = 135;
            // 
            // lblDonHang
            // 
            this.lblDonHang.BackColor = System.Drawing.Color.Transparent;
            this.lblDonHang.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonHang.ForeColor = System.Drawing.Color.White;
            this.lblDonHang.Location = new System.Drawing.Point(409, 4);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(146, 43);
            this.lblDonHang.TabIndex = 134;
            this.lblDonHang.Text = "VOUCHER";
            this.lblDonHang.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowPanel
            // 
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(0, 59);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(982, 335);
            this.flowPanel.TabIndex = 32;
            // 
            // FApDungKhuyenMaiVaoSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 394);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FApDungKhuyenMaiVaoSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FApDungKhuyenMaiVaoSanPham";
            this.Load += new System.EventHandler(this.FApDungKhuyenMaiVaoSanPham_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public Guna.UI2.WinForms.Guna2ControlBox ctrol1;
        public Guna.UI2.WinForms.Guna2ControlBox ctrol2;
        public Guna.UI2.WinForms.Guna2ControlBox ctrol3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDonHang;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
    }
}