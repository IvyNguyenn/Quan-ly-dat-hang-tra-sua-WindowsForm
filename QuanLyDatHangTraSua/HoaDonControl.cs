using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDatHangTraSua
{
    public partial class HoaDonControl : UserControl
    {
        public HoaDonControl()
        {
            InitializeComponent();
        }

        public string LabelMaHoaDon
        {
            get { return label7.Text; }
            set { label7.Text = value; }
        }
        public string LabelKhachHang
        {
            get { return label8.Text; }
            set { label8.Text = value; }
        }
        public string LabelNgay
        {
            get { return label9.Text; }
            set { label9.Text = value; }
        }
        public string LabelTongTien
        {
            get { return label10.Text; }
            set { label10.Text = value; }
        }
        public string LabelTien
        {
            get { return label12.Text; }
            set { label12.Text = value; }
        }
        public ListView ListViewDrink
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        private void HoaDonControl_Load(object sender, EventArgs e)
        {

        }
    }
}
