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
    public partial class FApDungKhuyenMaiVaoSanPham : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        private string ma;
        public static string maKM = null;
        public static string phanTram;
        public FApDungKhuyenMaiVaoSanPham(string ma)
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

                // Query to select from the table-valued function LayThongTinChiTietSanPham
                string query = "SELECT * FROM dbo.LayKhuyenMaiCuaKhachHangVaSanPham(@ma_khach_hang, @ma_may_tinh)";

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    // Set the function parameter
                    cmd.Parameters.AddWithValue("@ma_khach_hang", Form1.matk);

                    cmd.Parameters.AddWithValue("@ma_may_tinh", ma);

                    // Execute the query and fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Display any errors
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Close the connection
                sqlcon.Close();
            }

            return dt;


        }


        private void FApDungKhuyenMaiVaoSanPham_Load(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieu();
            flowPanel.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                

                if (Convert.ToDateTime(dr["ngay_ket_thuc"]) > DateTime.Now)
                {
                    UCSuDungKhuyenMai uc = new UCSuDungKhuyenMai();
                    maKM = dr["ma_khuyen_mai"].ToString();
                    uc.lblTenVoucher.Text = dr["ten_khuyen_mai"].ToString();
                    uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                    int phan_tram_giam = int.Parse(dr["phan_tram_giam"].ToString());
                    uc.lblPhanTramGiam.Text =phan_tram_giam.ToString();
                    uc.txtGiamTD.Text = "% giảm: " + phan_tram_giam.ToString();
                    uc.lblNgayHetHan.Text = Convert.ToDateTime(dr["ngay_ket_thuc"]).ToString("dd/MM/yyyy");
                    uc.CancelButtonClicked += DungVoucher;
                    if (phan_tram_giam >= 10 && phan_tram_giam < 15)
                    {
                        uc.pnl.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        uc.btnDung.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        uc.btnDung.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        uc.txtGiamTD.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        uc.txtGiamTD.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        uc.lblTenVoucher.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D86817");
                        uc.picLogo.Image = Image.FromFile("D://DBMS//MayTinhPic//sale.png");
                        uc.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (phan_tram_giam >= 15 && phan_tram_giam < 20)
                    {
                        uc.pnl.BorderColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        uc.btnDung.BorderColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        uc.btnDung.ForeColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        uc.txtGiamTD.BorderColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        uc.txtGiamTD.ForeColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        uc.lblTenVoucher.ForeColor = System.Drawing.ColorTranslator.FromHtml("#32E12E");
                        uc.picLogo.Image = Image.FromFile("D://DBMS//MayTinhPic//sale.png");
                        uc.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (phan_tram_giam >= 20)
                    {
                        uc.pnl.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        uc.btnDung.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        uc.btnDung.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        uc.txtGiamTD.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        uc.txtGiamTD.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        uc.lblTenVoucher.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D8173A");
                        uc.picLogo.Image = Image.FromFile("D://DBMS//MayTinhPic//gift.png");
                        uc.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    uc.Margin = new Padding(10);
                    flowPanel.Controls.Add(uc);
                }
            }
        }
        private void DungVoucher(object sender, EventArgs e)
        {
            var ls = sender as UCSuDungKhuyenMai;
            phanTram = ls.lblPhanTramGiam.Text;
            this.Hide();
        }
    }
}
