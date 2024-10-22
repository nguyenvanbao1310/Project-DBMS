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
    public partial class UCLichSuDonHang : UserControl
    {
        public UCLichSuDonHang()
        {
            InitializeComponent();
        }

        public event EventHandler CancelButtonClicked;



        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            CancelButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        
    }
}
