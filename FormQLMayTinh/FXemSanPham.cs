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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FormQLMayTinh
{
    public partial class FXemSanPham : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;

        public FXemSanPham()
        {
            InitializeComponent();
        }

        public DataTable LoadDuLieu()
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM View_MayTinh", sqlcon))
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

        private void FXemSanPham_Load(object sender, EventArgs e)
        {
            DataTable sp = LoadDuLieu();
            flowPanel.Controls.Clear();
            List<UCSanPham> usp = new List<UCSanPham>();
            foreach (DataRow dr in sp.Rows)
            {
                UCSanPham uc = new UCSanPham();
                uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                uc.lblTenSP.Text = dr["ten_may_tinh"].ToString();
                uc.lblGiaBan.Text = dr["gia_tien"].ToString();
                uc.lblGiaTien.Text = (int.Parse(uc.lblGiaBan.Text) * 1.2).ToString();
                byte[] imageData = dr["hinh_anh"] as byte[];

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        try
                        {
                            Image img = Image.FromStream(ms);
                            uc.picAnhSP.Image = img;
                            uc.picAnhSP.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show("Không thể tạo hình ảnh: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu hình ảnh.");
                }
                usp.Add(uc);
                
            }
            foreach (UCSanPham a in usp)
            {
                a.Margin = new Padding(10);
                flowPanel.Controls.Add(a);
            }
        }

        private void picTimKiem_Click(object sender, EventArgs e)
        {
            DataTable sp = LoadDuLieuTheoTimKiem(txtSearch.Text);
            flowPanel.Controls.Clear();
            List<UCSanPham> usp = new List<UCSanPham>();
            foreach (DataRow dr in sp.Rows)
            {
                UCSanPham uc = new UCSanPham();
                uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                uc.lblTenSP.Text = dr["ten_may_tinh"].ToString();
                uc.lblGiaBan.Text = dr["gia_tien"].ToString();
                uc.lblGiaTien.Text = (int.Parse(uc.lblGiaBan.Text) * 1.2).ToString();
                byte[] imageData = dr["hinh_anh"] as byte[];

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        try
                        {
                            Image img = Image.FromStream(ms);
                            uc.picAnhSP.Image = img;
                            uc.picAnhSP.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show("Không thể tạo hình ảnh: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu hình ảnh.");
                }
                usp.Add(uc);

            }
            foreach (UCSanPham a in usp)
            {
                a.Margin = new Padding(10);
                flowPanel.Controls.Add(a);
            }
        }
        public DataTable LoadDuLieuTheoTimKiem(string tu)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.TimKiemSanPham", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tu_khoa", tu);
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
    }



}
