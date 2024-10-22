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
    public partial class FTaoKhuyenMai : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        public FTaoKhuyenMai()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maKM = TaoMaKhuyenMai();
            ThemKhuyenMai(maKM);
            ThemKhuyenMai_SanPham(maKM);
            MessageBox.Show("Thêm khuyến mãi thành công");
        }
        private string TaoMaKhuyenMai()
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.TaoMaKhuyenMai();", sqlcon))
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

        private void ThemKhuyenMai(string maKM)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ThemKhuyenMai", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khuyen_mai", maKM);
                    cmd.Parameters.AddWithValue("@ten_khuyen_mai", txtTenKhuyenMai.Text);
                    cmd.Parameters.AddWithValue("@mo_ta", txtMoTa.Text);
                    cmd.Parameters.AddWithValue("@phan_tram_giam", float.Parse(txtPhanTramGiam.Text));
                    cmd.Parameters.AddWithValue("@so_tien_giam ", null);
                    cmd.Parameters.AddWithValue("@ngay_bat_dau", dtpNgayBatDau.Value.ToString());
                    cmd.Parameters.AddWithValue("@ngay_ket_thuc", dtpNgayKetThuc.Value.ToString());
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

        private void ThemKhuyenMai_SanPham(string maKM)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ThemKhuyenMaiSanPham", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khuyen_mai", maKM);
                    cmd.Parameters.AddWithValue("@ma_may_tinh", cbSanPham.SelectedItem.ToString());
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

        private void FTaoKhuyenMai_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM View_MayTinh", sqlcon))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string maSP = reader["ma_may_tinh"].ToString();
                        cbSanPham.Items.Add(maSP);
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
    }
}
