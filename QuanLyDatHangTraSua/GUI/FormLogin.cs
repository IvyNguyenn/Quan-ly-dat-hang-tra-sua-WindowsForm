using QuanLyDatHangTraSua.BUS;
using QuanLyDatHangTraSua.DAO;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDatHangTraSua.GUI
{
    public partial class FormLogin : Form
    {
        string error;
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.txtbUsername.Text = "hoangvy";
            this.txtbPass.Text = "12345";
            if (BillBUS.Instance.checkAllBill(ref error) == false)
                MessageBox.Show(error);

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtbPass.UseSystemPasswordChar = false;
            else
                txtbPass.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string password = txtbPass.Text;
            if (Login(username, password))
            {
                FormMain f = new FormMain(username);
                f.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoạt mật khẩu", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát? ", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
            //Application.Exit();
        }
        private void btnResign_Click(object sender, EventArgs e)
        {
            FormAccountProfile f = new FormAccountProfile(new Account());
            f.Show();

        }
        
        #region Function 
        bool Login(string username, string password)
        {
            return AccountBUS.Instance.Login(username, password);
        }
        #endregion
        
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn thoát? ", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
        }

        
    }
}
