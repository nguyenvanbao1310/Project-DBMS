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
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        public FTaoKhuyenMai()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemKhuyenMai();
        }
        private void ThemKhuyenMai()
        {
            float phanTram = 0;
            int soTien = 0;
            if (cbSanPham.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm.");
                return;
            }
            if (rdoPhanTram.Checked == true)
            {
                phanTram = float.Parse(txtPhanTramGiam.Text);
            }

            if (rdoSoTien.Checked == true)
            {
                soTien = int.Parse(txtSoTienGiam.Text);
            }

            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.InfoMessage += (s, ev) =>
                {
                    // Hiển thị thông báo từ SQL Server qua MessageBox
                    MessageBox.Show("SQL Server Message: " + ev.Message, "Thông báo từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ThemKhuyenMai", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ten_khuyen_mai", txtTenKhuyenMai.Text);
                    cmd.Parameters.AddWithValue("@mo_ta", txtMoTa.Text);
                    cmd.Parameters.AddWithValue("@phan_tram_giam", phanTram);
                    cmd.Parameters.AddWithValue("@so_tien_giam ", soTien);
                    cmd.Parameters.AddWithValue("@ngay_bat_dau", dtpNgayBatDau.Value.ToString());
                    cmd.Parameters.AddWithValue("@ngay_ket_thuc", dtpNgayKetThuc.Value.ToString());
                    cmd.Parameters.AddWithValue("@ma_may_tinh", cbSanPham.SelectedItem.ToString());
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

        private void FTaoKhuyenMai_Load(object sender, EventArgs e)
        {
            txtSoTienGiam.Enabled = false;
            txtPhanTramGiam.Enabled = false;
            ChonHinhThucKhuyenMai();
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

        private void ChonHinhThucKhuyenMai()
        {
            if (rdoPhanTram.Checked == true)
            {
                txtSoTienGiam.Enabled = false;
                txtPhanTramGiam.Enabled = true;
            }

            if (rdoSoTien.Checked == true)
            {
                txtSoTienGiam.Enabled = true;
                txtPhanTramGiam.Enabled = false;
            }
        }

        private void rdoPhanTram_CheckedChanged(object sender, EventArgs e)
        {
            ChonHinhThucKhuyenMai();
        }

        private void rdoSoTien_CheckedChanged(object sender, EventArgs e)
        {
            ChonHinhThucKhuyenMai();
        }
    }
}
