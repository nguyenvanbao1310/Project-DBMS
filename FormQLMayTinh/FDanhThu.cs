using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLMayTinh
{
    public partial class FDanhThu : Form
    {
        private String connStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        private int tongThu = 0;

        public FDanhThu()
        {
            InitializeComponent();
        }
        private void rdbNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNgay.Checked)
            {
                dtpNgay.Enabled = true;
                dtpNam.Enabled = false;
                dtpThang.Enabled = false;
                LoadDoanhThuTheoNgay(dtpNgay.Value);
            }
            else
            {
                if (rdbThang.Checked)
                {
                    dtpThang.Enabled = true;
                    dtpNam.Enabled = false;
                    dtpNgay.Enabled = false;
                    LoadDoanhThuTheoThang(dtpThang.Value.Month, dtpThang.Value.Year);
                }
                else
                {
                    dtpNam.Enabled = true;
                    dtpNgay.Enabled = false;
                    dtpThang.Enabled = false;
                    LoadDoanhThuTheoNam(dtpNam.Value.Year);
                }
            }

        }

        private void FDoanhThu_Load(object sender, EventArgs e)
        {
            dtpNgay.Enabled = true;
            dtpNam.Enabled = false;
            dtpThang.Enabled = false;
            dtpNgay.Checked = true;
        }

        private void LoadDoanhThuTheoNgay(DateTime ngay)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.DoanhThuTheoNgay(@ngay)", conn);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            doiTen(ref dt);
            dgvDoanhThu.DataSource = dt;
            // Tính tổng doanh thu
            tongThu = TinhTongGiaBanTheoNgay(ngay);
            txtTongTien.Text = tongThu.ToString("N0", new CultureInfo("vi-VN"));
        }

        private void LoadDoanhThuTheoThang(int thang, int nam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.DoanhThuTheoThang(@thang, @nam)", conn);
                cmd.Parameters.AddWithValue("@thang", thang);
                cmd.Parameters.AddWithValue("@nam", nam);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            doiTen(ref dt);
            dgvDoanhThu.DataSource = dt;

            // Tính tổng doanh thu
            tongThu = TinhTongGiaBanTheoThang(thang, nam);
            txtTongTien.Text = tongThu.ToString("N0", new CultureInfo("vi-VN"));
        }

        private void LoadDoanhThuTheoNam(int nam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.DoanhThuTheoNam(@nam)", conn);
                cmd.Parameters.AddWithValue("@nam", nam);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            doiTen(ref dt);
            dgvDoanhThu.DataSource = dt;

            // Tính tổng doanh thu
            tongThu = TinhTongGiaBanTheoNam(nam);
            txtTongTien.Text = tongThu.ToString("N0", new CultureInfo("vi-VN"));
        }

        private int TinhTongGiaBanTheoNgay(DateTime ngay)
        {
            int tongGiaBan = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Gọi hàm TinhTongGiaBanTheoNgay với tham số ngày
                SqlCommand cmd = new SqlCommand("SELECT dbo.TinhTongGiaBanTheoNgay(@ngay)", conn);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                conn.Open();

                object result = cmd.ExecuteScalar(); // Gọi ExecuteScalar để lấy giá trị
                if (result != null && result != DBNull.Value)
                {
                    tongGiaBan = (int)result; // Ép kiểu
                }
            }
            return tongGiaBan;
        }

        private int TinhTongGiaBanTheoThang(int thang, int nam)
        {
            int tongGiaBan = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Gọi hàm TinhTongGiaBanTheoThang với tham số tháng và năm
                SqlCommand cmd = new SqlCommand("SELECT dbo.TinhTongGiaBanTheoThang(@thang, @nam)", conn);
                cmd.Parameters.AddWithValue("@thang", thang);
                cmd.Parameters.AddWithValue("@nam", nam);
                conn.Open();

                object result = cmd.ExecuteScalar(); // Gọi ExecuteScalar để lấy giá trị
                if (result != null && result != DBNull.Value)
                {
                    tongGiaBan = (int)result; // Ép kiểu
                }
            }
            return tongGiaBan;
        }

        private int TinhTongGiaBanTheoNam(int nam)
        {
            int tongGiaBan = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT dbo.TinhTongGiaBanTheoNam(@nam)", conn);
                cmd.Parameters.AddWithValue("@nam", nam);
                conn.Open();

                object result = cmd.ExecuteScalar(); // Gọi ExecuteScalar để lấy giá trị
                if (result != null && result != DBNull.Value)
                {
                    tongGiaBan = (int)result; // Ép kiểu
                }
            }
            return tongGiaBan;
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadDoanhThuTheoNgay(dtpNgay.Value);
        }

        private void dtpThang_ValueChanged(object sender, EventArgs e)
        {
            LoadDoanhThuTheoThang(dtpThang.Value.Month, dtpThang.Value.Year);
        }

        private void dtpNam_ValueChanged(object sender, EventArgs e)
        {
            LoadDoanhThuTheoNam(dtpNam.Value.Year);
        }
        private void doiTen(ref DataTable dt)
        {
            if (dt.Columns.Contains("ten_may_tinh"))
            {
                dt.Columns["ten_may_tinh"].ColumnName = "Tên Máy";
            }
            if (dt.Columns.Contains("gia_ban"))
            {
                dt.Columns["gia_ban"].ColumnName = "Giá Bán";
            }
            if (dt.Columns.Contains("so_luong"))
            {
                dt.Columns["so_luong"].ColumnName = "Số Lượng";
            }
            if (dt.Columns.Contains("tong_tien"))
            {
                dt.Columns["tong_tien"].ColumnName = "Tổng Tiền";
            }
        }
    }
}
