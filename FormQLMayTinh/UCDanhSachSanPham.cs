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
    public partial class UCDanhSachSanPham : UserControl
    {

        public UCDanhSachSanPham()
        {
            InitializeComponent();
        }

        public event EventHandler CancelButtonClicked;

        private string TruncateText(string text, int maxLength)
        {
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength) + "...";
            }
            else
            {
                return text;
            }
        }

        private void UCDanhSachSanPham_Load(object sender, EventArgs e)
        {
            lblMoTaSP.Text = TruncateText(lblMoTaSP.Text, 20);
            lblTenSP.Text = TruncateText(lblTenSP.Text, 20);
        }

        private void picSua_Click(object sender, EventArgs e)
        {
            FChinhSuaSanPham f = new FChinhSuaSanPham(lblMaSP.Text);
            f.ShowDialog();
        }

        private void picXoa_Click(object sender, EventArgs e)
        {
            CancelButtonClicked?.Invoke(this, EventArgs.Empty);
        }



       
    }
}
