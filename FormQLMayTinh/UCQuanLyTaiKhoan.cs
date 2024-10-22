using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLMayTinh
{
    public partial class UCQuanLyTaiKhoan : UserControl
    {
        public UCQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

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

        private string DieuChinhEmail(string email)
        {
            string displayEmail = $"{email.Substring(0, 3)}...{email.Substring(email.Length - 3)}";


            return displayEmail;
        }

        private void UCQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            lblDiaChi.Text = TruncateText(lblDiaChi.Text, 10);
            lblEmail.Text = DieuChinhEmail(lblEmail.Text);
        }
    }
}
