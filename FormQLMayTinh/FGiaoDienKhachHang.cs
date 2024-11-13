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
    public partial class FGiaoDienKhachHang : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        private SqlConnection sqlcon = null;
        private Form current;
        public FGiaoDienKhachHang()
        {
            InitializeComponent();
        }
        private void OpenForm(Form child)
        {
            if (current != null)
            {
                current.Close();
            }
            current = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            pnlChuyenTiep.Controls.Add(child);
            pnlChuyenTiep.Tag = child;
            child.BringToFront();
            child.Show();
        }


        private void btnThongTin_Click(object sender, EventArgs e)
        {

            FQuanLyThongTinCaNhan f = new FQuanLyThongTinCaNhan();
            OpenForm(f);
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            FGioHang f = new FGioHang();
            OpenForm(f);
        }

        private void btnKhoVouCher_Click(object sender, EventArgs e)
        {
           FSuDungKhuyenMai f = new FSuDungKhuyenMai();
            OpenForm(f);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            FLichSuDonHang f = new FLichSuDonHang();
            OpenForm(f);
        }

        private void btnLaptop_Click(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieu();
            FXemSanPham f = new FXemSanPham(dt);
            OpenForm(f);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void btnUuChuong_Click(object sender, EventArgs e)
        {
            DataTable dt = LoadDuLieuUuChuong();
            FXemSanPham f = new FXemSanPham(dt);
            OpenForm(f);
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

        public DataTable LoadDuLieuUuChuong()
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetMayTinhTheoSoSaoTrungBinh", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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

        private void FGiaoDienKhachHang_Load(object sender, EventArgs e)
        {
            
        }
    }
}
