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
    public partial class FKhoKhuyenMai : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        public FKhoKhuyenMai()
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
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM View_DanhSachKhuyenMai", sqlcon))
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

        private void FKhoKhuyenMai_Load(object sender, EventArgs e)
        {
            DataTable sp = LoadDuLieu();
            flowPanel.Controls.Clear();
            List<UCKhuyenMai> usp = new List<UCKhuyenMai>();
            foreach (DataRow dr in sp.Rows)
            {
                UCKhuyenMai uc = new UCKhuyenMai();
                uc.lblMaKhuyenMai.Text = dr["ma_khuyen_mai"].ToString();
                uc.lblTenKhuyenMai.Text = dr["ten_khuyen_mai"].ToString();
                uc.lblMoTa.Text = dr["mo_ta"].ToString();
                uc.lblNgayBatDau.Text = Convert.ToDateTime(dr["ngay_bat_dau"]).ToString("MM/dd/yyyy");
                uc.lblNgayKetThuc.Text = Convert.ToDateTime(dr["ngay_ket_thuc"]).ToString("MM/dd/yyyy");
                uc.hiddenMoTa.Text = dr["mo_ta"].ToString();
                uc.CancelButtonClicked += XemChiTiet;
                if (dr["phan_tram_giam"] == DBNull.Value)
                {
                    uc.lblPhanTramGiam.Text = "Không có";
                }
                else
                {
                    uc.lblPhanTramGiam.Text = dr["phan_tram_giam"].ToString();
                }
                if (dr["so_tien_giam"] == DBNull.Value)
                {
                    uc.lblSoTienGiam.Text = "Không có";

                }
                else
                {
                    uc.lblSoTienGiam.Text = dr["so_tien_giam"].ToString();
                }
                usp.Add(uc);

            }
            foreach (UCKhuyenMai a in usp)
            {
                a.Margin = new Padding(0, 10, 0, 0);
                flowPanel.Controls.Add(a);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FTaoKhuyenMai f = new FTaoKhuyenMai();
            f.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FKhoKhuyenMai_Load(sender, e);
        }

        private void XemChiTiet(object sender, EventArgs e)
        {
            var ls = sender as UCKhuyenMai;
            if (ls != null)
            {
                
                FSuaKhuyenMai f = new FSuaKhuyenMai(ls);
                f.ShowDialog();
            }
        }
    }
}
