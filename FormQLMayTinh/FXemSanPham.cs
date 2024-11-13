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
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        private DataTable sp;
        public FXemSanPham(DataTable sp)
        {
            InitializeComponent();
            this.sp = sp;
        }



        private void FXemSanPham_Load(object sender, EventArgs e)
        {
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
            string luaChonGia = cboxTien.SelectedItem?.ToString();
            DataTable sp = LoadDuLieuTheoTimKiem(txtSearch.Text, luaChonGia);
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
        public DataTable LoadDuLieuTheoTimKiem(string tu, string luaChonGia)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Câu truy vấn sử dụng hàm TimKiemSanPham
                string query = "SELECT * FROM dbo.TimKiemSanPham(@tu_khoa, @gia_min, @gia_max)";

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    cmd.CommandType = CommandType.Text;

                    // Thêm từ khóa vào tham số
                    cmd.Parameters.AddWithValue("@tu_khoa", string.IsNullOrEmpty(tu) ? (object)DBNull.Value : tu);

                    // Thiết lập giá trị cho @gia_min và @gia_max dựa trên lựa chọn trong ComboBox
                    int? giaMin = null, giaMax = null;

                    switch (luaChonGia)
                    {
                        case "10 triệu < tiền < 20 triệu":
                            giaMin = 10000000;
                            giaMax = 20000000;
                            break;
                        case "20 triệu < tiền < 30 triệu":
                            giaMin = 20000000;
                            giaMax = 30000000;
                            break;
                        case "Trên 30 triệu":
                            giaMin = 30000000; // không cần gán giá tối thiểu
                            giaMax = null;
                            break;
                        default:
                            giaMin = null;
                            giaMax = null;
                            break;
                    }

                    // Kiểm tra và gán giá trị cho tham số giá min/max
                    cmd.Parameters.AddWithValue("@gia_min", giaMin.HasValue ? (object)giaMin.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@gia_max", giaMax.HasValue ? (object)giaMax.Value : DBNull.Value);

                    // Kiểm tra nếu tất cả các tham số đều là NULL
                    if (string.IsNullOrEmpty(tu) && giaMin == null && giaMax == null)
                    {
                        MessageBox.Show("Bạn muốn tìm sản phẩm thế nào?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return dt; // Trả về DataTable rỗng
                    }

                    // Thực hiện truy vấn và đổ dữ liệu vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi và hiển thị thông báo cho người dùng
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi hoàn thành
                sqlcon.Close();
            }

            return dt;

        }

        private void btnSoSanh_Click(object sender, EventArgs e)
        {
            FSoSanh2MayTinh f = new FSoSanh2MayTinh();
            f.ShowDialog();
        }

        private void btnBanChay_Click(object sender, EventArgs e)
        {
            DataTable sp = LoadCacSanPhamBanChay();
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
        public DataTable LoadCacSanPhamBanChay()
        {
            DataTable dt = new DataTable();
            SqlConnection sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.layCacSanPhamBanChayTrongThang", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Xác định đây là một stored procedure

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }

        private void btnGia_Click(object sender, EventArgs e)
        {
            bool isGiaTang = btnGia.Tag as bool? ?? true;

            string query = isGiaTang
                ? "SELECT * FROM View_MayTinh ORDER BY gia_tien ASC"
                : "SELECT * FROM View_MayTinh ORDER BY gia_tien DESC";

            LoadData(query);

            isGiaTang = !isGiaTang;
            btnGia.Tag = isGiaTang;

            btnGia.Text = isGiaTang ? "Giá tăng" : "Giá giảm";
        }
        private void LoadData(string query)
        {
            DataTable sp = getData(query);
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
                flowPanel.Controls.Add(uc);

            }
        }

        public DataTable getData(string query)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
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
    }





}
