using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLMayTinh
{
    public partial class FLichSuDonHang : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        private int trangThai;
        private UCLichSuDonHang ls;
        public FLichSuDonHang()
        {
            InitializeComponent();
        }

        private DataTable LoadDuLieu()
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.XemLichSuDonHang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_nguoi_dung", Form1.matk);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            finally
            {
                sqlcon.Close();
            }
            return dt;

        }

        private void FLichSuDonHang_Load(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;
            DataTable dt = LoadDuLieu();
            flowPanel.Controls.Clear();
            List<UCLichSuDonHang> usp = new List<UCLichSuDonHang>();
            foreach (DataRow dr in dt.Rows)
            {
                UCLichSuDonHang uc = new UCLichSuDonHang();
                uc.lblDonHang.Text = dr["ma_don_hang"].ToString();
                uc.lblNgayDatHang.Text = Convert.ToDateTime(dr["ngay_dat_hang"]).ToString("dd/MM/yyyy");
                trangThai= int.Parse(dr["trang_thai"].ToString());
                uc.CancelButtonClicked += XemChiTiet;
                switch (trangThai)
                {
                    case 1:
                        uc.lblTrangThai.Text = "Hoàn thành";
                        uc.lblTrangThai.ForeColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        break;
                    case 2:
                        uc.lblTrangThai.Text = "Đang xử lý";
                        uc.lblTrangThai.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        break;
                    case 3:
                        uc.lblTrangThai.Text = "Đã hủy";
                        uc.lblTrangThai.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        break;
                }
                usp.Add(uc);
            }
            foreach (UCLichSuDonHang a in usp)
            {
                a.Margin = new Padding(10);
                flowPanel.Controls.Add(a);
            }

        }
        private void XemChiTiet(object sender, EventArgs e)
        {
            ls = sender as UCLichSuDonHang;
            int sl = 0;
            int sum = 0;
            if (ls != null)
            {
                DataTable dt = LoadChiTietDonHang(ls.lblDonHang.Text);
                flowPanel1.Controls.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    UCChiTietDonHang uc = new UCChiTietDonHang();
                    uc.lblMaSanPham.Text = dr["ma_may_tinh"].ToString();
                    uc.lblTenSP.Text = dr["ten_may_tinh"].ToString();
                    uc.lblGiaTien.Text = dr["gia_ban"].ToString();
                    uc.lblSoLuong.Text = dr["so_luong"].ToString();
                    sl += int.Parse(uc.lblSoLuong.Text);
                    sum += int.Parse(uc.lblGiaTien.Text) * int.Parse(uc.lblSoLuong.Text);
                    uc.Margin = new Padding(10);
                    flowPanel1.Controls.Add(uc);
                }
                txtTongTien.Text = sum.ToString();
                txtPhiVC.Text = (sum * 0.01).ToString();
                txtTongTienHoaDon.Text = (sum + sum * 0.01).ToString();
                txtSoLuong.Text = sl.ToString();
                txtNgayDat.Text = ls.lblNgayDatHang.Text;

                switch (ls.lblTrangThai.Text)
                {
                    case "Hoàn thành":
                        txtTrangThaiDH.Text = "HOÀN THÀNH";
                        txtTrangThaiDH.BorderColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        txtTrangThaiDH.ForeColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        btnXacNhan.Text = "HỦY ĐƠN HÀNG";
                        btnXacNhan.Enabled = false;
                        txtPhuongThucTT.Text = "Thanh toán online";
                        break;
                    case "Đang xử lý":
                        txtTrangThaiDH.Text = "ĐANG XỬ LÝ";
                        txtTrangThaiDH.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        txtTrangThaiDH.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        btnXacNhan.Text = "HỦY ĐƠN HÀNG";
                        btnXacNhan.Enabled = true;
                        txtPhuongThucTT.Text = "COD";
                        break;
                    case "Đã hủy":
                        txtTrangThaiDH.Text = "ĐÃ HỦY";
                        txtTrangThaiDH.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        txtTrangThaiDH.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        btnXacNhan.Text = "HỦY ĐƠN HÀNG";
                        btnXacNhan.Enabled = false;
                        txtPhuongThucTT.Text = "COD";
                        break;
                }
            }
           

        }

        private DataTable LoadChiTietDonHang(string ma)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.XemChiTietDonHang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_don_hang", ma);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            FHuyDonHang f = new FHuyDonHang(ls);
            f.ShowDialog();
        }
    }
}
