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
    public partial class FGioHang : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        public FGioHang()
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
                using (SqlCommand cmd = new SqlCommand("dbo.XemGioHang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_khach_hang", Form1.matk);
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

        private void FGioHang_Load(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieu();
            flowPanel.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                UCGioHang uc = new UCGioHang();
                uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                uc.lblTenSP.Text= dr["ten_may_tinh"].ToString() ;
                uc.lblGiaTien.Text = dr["gia_tien"].ToString();
                uc.lblSoLuong.Text = dr["so_luong"].ToString();
                uc.Margin = new Padding(10);
                uc.CancelButtonClicked += XemSanPham;
                flowPanel.Controls.Add(uc);
            }
        }

        private void XemSanPham(object sender, EventArgs e)
        {
            var ls = sender as UCGioHang;
            if (ls != null)
            {
                DataTable dt = LoadDuLieuChiTiet(ls.lblMaSP.Text);
                foreach(DataRow dr in dt.Rows)
                {
                    txtTenMayTinh.Text = dr["ten_may_tinh"].ToString();
                    txtCPU.Text = dr["cpu"].ToString();
                    txtRAM.Text = dr["ram"].ToString();
                    txtOCung.Text = dr["o_cung"].ToString();
                    txtCardRoi.Text = dr["card_roi"].ToString();
                    txtManHinh.Text = dr["man_hinh"].ToString();
                    txtTrongLuong.Text = dr["trong_luong"].ToString();
                    txtGiaTien.Text = dr["gia_tien"].ToString() ;
                    txtBaoHanh.Text = dr["bao_hanh"].ToString();
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
        }
        private DataTable LoadDuLieuChiTiet(string ma)
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ma_may_tinh", typeof(string));
            dt.Columns.Add("ten_may_tinh", typeof(string));
            dt.Columns.Add("gia_tien", typeof(int));
            dt.Columns.Add("so_luong", typeof(int));

            // Duyệt qua các sản phẩm trong giỏ hàng
            foreach (Control control in flowPanel.Controls)
            {
                UCGioHang uc = control as UCGioHang;
                if (uc != null && uc.checkboxChon.Checked) // Nếu sản phẩm được chọn
                {
                    DataRow row = dt.NewRow();
                    row["ma_may_tinh"] = uc.lblMaSP.Text;
                    row["ten_may_tinh"] = uc.lblTenSP.Text;
                    row["gia_tien"] = uc.lblGiaTien.Text;
                    row["so_luong"] = uc.lblSoLuong.Text;
                    dt.Rows.Add(row);
                }
            }
            FThanhToan f = new FThanhToan(dt);
            f.ShowDialog();
        }
    }
}
