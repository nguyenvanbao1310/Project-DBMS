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
    public partial class FQuanLyThongTinCaNhan : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        private SqlConnection sqlcon = null;

        public FQuanLyThongTinCaNhan()
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
                using (SqlCommand cmd = new SqlCommand("dbo.ThongTinCaNhan", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_nguoi_dung", Form1.matk);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
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
            return dt;

        }

        private void FQuanLyThongTinCaNhan_Load(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieu();
            foreach (DataRow dr in dt.Rows)
            {
                txtHoVaTen.Text = dr["ten_khach_hang"].ToString();
                txtEmail.Text = dr["email"].ToString();
                txtDiaChi01.Text = dr["dia_chi"].ToString();
                txtSDT.Text = dr["so_dien_thoai"].ToString();
                txtTenDangNhap.Text = dr["tai_khoan"].ToString();
                txtMatKhau.Text = dr["mat_khau"].ToString();
                txtTenNguoiNhan01.Text = dr["ten_khach_hang"].ToString();
                txtSoDT01.Text = dr["email"].ToString();
            }
        }
    }
}
