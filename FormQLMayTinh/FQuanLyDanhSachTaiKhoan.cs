﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLMayTinh
{
    public partial class FQuanLyDanhSachTaiKhoan : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;

        public FQuanLyDanhSachTaiKhoan()
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
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM View_ThongTinKhachHang", sqlcon))
                {
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

        private void FQuanLyDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            DataTable sp = LoadDuLieu();
            flowPanel.Controls.Clear();
            List<UCQuanLyTaiKhoan> usp = new List<UCQuanLyTaiKhoan>();
            foreach (DataRow dr in sp.Rows)
            {
                UCQuanLyTaiKhoan uc = new UCQuanLyTaiKhoan();
                uc.lblMaTaiKhoan.Text = dr["ma_khach_hang"].ToString();
                uc.lblTaiKhoan.Text = dr["tai_khoan"].ToString();
                uc.lblMatKhau.Text = dr["mat_khau"].ToString();
                uc.lblTenKhachHang.Text = dr["ten_khach_hang"].ToString();
                uc.lblEmail.Text = dr["email"].ToString();
                uc.lblSoDT.Text = dr["so_dien_thoai"].ToString();
                uc.lblDiaChi.Text = dr["dia_chi"].ToString();
                usp.Add(uc);

            }
            foreach (UCQuanLyTaiKhoan a in usp)
            {
                a.Margin = new Padding(10);
                flowPanel.Controls.Add(a);
            }
        }

        private void picTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text;
            DataTable sp = LoadDuLieuTheoTimKiem(tuKhoa);
            flowPanel.Controls.Clear();
            List<UCQuanLyTaiKhoan> usp = new List<UCQuanLyTaiKhoan>();
            foreach (DataRow dr in sp.Rows)
            {
                UCQuanLyTaiKhoan uc = new UCQuanLyTaiKhoan();
                uc.lblMaTaiKhoan.Text = dr["ma_khach_hang"].ToString();
                uc.lblTaiKhoan.Text = dr["tai_khoan"].ToString();
                uc.lblMatKhau.Text = dr["mat_khau"].ToString();
                uc.lblTenKhachHang.Text = dr["ten_khach_hang"].ToString();
                uc.lblEmail.Text = dr["email"].ToString();
                uc.lblSoDT.Text = dr["so_dien_thoai"].ToString();
                uc.lblDiaChi.Text = dr["dia_chi"].ToString();
                usp.Add(uc);

            }
            foreach (UCQuanLyTaiKhoan a in usp)
            {
                a.Margin = new Padding(10);
                flowPanel.Controls.Add(a);
            }

        }

        private DataTable LoadDuLieuTheoTimKiem(string tuKhoa)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Use SELECT statement to call the table-valued function
                string query = "SELECT * FROM dbo.TimTaiKhoanKhachHang(@tu_khoa)";

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    // Add parameter to function
                    cmd.Parameters.AddWithValue("@tu_khoa", (object)tuKhoa ?? DBNull.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }

            return dt;
        }

    }
}
