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
    public partial class FQuanLySanPham : Form
    {
        private String conStr = "Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;Integrated Security=True";
        SqlConnection sqlcon = null;
        public FQuanLySanPham()
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

        private void FQuanLySanPham_Load(object sender, EventArgs e)
        {
            DataTable sp = LoadDuLieu();
            flowPanel.Controls.Clear();
            List<UCDanhSachSanPham> usp = new List<UCDanhSachSanPham>();
            foreach (DataRow dr in sp.Rows)
            {
                UCDanhSachSanPham uc = new UCDanhSachSanPham();
                uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                uc.lblTenSP.Text = dr["ten_may_tinh"].ToString();
                uc.lblGiaTien.Text = dr["gia_tien"].ToString();
                uc.lblMoTaSP.Text = dr["mo_ta"].ToString();
                uc.lblTonKho.Text = dr["ton_kho"].ToString();
                uc.lblBaoHanh.Text = dr["bao_hanh"].ToString();
                usp.Add(uc);
            }
            foreach (UCDanhSachSanPham a in usp)
            {
                a.Margin = new Padding(10);
                flowPanel.Controls.Add(a);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FThemSanPham f = new FThemSanPham();
            f.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FQuanLySanPham_Load(sender, e);
        }

        private void picTimKiem_Click(object sender, EventArgs e)
        {
            DataTable sp = LoadDuLieuTheoTimKiem(txtTimKiem.Text);
            flowPanel.Controls.Clear();
            List<UCDanhSachSanPham> usp = new List<UCDanhSachSanPham>();
            foreach (DataRow dr in sp.Rows)
            {
                UCDanhSachSanPham uc = new UCDanhSachSanPham();
                uc.lblMaSP.Text = dr["ma_may_tinh"].ToString();
                uc.lblTenSP.Text = dr["ten_may_tinh"].ToString();
                uc.lblGiaTien.Text = dr["gia_tien"].ToString();
                uc.lblMoTaSP.Text = dr["mo_ta"].ToString();
                uc.lblTonKho.Text = dr["ton_kho"].ToString();
                uc.lblBaoHanh.Text = dr["bao_hanh"].ToString();
                usp.Add(uc);
            }
            foreach (UCDanhSachSanPham a in usp)
            {
                a.Margin = new Padding(10);
                flowPanel.Controls.Add(a);
            }
        }
        private DataTable LoadDuLieuTheoTimKiem(string tu)
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
