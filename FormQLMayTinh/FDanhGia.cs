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
    public partial class FDanhGia : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        private string maMT;
        public FDanhGia(string maMT)
        {
            InitializeComponent();
            this.maMT = maMT;
        }

        private void FDanhGia_Load(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieu();
            if(dt != null && dt.Rows.Count > 0)
            {
                panel.Controls.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    UCDanhGia uc = new UCDanhGia();
                    uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                    uc.lblNgayDanhGia.Text = Convert.ToDateTime(dr["ngay_danh_gia"]).ToString("dd/MM/yyyy");
                    uc.lblMaKH.Text = dr["ma_khach_hang"].ToString();
                    uc.lblSoSao.Text = dr["so_sao_danh_gia"].ToString();
                    uc.lblNoiDung.Text = dr["noi_dung"].ToString();
                    byte[] imageData = dr["hinh_anh"] as byte[];

                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            try
                            {
                                Image img = Image.FromStream(ms);
                                uc.picHinhAnh.Image = img;
                                uc.picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show("Không thể load được hình ảnh: " + ex.Message);
                            }
                        }
                    }
                    uc.Margin = new Padding(10);
                    panel.Controls.Add(uc);
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
                using (SqlCommand cmd = new SqlCommand("dbo.XemDanhGia1SanPham", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_may_tinh", maMT);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            finally
            {
                sqlcon.Close();
            }
            return dt;

        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            this.Hide();
            FGhiDanhGia f = new FGhiDanhGia();
            f.ShowDialog();
            
        }
    }
}
