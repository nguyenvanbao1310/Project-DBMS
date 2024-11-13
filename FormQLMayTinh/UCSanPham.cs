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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FormQLMayTinh
{
    public partial class UCSanPham : UserControl
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        public UCSanPham()
        {
            InitializeComponent();
        }

        private void UCSanPham_Load(object sender, EventArgs e)
        {
            lblTenSP.Text = TruncateText(lblTenSP.Text, 10);
        }
        private string TruncateText(string text, int maxLength)
        {
            // Nếu độ dài của văn bản lớn hơn maxLength, cắt nó và thêm dấu ba chấm
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength) + "...";
            }
            else
            {
                return text;
            }
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn với sự lựa chọn này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               
                ThemSanPhamVaoGioHang(lblMaSP.Text);
            }


        }

       
        private void ThemSanPhamVaoGioHang(string ma)
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
                using (SqlCommand cmd = new SqlCommand("dbo.ThemVaoGioHang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khach_hang", Form1.matk);
                    cmd.Parameters.AddWithValue("@ma_may_tinh", ma);
                    cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
        }

        private void picChiTiet_Click(object sender, EventArgs e)
        {
            FXemChiTietSanPham f = new FXemChiTietSanPham(lblMaSP.Text);
            f.ShowDialog();
        }
    }
}
