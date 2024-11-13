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
    public partial class FDangKi : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        private SqlConnection sqlcon = null;
        public FDangKi()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
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
                using (SqlCommand cmd = new SqlCommand("dbo.DangKi", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tai_khoan", txtTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@mat_khau", txtMatKhau.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@ten_khach_hang", txtTenNguoiDung.Text);
                    cmd.Parameters.AddWithValue("@dia_chi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@so_dien_thoai", txtSoDT.Text);
                    cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
        }
    }
}
