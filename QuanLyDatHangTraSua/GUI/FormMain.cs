using QuanLyDatHangTraSua.BUS;
using QuanLyDatHangTraSua.DAO;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDatHangTraSua.GUI
{
    public partial class FormMain : Form
    {
        #region Declare
        Account account;// = new Account(1,"Nguyen Van An","12345","Nguyễn Văn An",new DateTime(1997,3,25), "0958741114","89 Lê Văn Việt", 1);
        CultureInfo culture = new CultureInfo("vi-VN");
        List<Combo> listCombo = new List<Combo>();
        List<Topping> listTopping = new List<Topping>();
        Drink drink = null;
        Topping topping = null;
        Bill bill = null;
        string error;
        string username;
        int subPrice = 0, tolTalPrice = 0;
        #endregion

        public FormMain(string name)
        {
            InitializeComponent();
            this.username = name;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            account = AccountBUS.Instance.getAccountByUserName(username);
            if (account == null)
            {
                MessageBox.Show("Fail");
                this.Close();
                return;
            }
            if (AccountDAO.Instance.isAdmin(ref error))
            {
                navbtnAdmin.Enabled = true;
                navbtnAdmin.Caption = "Admin";
            }
            else
            {
                navbtnAdmin.Enabled = false;
                navbtnAdmin.Caption = "Khách hàng:  " + account.Hoten;
            }
            
            reStart();
            loadListView();
        }
        
        #region Function
        private void loadListLoaiThucUong()
        {
            List<Category> listCategory = CategoryBUS.Instance.getListCategory();
            cbLoaiThucUong.DataSource = listCategory;
            cbLoaiThucUong.DisplayMember = "name";
        }

        private void loadListThucUongByLoaiThucUongId()
        {
            cbThucUong.DisplayMember = "name";
            Category selected = cbLoaiThucUong.SelectedItem as Category;
            cbThucUong.DataSource = DrinkBUS.Instance.getListDrinkByCategoryId(selected.Id);

        }

        private void loadListTopping()
        {
            List<Topping> listTopping = ToppingBUS.Instance.getListTopping();
            listTopping.Insert(0,new Topping(0,"<None>",0,null));
            cbTopping.DisplayMember = "name";
            cbTopping.DataSource = listTopping;
            
        }

        private void tinhTien()
        {
            subPrice = drink.Price;
            foreach(Topping t in listTopping)
            {
                subPrice += t.Price;
            }
            subPrice *= (int)numericUpDownCountOrder.Value;
            txtPrice.Text = subPrice.ToString("c", culture);
        }

        private void reStart()
        {
            loadListLoaiThucUong();
            loadListThucUongByLoaiThucUongId();
            loadListTopping();
            drink = cbThucUong.SelectedItem as Drink;
            topping = cbTopping.SelectedItem as Topping;
            numericUpDownCountOrder.Value = 1;
            listTopping = new List<Topping>();
            btnAddOrder.Focus();
            btnThanhToan.Enabled = false;
            btnDatHang.Enabled = true;
        }

        private void loadListView()
        {
            drink = cbThucUong.SelectedItem as Drink;
            int count = (int)numericUpDownCountOrder.Value;
            listCombo = ComboBUS.Instance.loadListCombo(account.Id,ref tolTalPrice);
            listView1.Items.Clear();
            cbTopping2.DataSource = null;
            foreach (Combo com in listCombo)
            {
                ListViewItem lvitem = new ListViewItem();
                lvitem.Text = com.IdOrder.ToString();
                string s = "";
                foreach (Topping t in com.ListTopping)
                {
                    s = s + t.Name + ", ";
                }
                lvitem.SubItems.Add(com.Drink.Name);
                lvitem.SubItems.Add(s);
                lvitem.SubItems.Add(com.Count.ToString());
                lvitem.SubItems.Add(com.Price.ToString("c", culture));
                listView1.Items.Add(lvitem);
            }
            txttotalprice.Text = tolTalPrice.ToString("c", culture);
            reStart();
        }
        private void binddingComboBox()
        {
            cbTopping2.DataSource = null;
            cbTopping2.DataSource = listTopping;
            cbTopping2.DisplayMember = "name";
            
        }
        #endregion

        #region Event
        
        private void cbLoaiThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadListThucUongByLoaiThucUongId();
            subPrice = 0;
            tinhTien();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            int count = (int)numericUpDownCountOrder.Value;
            if (OrderBUS.Instance.themOrder(new Order(1, drink.Id, subPrice, null), listTopping,account,count,ref error))
            {
                //MessageBox.Show("Đã thêm");
            }
            else
            {
                MessageBox.Show("Không thêm được! ", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            loadListView();
        }

        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                for(int i=0;i<listView1.Items.Count;i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        DialogResult traloi;
                        traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        // Kiểm tra có nhắp chọn nút Ok không?
                        if (traloi == DialogResult.Yes)
                        {
                            if (CartBUS.Instance.deleteCart(int.Parse(listView1.Items[i].Text), ref error))
                            {
                                loadListView();
                                MessageBox.Show("Xóa thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                            else
                                MessageBox.Show("Không xóa được !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            // Thông báo
                            MessageBox.Show("Không thực hiện việc xóa !","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được. \n"+ex.Message,"Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                bill = BillBUS.Instance.getLastBill(account.Id);
                if (BillBUS.Instance.payedBill(bill, ref error))
                {
                    MessageBox.Show("Thanh toán đơn hàng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listCombo.Clear();
                    btnThanhToan.Enabled = false;
                    btnDatHang.Enabled = true;
                    tolTalPrice = 0;
                    listView1.Items.Clear();
                }
                else
                    MessageBox.Show("Không thanh toán được !\n " + error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thanh toán được !\n " + ex.Message + ", " + error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            txttotalprice.Text = tolTalPrice.ToString("c", culture);
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nước!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    //bill = new Bill(1, account.Id, DateTime.Now, tolTalPrice);
                    //BillBUS.Instance.insertBill(bill, ref error);
                    //bill = BillBUS.Instance.getLastBill();
                    //OrderBUS.Instance.addOrder(bill, listCombo, account, ref error);

                    
                    BillBUS.Instance.insertBill(new Bill(1, account.Id, DateTime.Now, tolTalPrice,"Đã đặt"), ref error);

                    MessageBox.Show("Đặt hàng thành công!\n\n Vui lòng thanh toán", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnThanhToan.Enabled = true;
                    btnDatHang.Enabled = false;
                    listCombo.Clear();
                    listTopping.Clear();
                    tolTalPrice = 0;
                    txttotalprice.ResetText();
                    listView1.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đặt hàng không thành công\n" + ex.Message, "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                }
            }


        }

        private void cbThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            drink = cbThucUong.SelectedItem as Drink;
            lblDrink.Text = drink.Name;
            tinhTien();
        }

        private void cbTopping_SelectedIndexChanged(object sender, EventArgs e)
        {
            topping = cbTopping.SelectedItem as Topping;
            if (topping.Name == "<None>")
            {
                listTopping.Clear();
                binddingComboBox();
                tinhTien();
                return;
            }
            listTopping.Add(topping);
            binddingComboBox();
            tinhTien();
        }

        private void cbTopping_Click(object sender, EventArgs e)
        {
            cbTopping.DroppedDown = true;
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAccountProfile f = new FormAccountProfile(account);
            f.UpdatAccount += F_UpdatAccount;
            f.Show();
        }
        private void F_UpdatAccount(object sender, AccountEvent e)
        {
            navbtnThongTinTaiKhoang.Caption = "Thông tin cá nhân (" + e.Acc.Hoten + ")";
        }

        #endregion

        #region Dat hang
        private void numericUpDownCountOrder_ValueChanged(object sender, EventArgs e)
        {
            lblCount.Text = numericUpDownCountOrder.Value.ToString();
            tinhTien();
        }

        private void btnHuyDatHang_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc hủy không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    bill = BillBUS.Instance.getLastBill(account.Id);
                    if (BillBUS.Instance.deleteBill(bill, ref error))
                    {
                        MessageBox.Show("Hủy đơn hàng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThanhToan.Enabled = false;
                    }
                    else
                        MessageBox.Show("Không hủy được !\n " + error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Không hủy được !\n " + ex.Message+", "+error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Thông báo
                MessageBox.Show("Không hủy đơn hàng này !","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }

        }

        private void cbThucUong_Click(object sender, EventArgs e)
        {
            cbThucUong.DroppedDown = true;
        }

        private void cbLoaiThucUong_Click(object sender, EventArgs e)
        {
            cbLoaiThucUong.DroppedDown = true;
        }

        private void cbTopping2_Click(object sender, EventArgs e)
        {
            cbTopping2.DroppedDown = true;
        }

        private void navbtnAdmin_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            FormAdmin f = new FormAdmin(account.Id);
            this.Hide();
            f.ShowDialog();
            reStart();
            this.Show();

        }

        private void navbtnThongtintaikhoang_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            FormAccountProfile f = new FormAccountProfile(account);
            f.Show();
        }
                
        private void navbtnthoat_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }
                
        private void btnShowBill_Click(object sender, EventArgs e)
        {
            FormBillInfomation f = new FormBillInfomation(account);
            f.ShowDialog();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach(ListViewItem item in listView1.Items)
            {
                if(item.Selected)
                {
                    string s = item.SubItems[0].Text + "\n"
                               + item.SubItems[1].Text + "\n"
                               + item.SubItems[2].Text + "\n"
                               + item.SubItems[3].Text;
                    MessageBox.Show(s,"Chi tiết");
                }
            }
        }


        #endregion

        
    }
}
