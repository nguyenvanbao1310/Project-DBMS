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
    public partial class FSuaKhuyenMai : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        private UCKhuyenMai uc;
        private List<string> list = new List<string>();
        public FSuaKhuyenMai(UCKhuyenMai uc)
        {
            InitializeComponent();
            this.uc = uc;
        }

        private void FSuaKhuyenMai_Load(object sender, EventArgs e)
        {
            cbSanPham.Items.Clear();
            cbThemMaSP.Items.Clear();
            txtTenKhuyenMai.Text = uc.lblTenKhuyenMai.Text;
            txtMoTa.Text = uc.hiddenMoTa.Text;
            txtSoTienGiam.Text = uc.lblSoTienGiam.Text;
            txtPhanTramGiam.Text = uc.lblPhanTramGiam.Text;
            dtpNgayBatDau.Value = Convert.ToDateTime(uc.lblNgayBatDau.Text);
            dtpNgayKetThuc.Value = Convert.ToDateTime(uc.lblNgayKetThuc.Text);
            LoadTatCaMaSanPhamTheoMaKhuyenMai(uc.lblMaKhuyenMai.Text);
            LoadTatCaMaSanPham();
        }

        private void LoadTatCaMaSanPhamTheoMaKhuyenMai(string ma)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.XemSanPhamApDungVoiMoiKhuyenMai", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khuyen_mai", ma);
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

        private void LoadTatCaMaSanPham()
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
                        cbThemMaSP.Items.Add(maSP);
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

        private void bntThem_Click(object sender, EventArgs e)
        {
            if (cbThemMaSP.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm.");
                return;
            }
            else
            {
                string maSP = cbThemMaSP.SelectedItem.ToString();
                if(cbSanPham.Items.Contains(maSP))
                {
                    MessageBox.Show("Sản phẩm này đã được áp dụng khuyến mãi");
                }
                else
                {
                    cbSanPham.Items.Add(maSP);
                    list.Add(maSP);
                }    
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.SuaKhuyenMai", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khuyen_mai", uc.lblMaKhuyenMai.Text);
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

            if(list.Count>0)
            {
                ThemKhuyenMai_SanPham(uc.lblMaKhuyenMai.Text);
            }
            MessageBox.Show("Sửa thành công");
        }

        private void ThemKhuyenMai_SanPham(string maKM)
        {
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ThemKhuyenMaiSanPham", sqlcon))
                {
                    foreach (string item in list) 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma_khuyen_mai", maKM);
                        cmd.Parameters.AddWithValue("@ma_may_tinh", item);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm cần xóa.");
                return;
            }
            else
            {
                if(cbSanPham.SelectedItem.ToString() == "All")
                {
                    sqlcon = new SqlConnection(conStr);
                    try
                    {
                        sqlcon.Open();
                        using (SqlCommand cmd = new SqlCommand("dbo.XoaKhuyenMai", sqlcon))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ma_khuyen_mai", uc.lblMaKhuyenMai.Text);
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
                    MessageBox.Show("Xóa khuyến mãi thành công");
                    this.Hide();
                }
                else
                {
                    sqlcon = new SqlConnection(conStr);
                    try
                    {
                        sqlcon.Open();
                        using (SqlCommand cmd = new SqlCommand("dbo.XoaSanPham_KhuyenMai", sqlcon))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ma_khuyen_mai", uc.lblMaKhuyenMai.Text);
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
                    MessageBox.Show("Xóa khuyến mãi - sản phẩm thành công");
                    FSuaKhuyenMai_Load(sender, e);
                }
                
            }
        }
    }
}
