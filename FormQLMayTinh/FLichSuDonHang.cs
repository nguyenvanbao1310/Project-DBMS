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
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
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

        private DataTable LoadChiTietDonHang(string maDonHang)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Query to call the function
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.LayChiTietDonHang(@ma_don_hang)", sqlcon))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ma_don_hang", maDonHang);

                    // Fill the DataTable with the result of the function call
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;

            // Lấy từ khóa mã đơn hàng và mã khách hàng từ các TextBox


            // Gọi hàm LoadDonHang với từ khóa mã đơn hàng và mã khách hàng
            DataTable dt = LoadDuLieuTheoTimKiem(txtTimKiem.Text, Form1.matk);

            // Xóa các đơn hàng hiện có trên giao diện
            flowPanel.Controls.Clear();
            List<UCLichSuDonHang> usp = new List<UCLichSuDonHang>();

            // Hiển thị từng đơn hàng trong DataTable lên flowPanel
            foreach (DataRow dr in dt.Rows)
            {
                UCLichSuDonHang uc = new UCLichSuDonHang();

                // Gán thông tin đơn hàng từ DataTable vào các nhãn trong UserControl
                uc.lblDonHang.Text = dr["ma_don_hang"].ToString();
                uc.lblNgayDatHang.Text = Convert.ToDateTime(dr["ngay_dat_hang"]).ToString("dd/MM/yyyy");

                int trangThai = int.Parse(dr["trang_thai"].ToString());
                uc.CancelButtonClicked += XemChiTiet;

                // Gán trạng thái đơn hàng dựa trên giá trị của cột 'trang_thai'
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

            // Thêm các UserControl vào flowPanel
            foreach (UCLichSuDonHang a in usp)
            {
                a.Margin = new Padding(10);
                flowPanel.Controls.Add(a);
            }

        }
        private DataTable LoadDuLieuTheoTimKiem(string maDonHang, string maKhachHang)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Query to select from the table-valued function TimDonHang
                string query = "SELECT * FROM dbo.TimDonHang(@ma_don_hang, @ma_khach_hang)";

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    // Add the parameters for the function
                    cmd.Parameters.AddWithValue("@ma_don_hang", maDonHang);
                    cmd.Parameters.AddWithValue("@ma_khach_hang", maKhachHang);

                    // Execute the query and fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors and display a message to the user
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Close the connection after finishing
                sqlcon.Close();
            }

            return dt;
        }

    }
}
