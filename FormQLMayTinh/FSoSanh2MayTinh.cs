using Guna.UI2.WinForms;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DrawingImage = System.Drawing.Image;

namespace FormQLMayTinh
{
    public partial class FSoSanh2MayTinh : Form
    {
        private String conStr = $"Data Source=LAPTOP-76436L4E\\SQLEXPRESS;Initial Catalog=ShopMayTinh;User ID={Form1.username};Password={Form1.password};";
        SqlConnection sqlcon = null;
        private DataTable dt1;
        private DataTable dt2;

        public FSoSanh2MayTinh()
        {
            InitializeComponent();
        }



        private void FSoSanh2MayTinh_Load(object sender, EventArgs e)
        {
            LoadTenMayTinh(cboxSanPham1);
            LoadTenMayTinh(cboxSanPham2);

        }
        private void LoadTenMayTinh(ComboBox cb)
        {
            cb.Items.Clear();
            sqlcon = new SqlConnection(conStr);
            try
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM View_MayTinh", sqlcon))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string tenMT = reader["ten_may_tinh"].ToString();
                        cb.Items.Add(tenMT);
                    }
                    reader.Close();
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
        }
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {

                e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold);
                if (e.Value.ToString() == "↑")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Green; 
                }
                else if (e.Value.ToString() == "↓")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red; 
                }
                else if (e.Value.ToString() == "=")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Gold; 
                }
            }
        }

        private void cboxSanPham1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = cboxSanPham1.Text;
            LoadTimKiem(text, cboxSanPham1);
        }

        private void cboxSanPham2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = cboxSanPham2.Text;
            LoadTimKiem(text, cboxSanPham2);
        }

        private void LoadTimKiem(string searchText, ComboBox comboBox)
        {
            using (sqlcon = new SqlConnection(conStr))
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ten_may_tinh FROM dbo.TimKiemTenMayTinh(@tu_khoa)", sqlcon))
                {
                    cmd.Parameters.AddWithValue("@tu_khoa", searchText);
                    List<string> TenSP = new List<string>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TenSP.Add(reader["ten_may_tinh"].ToString());
                        }
                    }

                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(TenSP.ToArray());
                }
            }

            comboBox.Text = searchText;  // Đảm bảo văn bản nhập vào vẫn được giữ
            comboBox.SelectionStart = searchText.Length;
            comboBox.SelectionLength = 0;  // Đảm bảo không có văn bản nào bị chọn
        }

        private void cboxSanPham1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tuKhoa = cboxSanPham1.Text;
            dt1 = LayDuLieuMT(tuKhoa);
            foreach (DataRow dr in dt1.Rows)
            {
                lblMaMT1.Text = dr["ma_may_tinh"].ToString();
                lblTenMayTinh1.Text = dr["ten_may_tinh"].ToString();   
                lblGiaTien1.Text = dr["gia_tien"].ToString();
                byte[] imageData = dr["hinh_anh"] as byte[];

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        try
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);  // Chỉ rõ namespace
                            picAnhMT1.Image = img;
                            picAnhMT1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show("Không thể load được hình ảnh: " + ex.Message);
                        }
                    }
                }
            }

        }

        private void cboxSanPham2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tuKhoa = cboxSanPham2.Text;
            dt2 = LayDuLieuMT(tuKhoa);
            foreach (DataRow dr in dt2.Rows)
            {
                lblMaMT2.Text = dr["ma_may_tinh"].ToString();
                lblTenMayTinh2.Text = dr["ten_may_tinh"].ToString();
                lblGiaTien2.Text = dr["gia_tien"].ToString();
                byte[] imageData = dr["hinh_anh"] as byte[];

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        try
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);  // Chỉ rõ namespace
                            picAnhMT2.Image = img;
                            picAnhMT2.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show("Không thể load được hình ảnh: " + ex.Message);
                        }
                    }
                }
            }
        }

        private DataTable LayDuLieuMT(string tuKhoa)
        {
            DataTable dt = new DataTable();
            sqlcon = new SqlConnection(conStr);

            try
            {
                sqlcon.Open();

                // Use SELECT statement to access the table-valued function
                string query = "SELECT * FROM dbo.TimKiemSanPhamChoChu(@tu_khoa)";

                using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                {
                    // Add parameter to function
                    cmd.Parameters.AddWithValue("@tu_khoa", (object)tuKhoa ?? DBNull.Value);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }

        private DataTable LoadThongTinSoSanh(string ma1, string ma2)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(conStr))
            {
                try
                {
                   
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.SoSanh2LapTop", sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma1", ma1);
                        cmd.Parameters.AddWithValue("@ma2", ma2);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL Server Message: " + ex.Message);

                }
                finally
                {
                    sqlcon.Close();

                }
            }
            return dt;
        }


        private void btnSoSanh_Click(object sender, EventArgs e)
        {
            DataTable dtSoSanh = LoadThongTinSoSanh(lblMaMT1.Text, lblMaMT2.Text);
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("Criterion", "Tiêu chí");
            dataGridView.Columns.Add("Laptop1", "Laptop 1");
            dataGridView.Columns.Add("Comparison", "So sánh");
            dataGridView.Columns.Add("Laptop2", "Laptop 2");

            if (dt1 != null && dt2 != null && dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && dtSoSanh.Rows.Count > 0)
            {
                DataRow row1 = dt1.Rows[0];
                DataRow row2 = dt2.Rows[0];
                DataRow soSanhRow = dtSoSanh.Rows[0];

                // Thêm các hàng vào DataGridView dựa trên các cột
                dataGridView.Rows.Add("Tên sản phẩm", row1["ten_may_tinh"], "", row2["ten_may_tinh"]);
                dataGridView.Rows.Add("Giá", row1["gia_tien"], soSanhRow["SoSanhGia"], row2["gia_tien"]);
                dataGridView.Rows.Add("RAM", row1["ram"], soSanhRow["SoSanhRam"], row2["ram"]);
                dataGridView.Rows.Add("Card đồ họa", row1["card_roi"], soSanhRow["SoSanhGpu"], row2["card_roi"]);
                dataGridView.Rows.Add("Trọng lượng", row1["trong_luong"], soSanhRow["SoSanhTrongLuong"], row2["trong_luong"]);
                dataGridView.Rows.Add("CPU", row1["cpu"], soSanhRow["SoSanhCPU"], row2["cpu"]);
                dataGridView.Rows.Add("Ổ cứng", row1["o_cung"], soSanhRow["SoSanhOCung"], row2["o_cung"]);
                dataGridView.Rows.Add("Màn hình", row1["man_hinh"], soSanhRow["SoSanhManHinh"], row2["man_hinh"]);
                dataGridView.CellFormatting += DataGridView_CellFormatting;
            }
            else
            {
                return;
            }    
            
        }
    }
}
