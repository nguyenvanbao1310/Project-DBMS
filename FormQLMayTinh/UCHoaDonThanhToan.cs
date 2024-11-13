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
    public partial class UCHoaDonThanhToan : UserControl
    {
        public UCHoaDonThanhToan()
        {
            InitializeComponent();
        }
        public event EventHandler CancelButtonClicked;
        public event EventHandler CancelButtonClicked1;



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

        private void picXoa_Click(object sender, EventArgs e)
        {
            CancelButtonClicked1?.Invoke(this, EventArgs.Empty);

        }

        private void UCHoaDonThanhToan_Load(object sender, EventArgs e)
        {
            lblTenSP.Text = TruncateText(lblTenSP.Text, 15);
        }

        private void linkchon_Click(object sender, EventArgs e)
        {
            CancelButtonClicked?.Invoke(this, EventArgs.Empty);
        }

       
    }
}
