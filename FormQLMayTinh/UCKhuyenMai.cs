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
        public Label hiddenMoTa;
        public UCKhuyenMai()
        {
            InitializeComponent();
            hiddenMoTa = new Label();
            hiddenMoTa.AutoSize = true;
        }

        public event EventHandler CancelButtonClicked;

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

        private void lblMaKhuyenMai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
