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
    public partial class FHuyDonHang : Form
    {
        private UCLichSuDonHang uc;
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        public FHuyDonHang(UCLichSuDonHang uc)
        {
            InitializeComponent();
            this.uc = uc;
        }

        private void btnXacNhanTT_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn với sự lựa chọn này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                sqlcon = new SqlConnection(conStr);
                try
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.CapNhatTrangThaiDonHang", sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma_don_hang", uc.lblDonHang.Text);
                        cmd.Parameters.AddWithValue("@trang_thai",3);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Hủy đơn hàng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Hide();
        }
    }
}
