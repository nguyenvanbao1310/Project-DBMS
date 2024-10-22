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
    public partial class FGiaoDienKhachHang : Form
    {
        private Form current;
        public FGiaoDienKhachHang()
        {
            InitializeComponent();
        }
        private void OpenForm(Form child)
        {
            if (current != null)
            {
                current.Close();
            }
            current = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            pnlChuyenTiep.Controls.Add(child);
            pnlChuyenTiep.Tag = child;
            child.BringToFront();
            child.Show();
        }


        private void btnThongTin_Click(object sender, EventArgs e)
        {

            FQuanLyThongTinCaNhan f = new FQuanLyThongTinCaNhan();
            OpenForm(f);
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            FGioHang f = new FGioHang();
            OpenForm(f);
        }

        private void btnKhoVouCher_Click(object sender, EventArgs e)
        {
           FSuDungKhuyenMai f = new FSuDungKhuyenMai();
            OpenForm(f);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            FLichSuDonHang f = new FLichSuDonHang();
            OpenForm(f);
        }

        private void btnLaptop_Click(object sender, EventArgs e)
        {
            FXemSanPham f = new FXemSanPham();
            OpenForm(f);
        }
    }
}
