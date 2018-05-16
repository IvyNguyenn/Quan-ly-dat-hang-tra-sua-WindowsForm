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
    public partial class PropertiesControl : UserControl
    {
        public PropertiesControl()
        {
            InitializeComponent();
        }

        public Image ImageIcon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public string Tittle
        {
            get { return labelTittle.Text; }
            set { labelTittle.Text = value; }
        }

        public TextBox Content
        {
            get { return textboxname; }
            set { textboxname = value; }
        }
    }
}
