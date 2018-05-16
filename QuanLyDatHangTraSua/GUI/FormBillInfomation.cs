using QuanLyDatHangTraSua.BUS;
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
    public partial class FormBillInfomation : Form
    {
        Account account = null;
        List<Bill> listBill = new List<Bill>();
        string error;
        public FormBillInfomation(Account acc)
        {
            InitializeComponent();
            this.account = acc;
        }

        private void FormBillInfomation_Load(object sender, EventArgs e)
        {
            loadListBill();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                Bill bill = listBill[r];
                if (BillBUS.Instance.payedBill(bill, ref error))
                {
                    MessageBox.Show("Thanh toán đơn hàng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadListBill();
                }
                else
                    MessageBox.Show("Không thanh toán được !\n " + error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thanh toán được !\n " + ex.Message + ", " + error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc hủy không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    int r = dataGridView1.CurrentCell.RowIndex;
                    Bill bill = listBill[r];
                    if (BillBUS.Instance.deleteBill(bill, ref error))
                    {
                        MessageBox.Show("Hủy đơn hàng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThanhToan.Enabled = false;
                        loadListBill();
                    }
                    else
                        MessageBox.Show("Không hủy được !\n " + error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không hủy được !\n " + ex.Message + ", " + error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Thông báo
                MessageBox.Show("Không hủy đơn hàng này !", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
        private void loadListBill()
        {
            listBill = BillBUS.Instance.loadBillListByUserId(account.Id);
            dataGridView1.DataSource = listBill;
        }

        
    }
}
