using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FormQLMayTinh
{
    public partial class Form1 : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        public static string matk;
        public static string username;
        public static string password;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool check = CheckTaiKhoan(txtUserName.Text, txtPassword.Text);
            if (check)
            {
                username = txtUserName.Text;
                password = txtPassword.Text;
                matk = LayMaNguoiDung(txtUserName.Text, txtPassword.Text);
                if (matk == "admin")
                {
                    
                    FGiaoDienChuShop f = new FGiaoDienChuShop();
                    f.ShowDialog();
                    this.Hide();
                }
                else
                {
                    FGiaoDienKhachHang f = new FGiaoDienKhachHang();
                    f.ShowDialog();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
            }
        }

        private bool CheckTaiKhoan(string username, string password)
        {
            sqlcon = new SqlConnection(conStr);
            using (sqlcon)
            {
                try
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand("CheckTaiKhoan", sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@taikhoan", username);
                        cmd.Parameters.AddWithValue("@matkhau", password);

                        int trangThai = (int)cmd.ExecuteScalar();

                        return trangThai == 1;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message);
                    return false;
                }
            }
        }

        private string LayMaNguoiDung(string username, string password)
        {
            sqlcon = new SqlConnection(conStr);
            using (sqlcon)
            {
                try
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.LayMaNguoiDung", sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@tai_khoan", username);
                        cmd.Parameters.AddWithValue("@mat_khau", password);
                        return (string)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message);
                    return null;
                }
            }
        }

        private void lblDangKi_Click(object sender, EventArgs e)
        {
            FDangKi f = new FDangKi(); 
            f.ShowDialog();
        }
    }
}
