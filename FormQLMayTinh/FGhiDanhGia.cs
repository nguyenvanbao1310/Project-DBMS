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
    public partial class FGhiDanhGia : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        public FGhiDanhGia()
        {
            InitializeComponent();
        }


        private void cbMaDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaDonHang.SelectedItem != null)
            {
                string maDH  =cbMaDonHang.SelectedItem.ToString();
                LoadMaSanPham(maDH);
            }
        }

        private void FGhiDanhGia_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.LayDonHangHoanThanhCuaKhachHang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khach_hang", Form1.matk);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string maDH = reader["ma_don_hang"].ToString();
                            cbMaDonHang.Items.Add(maDH);
                        }
                    }
                    reader.Close();
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
        }

        private void LoadMaSanPham(string maDH)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.XemChiTietDonHang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_don_hang", maDH);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string maSP = reader["ma_may_tinh"].ToString();
                            cbMaSanPham.Items.Add(maSP);
                        }
                    }
                    reader.Close();
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
        }

        private void cbMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaSanPham.SelectedItem != null)
            {
                string maSP = cbMaSanPham.SelectedItem.ToString();
                LoadTenSanPham(maSP);
            }
        }

        private void  LoadTenSanPham(string maSP)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.XemChiTietMayTinh", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_may_tinh", maSP);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string tenSP = reader["ten_may_tinh"].ToString();
                            txtTenSP.Text = tenSP;
                        }
                    }
                    reader.Close();
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
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbMaSanPham.SelectedItem != null && txtNoiDungDG.Text !=null)
            {
                ThemDanhGia();
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin đánh giá");
            }    
        }

        private void ThemDanhGia()
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.InfoMessage += (s, ev) =>
                {
                    // Hiển thị thông báo từ SQL Server qua MessageBox
                    MessageBox.Show("SQL Server Message: " + ev.Message, "Thông báo từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ThemDanhGia", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khach_hang", Form1.matk);
                    cmd.Parameters.AddWithValue("@ma_may_tinh", cbMaSanPham.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@so_sao_danh_gia ", int.Parse(cboxSoSao.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@noi_dung", txtNoiDungDG.Text);
                    cmd.ExecuteNonQuery();
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
        }
    }
}
