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
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        private string ma;
        public static int phanTram = 100;
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
                using (SqlCommand cmd = new SqlCommand("dbo.ApDungKhuyenMaiVaoSanPham", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_nguoi_dung", Form1.matk);
                    cmd.Parameters.AddWithValue("@ma_may_tinh", ma);
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


        private void FApDungKhuyenMaiVaoSanPham_Load(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieu();
            flowPanel.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                

                if (Convert.ToDateTime(dr["ngay_ket_thuc"]) > DateTime.Now)
                {
                    UCSuDungKhuyenMai uc = new UCSuDungKhuyenMai();
                    uc.lblTenVoucher.Text = dr["ten_khuyen_mai"].ToString();
                    uc.lblTenSanPham.Text = dr["ten_may_tinh"].ToString();
                    int phan_tram_giam = int.Parse(dr["phan_tram_giam"].ToString());
                    uc.lblPhanTramGiam.Text = (100 - phan_tram_giam).ToString();
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
            phanTram = int.Parse(ls.lblPhanTramGiam.Text);
            this.Hide();
        }
    }
}
