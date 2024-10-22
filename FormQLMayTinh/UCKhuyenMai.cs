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
    public partial class UCKhuyenMai : UserControl
    {
        public UCKhuyenMai()
        {
            InitializeComponent();
        }

        private void UCKhuyenMai_Load(object sender, EventArgs e)
        {
            lblMoTa.Text = TruncateText(lblMoTa.Text, 15);
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
    }
}
