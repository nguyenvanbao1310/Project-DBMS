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
    public partial class UCGioHang : UserControl
    {
        public UCGioHang()
        {
            InitializeComponent();
        }
        public event EventHandler CancelButtonClicked;


        private void btnMore_Click(object sender, EventArgs e)
        {
            CancelButtonClicked?.Invoke(this, EventArgs.Empty);
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

        private void UCGioHang_Load(object sender, EventArgs e)
        {
            lblTenSP.Text = TruncateText(lblTenSP.Text, 10);
        }
    }
}
