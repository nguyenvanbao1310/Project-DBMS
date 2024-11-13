using System;
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
    public partial class FChinhSuaSanPham : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        private string ma;
        public FChinhSuaSanPham(string ma)
        {
            InitializeComponent();
            this.ma = ma;
        }
        private DataTable LoadDuLieu()
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.XemChiTietMayTinh", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_may_tinh", ma);
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

        private void FChinhSuaSanPham_Load(object sender, EventArgs e)
        {
            DataTable sp = LoadDuLieu();
            foreach (DataRow dr in sp.Rows)
            {
                txtTenSP.Text = dr["ten_may_tinh"].ToString();
                txtManHinh.Text = dr["man_hinh"].ToString();
                txtCPU.Text = dr["cpu"].ToString();
                txtOCung.Text = dr["o_cung"].ToString();
                txtRAM.Text = dr["ram"].ToString();
                txtTrongLuong.Text = dr["trong_luong"].ToString();
                txtGiaTien.Text= dr["gia_tien"].ToString();
                NumericSL.Value = int.Parse(dr["ton_kho"].ToString());
                txtCardRoi.Text = dr["card_roi"].ToString();
                txtBaoHanh.Text = dr["bao_hanh"].ToString();
                txtMoTa.Text = dr["mo_ta"].ToString();
                byte[] imageData = dr["hinh_anh"] as byte[];

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        try
                        {
                            Image img = Image.FromStream(ms);
                            picAnh.Image = img;
                            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show("Không thể load được hình ảnh: " + ex.Message);
                        }
                    }
                }
            }
              
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // Kiểm tra định dạng dữ liệu
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
                    using (SqlCommand cmd = new SqlCommand("dbo.SuaMayTinh", conn))
                    {
                        conn.Open();
                        byte[] imgBytes = null;
                        if (picAnh.Image != null)
                        {
                            imgBytes = ConvertImageFromPictureBoxToBytes(picAnh.Image);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số
                        cmd.Parameters.AddWithValue("@ma_may_tinh", ma);
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
                        cmd.Parameters.AddWithValue("@hinh_anh", imgBytes);
                        cmd.ExecuteNonQuery();
                        conn.Close();
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
        public byte[] ConvertImageFromPictureBoxToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return ms.ToArray();
            }
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
