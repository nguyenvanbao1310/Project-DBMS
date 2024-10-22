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
    public partial class FXemChiTietSanPham : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        private string ma;
        public FXemChiTietSanPham(string ma)
        {
            InitializeComponent();
            this.ma = ma;
        }

        private void FXemChiTietSanPham_Load(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieu();
            foreach (DataRow dr in dt.Rows)
            {
                txtMaSP.Text = dr["ma_may_tinh"].ToString();
                txtTenSP.Text = dr["ten_may_tinh"].ToString();
                txtLoaiSP.Text = "Máy tính";
                txtManHinh.Text = dr["man_hinh"].ToString();
                txtCPU.Text = dr["cpu"].ToString();
                txtOCung.Text = dr["o_cung"].ToString();
                txtRAM.Text = dr["ram"].ToString();
                txtTrongLuong.Text = dr["trong_luong"].ToString();
                txtNamSanXuat.Text = dr["nam_san_suat"].ToString();
                txtGiaTien.Text = dr["gia_tien"].ToString();
                txtSoLuong.Text = dr["ton_kho"].ToString();
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
                            picAnhSP.Image = img;
                            picAnhSP.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show("Không thể load được hình ảnh: " + ex.Message);
                        }
                    }
                }

            }
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

        private void picQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
