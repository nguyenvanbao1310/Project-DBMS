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
    public partial class FThemSanPham : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        public FThemSanPham()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGiaTien.Text, out int giaTien) ||
            !int.TryParse(NumericSL.Text, out int soLuongTon) ||
            !float.TryParse(txtTrongLuong.Text, out float trongLuong))
            {
                MessageBox.Show("Vui lòng kiểm tra lại định dạng của giá tiền, số lượng tồn và trọng lượng.");
                return;
            }
 
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    conn.InfoMessage += (s, ev) =>
                    {
                        // Hiển thị thông báo từ SQL Server qua MessageBox
                        MessageBox.Show("SQL Server Message: " + ev.Message, "Thông báo từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };
  
                    using (SqlCommand cmd = new SqlCommand("dbo.ThemMayTinh", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số
                        cmd.Parameters.AddWithValue("@ten_may_tinh", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@mo_ta", txtMoTa.Text);
                        cmd.Parameters.AddWithValue("@gia_tien", int.Parse(txtGiaTien.Text));
                        cmd.Parameters.AddWithValue("@ton_kho", int.Parse(NumericSL.Text));
                        cmd.Parameters.AddWithValue("@cpu", txtCPU.Text);
                        cmd.Parameters.AddWithValue("@ram", txtRAM.Text);
                        cmd.Parameters.AddWithValue("@o_cung", txtOCung.Text);
                        cmd.Parameters.AddWithValue("@card_roi", txtCardRoi.Text);
                        cmd.Parameters.AddWithValue("@man_hinh", txtManHinh.Text);
                        cmd.Parameters.AddWithValue("@trong_luong", float.Parse(txtTrongLuong.Text));
                        cmd.Parameters.AddWithValue("@nam_san_suat", dtpNamSanXuat.Value.Year);
                        cmd.Parameters.AddWithValue("@bao_hanh", txtBaoHanh.Text);
                        cmd.Parameters.AddWithValue("@duong_dan", txtFileAnh.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Xử lý lỗi SQL
                MessageBox.Show($"Lỗi SQL: {sqlEx.Message}");
            }
            catch (FormatException formatEx)
            {
                // Xử lý lỗi định dạng dữ liệu
                MessageBox.Show($"Lỗi định dạng dữ liệu: {formatEx.Message}");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
        private byte[] ConvertImageToByteArray(string imagePath)
        {
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    return br.ReadBytes((int)fs.Length);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblThemAnh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; 
            openFileDialog.Title = "Chọn hình ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu đường dẫn tệp đã chọn
                txtFileAnh.Text = openFileDialog.FileName;

                // Hiển thị hình ảnh trong PictureBox
                picAnh.Image = Image.FromFile(txtFileAnh.Text);
                picAnh.SizeMode = PictureBoxSizeMode.Zoom; 
            }
        }
    }
}
