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
    public partial class MyComboBox : UserControl
    {
        public MyComboBox()
        {
            InitializeComponent();
        }
        public Image ImageIcon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public ComboBox ComboBox
        {
            get { return comboBox1; }
            set { comboBox1 = value; }
        }
    }
}
