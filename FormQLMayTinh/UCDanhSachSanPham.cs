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
    public partial class UCDanhSachSanPham : UserControl
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        public UCDanhSachSanPham()
        {
            InitializeComponent();
        }
        private string TruncateText(string text, int maxLength)
        {
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength) + "...";
            }
            else
            {
                return text;
            }
        }

        private void UCDanhSachSanPham_Load(object sender, EventArgs e)
        {
            lblMoTaSP.Text = TruncateText(lblMoTaSP.Text, 20);
            lblTenSP.Text = TruncateText(lblTenSP.Text, 20);
        }

        private void picSua_Click(object sender, EventArgs e)
        {
            FChinhSuaSanPham f = new FChinhSuaSanPham(lblMaSP.Text);
            f.ShowDialog();
        }

        private void picXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (sqlcon = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.XoaMayTinh", sqlcon))
                    {
                        sqlcon.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma_may_tinh", lblMaSP.Text);
                        cmd.ExecuteNonQuery();
                        sqlcon.Close();
                    }
                }
                MessageBox.Show("Xóa thành công!");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi SQL: {sqlEx.Message}");
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show($"Lỗi định dạng dữ liệu: {formatEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
    }
}
