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
    public partial class FormAccountProfile : Form
    {
        private Account account;
        string error;
        bool isResign = false;
        public FormAccountProfile(Account acc)
        {
            InitializeComponent();
            this.Account = acc;
            if (acc.UserName == null) isResign = true;
            groupBox1.Enabled = false;
        }

        public Account Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
                ChangeAccount(account);
            }
        }
        void ChangeAccount(Account acc)
        {
            txtusername.Text = Account.UserName;
            txtHoTen.Text = Account.Hoten;
            txtDate.Text = Account.Ngaysinh.ToShortDateString();
            txtPhone.Text = Account.Sdt;
            txtAddress.Text = Account.Diachi;
        }
        void UpdateAccountInfo()
        {
            string username = txtusername.Text;
            string hoten = txtHoTen.Text;
            string date = txtDate.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string password = txtPass.Text;
            string newpass = txtNewPass.Text;
            string renewpass = txtReNewPass.Text;
            

            if (username == "" || password == "" || hoten == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }
            

            if (isResign)
            {
                try
                {
                    Account Account = new Account(1, username, password , hoten, DateTime.Parse(date), phone, address, 2);
                    if (AccountBUS.Instance.insertAccount(Account, ref error))
                    {
                        MessageBox.Show("Thêm tài khoảng thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //isResign = false;
                        this.Close();
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                return;
            }       
            if (AccountBUS.Instance.MD5password(password) != account.PassWord)
            {
                MessageBox.Show("Mật khẩu cũ chưa đúng", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            if (!newpass.Equals(renewpass))
            {
                MessageBox.Show("Mật khẩu mới chưa trùng", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            if (newpass == "")
            {
                newpass = password;
            }
            
            account.UserName = username;
            account.PassWord = newpass;
            account.Hoten = hoten;
            account.Ngaysinh = DateTime.Parse(date);
            account.Sdt = phone;
            account.Diachi = address;

            if (AccountBUS.Instance.resetPass(new Account(account.Id,account.UserName,account.PassWord,
                account.Hoten,account.Ngaysinh,account.Sdt,account.Diachi,account.Role), ref error))
            {
                MessageBox.Show("Cập Nhật Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                //if (updateAccount != null)
                //    updateAccount(this, new AccountEvent(AccountDAO.Instance.getAccountByUserName(username)));
            }
            else
            {
                MessageBox.Show("Vui lòng điền đúng mật khẩu", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            if (updateAccount != null)
                updateAccount(this, new AccountEvent(AccountDAO.Instance.getAccountByUserName(username)));
        }
        private event EventHandler<AccountEvent> updateAccount;

        public event EventHandler<AccountEvent> UpdatAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAccountProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();

        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (groupBox1.Enabled)
                groupBox1.Enabled = false;
            else
                groupBox1.Enabled = true;
        }
    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get
            {
                return acc;
            }

            set
            {
                acc = value;
            }
        }
        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}

