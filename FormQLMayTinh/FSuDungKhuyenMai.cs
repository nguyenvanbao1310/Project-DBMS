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
    public partial class FSuDungKhuyenMai : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        public FSuDungKhuyenMai()
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
                using (SqlCommand cmd = new SqlCommand("dbo.LayThongTinKhuyenMai", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma_nguoi_dung", Form1.matk);
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

        private void FSuDungKhuyenMai_Load(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieu();
            flowPanel.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                UCSuDungKhuyenMai uc = new UCSuDungKhuyenMai();
                
                if (Convert.ToDateTime(dr["ngay_ket_thuc"]) > DateTime.Now)
                {
                    uc.lblTenVoucher.Text = dr["ten_khuyen_mai"].ToString();
                    uc.lblMaSP.Text = dr["ten_may_tinh"].ToString();
                    int phan_tram_giam = int.Parse(dr["phan_tram_giam"].ToString());
                    uc.txtGiamTD.Text = "% giảm: "+phan_tram_giam.ToString();
                    uc.lblNgayHetHan.Text = Convert.ToDateTime(dr["ngay_ket_thuc"]).ToString("dd/MM/yyyy");
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
    }
}
