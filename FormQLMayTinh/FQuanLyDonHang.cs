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
    public partial class FQuanLyDonHang : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        public FQuanLyDonHang()
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
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM View_DanhSachDonHang", sqlcon))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            finally
            {
                sqlcon.Close();
            }
            return dt;

        }

        private void FQuanLyDonHang_Load(object sender, EventArgs e)
        {
            DataTable sp = LoadDuLieu();
            flowPanel.Controls.Clear();
            List<UCQuanLyDonHang> usp = new List<UCQuanLyDonHang>();
            foreach (DataRow dr in sp.Rows)
            {
                UCQuanLyDonHang uc = new UCQuanLyDonHang();
                uc.lblMaDH.Text = dr["ma_don_hang"].ToString();
                uc.lblMaKH.Text = dr["ma_khach_hang"].ToString();
                uc.lblTenKhachHang.Text = dr["ten_khach_hang"].ToString();
                uc.lblNgayDatHang.Text = Convert.ToDateTime(dr["ngay_dat_hang"]).ToString("dd/MM/yyyy");
                uc.lblTien.Text = dr["tong_tien"].ToString();
                int trangThai = int.Parse(dr["trang_thai"].ToString());
                switch(trangThai)
                {
                    case 1:
                        uc.lblTrangThai.Text = "Đã hoàn thành";
                        break;
                    case 2:
                        uc.lblTrangThai.Text = "Chưa hoàn thành";
                        break;
                    case 3:
                        uc.lblTrangThai.Text = "Đã hủy";
                        break;
                }
                usp.Add(uc);

            }
            foreach (UCQuanLyDonHang a in usp)
            {
                a.Margin = new Padding(0,10,0,0);
                flowPanel.Controls.Add(a);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text;
            DataTable sp = LoadDuLieuTheoTimKiem(tuKhoa);
            flowPanel.Controls.Clear();
            List<UCQuanLyDonHang> usp = new List<UCQuanLyDonHang>();
            foreach (DataRow dr in sp.Rows)
            {
                UCQuanLyDonHang uc = new UCQuanLyDonHang();
                uc.lblMaDH.Text = dr["ma_don_hang"].ToString();
                uc.lblMaKH.Text = dr["ma_khach_hang"].ToString();
                uc.lblTenKhachHang.Text = dr["ten_khach_hang"].ToString();
                uc.lblNgayDatHang.Text = Convert.ToDateTime(dr["ngay_dat_hang"]).ToString("dd/MM/yyyy");
                uc.lblTien.Text = dr["tong_tien"].ToString();
                int trangThai = int.Parse(dr["trang_thai"].ToString());
                switch (trangThai)
                {
                    case 1:
                        uc.lblTrangThai.Text = "Đã hoàn thành";
                        break;
                    case 2:
                        uc.lblTrangThai.Text = "Chưa hoàn thành";
                        break;
                    case 3:
                        uc.lblTrangThai.Text = "Đã hủy";
                        break;
                }
                usp.Add(uc);

            }
            foreach (UCQuanLyDonHang a in usp)
            {
                a.Margin = new Padding(0, 10, 0, 0);
                flowPanel.Controls.Add(a);
            }

        }
        private DataTable LoadDuLieuTheoTimKiem(string tuKhoa)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Set up the command to call the function
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TimDonHangChoChu(@tu_khoa)", sqlcon))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@tu_khoa", string.IsNullOrEmpty(tuKhoa) ? (object)DBNull.Value : tuKhoa);

                    // Fill DataTable with the result of the function call
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


    }
}
