using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLMayTinh
{
    public partial class FGioHang : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        public FGioHang()
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
                using (SqlCommand cmd = new SqlCommand("dbo.XemGioHang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khach_hang", Form1.matk);
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

        private void FGioHang_Load(object sender, EventArgs e)
        {
            btnXemDanhGia.Enabled = false;
            DataTable dt = LoadDuLieu();
            flowPanel.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                UCGioHang uc = new UCGioHang();
                uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                uc.lblTenSP.Text= dr["ten_may_tinh"].ToString() ;
                uc.lblGiaTien.Text = dr["gia_tien"].ToString();
                uc.lblSoLuong.Text = dr["so_luong"].ToString();
                uc.Margin = new Padding(20);
                uc.CancelButtonClicked += XemSanPham;
                flowPanel.Controls.Add(uc);
            }
        }

        private void XemSanPham(object sender, EventArgs e)
        {
            btnXemDanhGia.Enabled = true;
            var ls = sender as UCGioHang;
            if (ls != null)
            {
                DataTable dt = LoadDuLieuChiTiet(ls.lblMaSP.Text);
                foreach(DataRow dr in dt.Rows)
                {
                    txtMaMayTinh.Text = dr["ma_may_tinh"].ToString();
                    txtTenMayTinh.Text = dr["ten_may_tinh"].ToString();
                    txtCPU.Text = dr["cpu"].ToString();
                    txtRAM.Text = dr["ram"].ToString();
                    txtOCung.Text = dr["o_cung"].ToString();
                    txtCardRoi.Text = dr["card_roi"].ToString();
                    txtManHinh.Text = dr["man_hinh"].ToString();
                    txtTrongLuong.Text = dr["trong_luong"].ToString();
                    txtGiaTien.Text = dr["gia_tien"].ToString() ;
                    txtBaoHanh.Text = dr["bao_hanh"].ToString();
                    byte[] imageData = dr["hinh_anh"] as byte[];

                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            try
                            {
                                Image img = Image.FromStream(ms);
                                picAnhSP.Image = img;
                                picAnhSP.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show("Không thể load được hình ảnh: " + ex.Message);
                            }
                        }
                    }
                }

            }
        }
        private DataTable LoadDuLieuChiTiet(string ma)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Query to select from the table-valued function LayThongTinChiTietSanPham
                string query = "SELECT * FROM dbo.LayThongTinChiTietSanPham(@ma_may_tinh)";

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    // Set the function parameter
                    cmd.Parameters.AddWithValue("@ma_may_tinh", ma);

                    // Execute the query and fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
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

            return dt;

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ma_may_tinh", typeof(string));
            dt.Columns.Add("ten_may_tinh", typeof(string));
            dt.Columns.Add("gia_tien", typeof(int));
            dt.Columns.Add("so_luong", typeof(int));

            // Duyệt qua các sản phẩm trong giỏ hàng
            foreach (Control control in flowPanel.Controls)
            {
                UCGioHang uc = control as UCGioHang;
                if (uc != null && uc.checkboxChon.Checked) // Nếu sản phẩm được chọn
                {
                    DataRow row = dt.NewRow();
                    row["ma_may_tinh"] = uc.lblMaSP.Text;
                    row["ten_may_tinh"] = uc.lblTenSP.Text;
                    row["gia_tien"] = uc.lblGiaTien.Text;
                    row["so_luong"] = uc.lblSoLuong.Text;
                    dt.Rows.Add(row);
                }
            }
            FThanhToan f = new FThanhToan(dt);
            f.ShowDialog();
        }

        private void btnXemDanhGia_Click(object sender, EventArgs e)
        {
            FDanhGia f = new FDanhGia(txtMaMayTinh.Text);
            f.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieuTheoTimKiem(txtTimKiem.Text, Form1.matk);
            flowPanel.Controls.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                // Tạo một UserControl UCGioHang mới cho mỗi sản phẩm
                UCGioHang uc = new UCGioHang();

                // Gán thông tin sản phẩm từ DataTable vào các nhãn trong UserControl
                uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                uc.lblTenSP.Text = dr["ten_may_tinh"].ToString();
                uc.lblGiaTien.Text = dr["gia_tien"].ToString();
                uc.lblSoLuong.Text = dr["so_luong"].ToString();
                uc.Margin = new Padding(20);

                // Gán sự kiện CancelButtonClicked để thực hiện chức năng khi nhấn vào nút
                uc.CancelButtonClicked += XemSanPham;

                // Thêm UserControl vào flowPanel
                flowPanel.Controls.Add(uc);
            }

        }
        private DataTable LoadDuLieuTheoTimKiem(string tuKhoa, string maKhachHang)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Query to select from the table-valued function TimSanPhamTrongGioHang
                string query = "SELECT * FROM dbo.TimSanPhamTrongGioHang(@tu_khoa, @ma_khach_hang)";

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    // Add the parameters for the function
                    cmd.Parameters.AddWithValue("@tu_khoa", tuKhoa);
                    cmd.Parameters.AddWithValue("@ma_khach_hang", maKhachHang);

                    // Check if the search keyword is null or empty
                    if (string.IsNullOrEmpty(tuKhoa))
                    {
                        MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return dt; // Return an empty DataTable
                    }

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
