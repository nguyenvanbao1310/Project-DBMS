using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLMayTinh
{
    public partial class FGiaoDienChuShop : Form
    {
        private Form current;
        public FGiaoDienChuShop()
        {
            InitializeComponent();
            pnlSanPham.Visible = false;

            pnlCaiDat.Visible = false;
        }
        private void OpenForm(Form child)
        {
            if (current != null)
            {
                current.Close();
            }
            current = child;
            child.TopLevel = false;
            child.TopLevel = false;
            child.Dock = DockStyle.Fill;
            pnlManHinh.Controls.Add(child);
            pnlManHinh.Tag = child;
            child.Show();
        }
        private void OpenMenu()
        {
            if (pnlSanPham.Visible == true)
                pnlSanPham.Visible = false;

            if (pnlCaiDat.Visible == true)
                pnlCaiDat.Visible = false;

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            FQuanLyDanhSachTaiKhoan f = new FQuanLyDanhSachTaiKhoan();
            OpenForm(f);
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            OpenMenu();
            pnlCaiDat.Visible = true;
        }

        private void btnDanhSachSP_Click(object sender, EventArgs e)
        {
            OpenMenu();
            pnlSanPham.Visible = true;
        }

        private void btnDSSP_Click(object sender, EventArgs e)
        {
            FQuanLySanPham f = new FQuanLySanPham();
            OpenForm(f);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            FQuanLyDonHang f = new FQuanLyDonHang();
            OpenForm(f);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            FKhoKhuyenMai f = new FKhoKhuyenMai();
            OpenForm(f);
        }
    }
}
