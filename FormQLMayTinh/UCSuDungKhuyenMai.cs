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
    public partial class UCSuDungKhuyenMai : UserControl
    {
        public UCSuDungKhuyenMai()
        {
            InitializeComponent();
        }
        public event EventHandler CancelButtonClicked;

        private void btnDung_Click(object sender, EventArgs e)
        {
            CancelButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
