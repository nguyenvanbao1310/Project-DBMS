namespace FormQLMayTinh
{
    partial class FSuDungKhuyenMai
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
            this.lblDonHang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(107)))), ((int)(((byte)(186)))));
            this.guna2Panel1.Controls.Add(this.lblDonHang);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1282, 59);
            this.guna2Panel1.TabIndex = 30;
            // 
            // lblDonHang
            // 
            this.lblDonHang.BackColor = System.Drawing.Color.Transparent;
            this.lblDonHang.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonHang.ForeColor = System.Drawing.Color.White;
            this.lblDonHang.Location = new System.Drawing.Point(571, 3);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(219, 43);
            this.lblDonHang.TabIndex = 134;
            this.lblDonHang.Text = "KHO VOUCHER";
            this.lblDonHang.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowPanel
            // 
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(0, 59);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(1282, 441);
            this.flowPanel.TabIndex = 31;
            // 
            // FSuDungKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 500);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FSuDungKhuyenMai";
            this.Text = "FSuDungKhuyenMai";
            this.Load += new System.EventHandler(this.FSuDungKhuyenMai_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDonHang;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
    }
}