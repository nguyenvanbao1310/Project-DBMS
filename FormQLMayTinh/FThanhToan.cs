using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace FormQLMayTinh
{
    public partial class FThanhToan : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        private DataTable dt;
       
        public FThanhToan(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void FThanhToan_Load(object sender, EventArgs e)
        {
            flowPanel.Controls.Clear();
            int sl = 0;
            int sum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                UCHoaDonThanhToan uc = new UCHoaDonThanhToan();
                uc.lblMaSanPham.Text = dr["ma_may_tinh"].ToString();
                uc.lblTenSP.Text = dr["ten_may_tinh"].ToString();
                uc.lblGiaTien.Text = dr["gia_tien"].ToString();
                uc.lblSoLuong.Text = dr["so_luong"].ToString();
                uc.Margin = new Padding(10);
                uc.CancelButtonClicked1 += XoaSanPham;
                uc.CancelButtonClicked += ApDungVoucher;
                sl += int.Parse(uc.lblSoLuong.Text);
                sum += int.Parse(uc.lblGiaTien.Text) * int.Parse(uc.lblSoLuong.Text);
                flowPanel.Controls.Add(uc);
            }
            LoadHoaDon(sl, sum);
        }

        private void LoadHoaDon(int sl, int sum)
        {
            txtTienSanPham.Text = sum.ToString();
            txtSoLuong.Text = sl.ToString();
            txtPhiVC.Text = (sum * 0.01).ToString();
            txtTong.Text = (sum + sum * 0.01).ToString();
            dtpNgayTT.Value = DateTime.Now;
            dtpNgayTT.Enabled = false;
        }

        private void XoaSanPham(object sender, EventArgs e)
        {
            var ls = sender as UCHoaDonThanhToan;
            if (ls != null) 
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ma_may_tinh"].ToString() == ls.lblMaSanPham.Text)
                    {
                        dr.Delete();
                        break; 
                    }
                }

            }
            dt.AcceptChanges();
            FThanhToan_Load(sender, e);
        }

        private void btnXacNhanTT_Click(object sender, EventArgs e)
        {
            if (cboxPhuongThuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn với sự lựa chọn này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    string phuongThuc = cboxPhuongThuc.SelectedItem.ToString();
                    if (phuongThuc == "COD")
                    {
                        string maDH = TaoMaDonHang();
                        TaoDonHang(maDH, 2);
                        TaoDonHangChiTiet(maDH);

                    }
                    if (phuongThuc == "Thanh Toán Online")
                    {
                        string maDH = TaoMaDonHang();
                        TaoDonHang(maDH, 1);
                        TaoDonHangChiTiet(maDH);
                    }
                    MessageBox.Show("Thanh toán thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void ApDungVoucher(object sender, EventArgs e)
        {
            
            var ls = sender as UCHoaDonThanhToan;
            int goc = int.Parse(ls.lblGiaTien.Text);
            FApDungKhuyenMaiVaoSanPham f = new FApDungKhuyenMaiVaoSanPham(ls.lblMaSanPham.Text);
            f.ShowDialog();
            if(FApDungKhuyenMaiVaoSanPham.maKM != null)
            {
                ls.lblGiaTien.Text = TienSauKhiKhuyenMai(ls.lblMaSanPham.Text, FApDungKhuyenMaiVaoSanPham.maKM).ToString();

            }

            int giam = goc - int.Parse(ls.lblGiaTien.Text);
            ls.linkchon.Visible = false;
            ls.txtChonVoucher.Text = "GIẢM GIÁ " + FApDungKhuyenMaiVaoSanPham.phanTram + "%";
            ls.txtChonVoucher.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
            ls.txtChonVoucher.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
            int sum = int.Parse(txtTienSanPham.Text) - giam * int.Parse(ls.lblSoLuong.Text);
            int sl = int.Parse(ls.lblSoLuong.Text);
            LoadHoaDon(sl, sum);

        }

        private string TaoMaDonHang()
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.TaoMaDonHang();", sqlcon))
                {
                    return cmd.ExecuteScalar().ToString();
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
            return null;
        }

        private void TaoDonHang(string maDH, int trangThai)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ThemDonHang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_don_hang", maDH);
                    cmd.Parameters.AddWithValue("@ma_khach_hang", Form1.matk);
                    cmd.Parameters.AddWithValue("@ngay_dat_hang", DateTime.Now);
                    cmd.Parameters.AddWithValue("@tong_tien", int.Parse(txtTong.Text));
                    cmd.Parameters.AddWithValue("@trang_thai", trangThai);
                    cmd.ExecuteNonQuery();
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
        }

        private void TaoDonHangChiTiet(string maDH)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ThemDonHangChiTiet", sqlcon))
                {
                    foreach (System.Windows.Forms.Control control in flowPanel.Controls)
                    {
                        UCHoaDonThanhToan uc = control as UCHoaDonThanhToan;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma_don_hang", maDH);
                        cmd.Parameters.AddWithValue("@ma_may_tinh", uc.lblMaSanPham.Text);
                        cmd.Parameters.AddWithValue("@gia_ban", int.Parse(uc.lblGiaTien.Text));
                        cmd.Parameters.AddWithValue("@so_luong", int.Parse(uc.lblSoLuong.Text));
                        cmd.ExecuteNonQuery();
                        XoaSanPhamKhoiGioHang(uc.lblMaSanPham.Text);
                        cmd.Parameters.Clear();
                    }
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
        }

        private void XoaSanPhamKhoiGioHang(string ma)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.XoaKhoiGioHang", sqlcon))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khach_hang", Form1.matk);
                    cmd.Parameters.AddWithValue("@ma_may_tinh", ma);
                    cmd.ExecuteNonQuery();

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
        }

        private int TienSauKhiKhuyenMai(string maMT, string maKM)
        {
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Query to select from the table-valued function LayThongTinChiTietSanPham
                using (SqlCommand command = new SqlCommand("SELECT dbo.ApDungKhuyenMai(@ma_may_tinh, @ma_khuyen_mai)", sqlcon))
                {
                    // Thêm tham số cho hàm
                    command.Parameters.AddWithValue("@ma_may_tinh", maMT);
                    command.Parameters.AddWithValue("@ma_khuyen_mai", maKM);

                    // Thực thi lệnh và lấy kết quả
                    object result = command.ExecuteScalar();

                    // Kiểm tra kết quả và trả về
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                // Display any errors
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Close the connection
                sqlcon.Close();
            }
            return 0;

        }

    }
}
