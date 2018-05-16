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
    public partial class FormAdmin : Form
    {
        #region Declare
        BindingSource listCategory = new BindingSource();
        BindingSource listDrink = new BindingSource();
        BindingSource listTopping = new BindingSource();
        BindingSource listAccount = new BindingSource();
        string error;
        Account account;
        int idAccount;
        bool add = false;
        #endregion

        public FormAdmin(int id)
        {
            InitializeComponent();
            this.idAccount = id;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            account = AccountBUS.Instance.getAccountById(idAccount);
            lblAdminName.Text = "Admin:  " + account.Hoten;

            dgvCategories.DataSource = listCategory;
            dgvDrink.DataSource = listDrink;
            dgvTopping.DataSource = listTopping;
            dgvAccount.DataSource = listAccount;

            statistics(DateTime.Now, DateTime.Now);
            loadListAccount();
            loadListDrink();
            loadListCategory();
            loadListTopping();
            reStartCat();
            reStartDrink();
            reStartTopping();
            reStartAccount();

            addCategoryBinding();
            loadListCategoryIntoComboBox();
            addDrinkBinding();
            addToppingBinding();
            addAccountBinding();
        }

        #region Binding
        private void addCategoryBinding()
        {
            pcIdCat.Content.Enabled = false;
            pcIdCat.Content.DataBindings.Add(new Binding("Text", dgvCategories.DataSource, "Id", true, DataSourceUpdateMode.Never));
            pcNameCat.Content.DataBindings.Add(new Binding("Text", dgvCategories.DataSource, "Name", true, DataSourceUpdateMode.Never));
            pcNoteCat.Content.DataBindings.Add(new Binding("Text", dgvCategories.DataSource, "Ghichu", true, DataSourceUpdateMode.Never));
        }
        private void addDrinkBinding()
        {
            pcIdDrink.Content.Enabled = false;
            pcIdDrink.Content.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "Id", true, DataSourceUpdateMode.Never));
            pcNameDrink.Content.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "TenThucUong", true, DataSourceUpdateMode.Never));
            pcPriceDrink.Content.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "Dongia", true, DataSourceUpdateMode.Never));
            pcNoteDrink.Content.DataBindings.Add(new Binding("Text", dgvDrink.DataSource, "GhiChu", true, DataSourceUpdateMode.Never));
        }
        private void addToppingBinding()
        {
            pcIdTopping.Content.Enabled = false;
            pcIdTopping.Content.DataBindings.Add(new Binding("Text", dgvTopping.DataSource, "Id", true, DataSourceUpdateMode.Never));
            pcNameTopping.Content.DataBindings.Add(new Binding("Text", dgvTopping.DataSource, "Name", true, DataSourceUpdateMode.Never));
            pcPriceTopping.Content.DataBindings.Add(new Binding("Text", dgvTopping.DataSource, "Price", true, DataSourceUpdateMode.Never));
            pcNoteTopping.Content.DataBindings.Add(new Binding("Text", dgvTopping.DataSource, "GhiChu", true, DataSourceUpdateMode.Never));
        }
        private void addAccountBinding()
        {
            pcIdAccount.Content.Enabled = false;
            pcIdAccount.Content.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Id", true, DataSourceUpdateMode.Never));
            pcUsernameAccount.Content.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never));
            pcNameAccount.Content.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Hoten", true, DataSourceUpdateMode.Never));
            pcDayAccount.Content.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "ngsinh", true, DataSourceUpdateMode.Never));
            pcPhoneAccount.Content.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Sdt", true, DataSourceUpdateMode.Never));
            pcAddressAccount.Content.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            numericUpDownRole.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Role", true, DataSourceUpdateMode.Never));
        }
        #endregion

        #region LoadList
        private void loadListAccount()
        {
            listAccount.DataSource = AccountBUS.Instance.getListAccount();
        }
        private void loadListDrink()
        {
            listDrink.DataSource = DrinkBUS.Instance.getListDrink();
        }
        private void loadListCategory()
        {
            listCategory.DataSource = CategoryBUS.Instance.getListCategory();
        }
        private void loadListCategoryIntoComboBox()
        {
            cbDrink.DataSource = listCategory;
            cbDrink.DisplayMember = "name";
        }
        private void loadListTopping()
        {
            listTopping.DataSource = ToppingBUS.Instance.getListTopping();
        }
        #endregion

        #region tabCategory

        private void reStartCat()
        {
            dgvCategories.Enabled = true;
            btnSaveCat.Enabled = false;
            btnCancelCat.Enabled = false;
            btnAddCat.Enabled = true;
            btnUpdateCat.Enabled = true;
            btnDeleteCat.Enabled = true;
            pcIdCat.Content.ResetText();
            pcNameCat.Content.ResetText();
            pcNoteCat.Content.ResetText();
            panelCat.Enabled = false;
            add = false;
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            //FormAccountProfile f = new FormAccountProfile();
            //f.ShowDialog();
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            dgvCategories.Enabled = false;
            btnSaveCat.Enabled = true;
            btnCancelCat.Enabled = true;
            btnDeleteCat.Enabled = false;
            btnUpdateCat.Enabled = false;
            btnAddCat.Enabled = false;
            pcIdCat.Content.ResetText();
            pcNameCat.Content.ResetText();
            pcNoteCat.Content.ResetText();
            pcNameCat.Focus();
            panelCat.Enabled = true;
            add = true;
        }

        private void btnCancelCat_Click(object sender, EventArgs e)
        {
            reStartCat();
        }

        private void btnUpdateCat_Click(object sender, EventArgs e)
        {
            dgvCategories_CellClick(null, null);
            dgvCategories.Enabled = false;
            btnSaveCat.Enabled = true;
            btnCancelCat.Enabled = true;
            btnDeleteCat.Enabled = false;
            btnUpdateCat.Enabled = false;
            panelCat.Enabled = true;
            pcNameCat.Focus();
        }

        private void btnDeleteCat_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành
                int r = dgvCategories.CurrentCell.RowIndex;
                int idCategory = (int)dgvCategories.Rows[r].Cells[0].Value;

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (CategoryBUS.Instance.deleteCategory(idCategory, ref error)) ;
                    {
                        loadListCategory();
                        reStartCat();
                        MessageBox.Show("Đã xóa xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!","Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được \n" + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            string name = pcNameCat.Content.Text;
            string note = pcNoteCat.Content.Text;
            if (name == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (add)
            {
                try
                {
                    Category cat = new Category(1, name, note);
                    if (CategoryBUS.Instance.insertCategory(cat, ref error))
                    {
                        loadListCategory();
                        reStartCat();
                        loadListDrink();
                        MessageBox.Show("Đã thêm xong!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

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
            try
            {
                string id = pcIdCat.Content.Text;
                if (id == "") return;
                Category cat = new Category(int.Parse(id), name, note);
                if (CategoryBUS.Instance.updateCategory(cat, ref error))
                {
                    loadListCategory();
                    loadListDrink();
                    reStartCat();
                    MessageBox.Show("Đã sửa xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        #endregion

        #region tabDrink

        private void reStartDrink()
        {
            dgvDrink.Enabled = true;
            btnSaveDrink.Enabled = false;
            btnCancelDrink.Enabled = false;
            btnAddDrink.Enabled = true;
            btnUpdateDrink.Enabled = true;
            btnDeleteDrink.Enabled = true;
            pcIdDrink.Content.ResetText();
            pcNameDrink.Content.ResetText();
            pcNoteDrink.Content.ResetText();
            pcPriceDrink.Content.ResetText();
            panelDrink.Enabled = false;
            add = false;
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            dgvDrink.Enabled = false;
            btnSaveDrink.Enabled = true;
            btnCancelDrink.Enabled = true;
            btnDeleteDrink.Enabled = false;
            btnUpdateDrink.Enabled = false;
            btnAddDrink.Enabled = false;
            pcIdDrink.Content.ResetText();
            pcNameDrink.Content.ResetText();
            pcNoteDrink.Content.ResetText();
            pcPriceDrink.Content.ResetText();
            pcNameDrink.Focus();
            panelDrink.Enabled = true;
            add = true;
        }

        private void btnCancelDrink_Click(object sender, EventArgs e)
        {
            reStartDrink();
        }

        private void btnUpdateDrink_Click(object sender, EventArgs e)
        {
            dgvDrink_CellClick(null, null);
            dgvDrink.Enabled = false;
            btnSaveDrink.Enabled = true;
            btnCancelDrink.Enabled = true;
            btnDeleteDrink.Enabled = false;
            btnUpdateDrink.Enabled = false;
            panelDrink.Enabled = true;
            pcNameDrink.Focus();
        }

        private void btnDeleteDrink_Click(object sender, EventArgs e)
        {
            try
            {
                int idDrink = int.Parse(pcIdDrink.Content.Text);
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (DrinkBUS.Instance.deleteDrink(idDrink, ref error))
                    {
                        loadListDrink();
                        reStartDrink();
                        MessageBox.Show("Đã xóa xong!","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được \n" + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnSaveDrink_Click(object sender, EventArgs e)
        {
            string name = pcNameDrink.Content.Text;
            Category cat = cbDrink.SelectedItem as Category;
            int idCat = cat.Id;
            string price = pcPriceDrink.Content.Text;
            string note = pcNoteDrink.Content.Text;

            if (name == "" || idCat == null || price == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (add)
            {
                try
                {
                    Drink Drink = new Drink(1, name, idCat, int.Parse(price), note);
                    if (DrinkBUS.Instance.insertDrink(Drink, ref error))
                    {
                        loadListDrink();
                        reStartDrink();
                        MessageBox.Show("Đã thêm xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                string id = pcIdDrink.Content.Text;
                if (id == "") return;
                Drink Drink = new Drink(int.Parse(id), name, idCat, int.Parse(price), note);
                if (DrinkBUS.Instance.updateDrink(Drink, ref error))
                {
                    loadListDrink();
                    reStartDrink();
                    MessageBox.Show("Đã sửa xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void dgvDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDrink.CurrentCell.RowIndex;
            string name = dgvDrink.Rows[r].Cells[2].Value.ToString();
            if (name == "")
                return;
            Category category = CategoryBUS.Instance.getCategoryByName(name);
            cbDrink.SelectedItem = category;
            cbDrink.Text = category.Name;
        }


        #endregion

        #region tabTopping

        private void reStartTopping()
        {
            dgvTopping.Enabled = true;
            btnSaveTopping.Enabled = false;
            btnCancelTopping.Enabled = false;
            btnAddTopping.Enabled = true;
            btnUpdateTopping.Enabled = true;
            btnDeleteTopping.Enabled = true;
            pcIdTopping.Content.ResetText();
            pcNameTopping.Content.ResetText();
            pcNoteTopping.Content.ResetText();
            pcPriceTopping.Content.ResetText();
            panelTopping.Enabled = false;
            add = false;
        }

        private void btnAddTopping_Click(object sender, EventArgs e)
        {
            dgvTopping.Enabled = false;
            btnSaveTopping.Enabled = true;
            btnCancelTopping.Enabled = true;
            btnDeleteTopping.Enabled = false;
            btnUpdateTopping.Enabled = false;
            btnAddTopping.Enabled = false;
            pcIdTopping.Content.ResetText();
            pcNameTopping.Content.ResetText();
            pcNoteTopping.Content.ResetText();
            pcPriceTopping.Content.ResetText();
            pcNameTopping.Focus();
            panelTopping.Enabled = true;
            add = true;
        }

        private void btnCancelTopping_Click(object sender, EventArgs e)
        {
            reStartTopping();
        }

        private void btnUpdateTopping_Click(object sender, EventArgs e)
        {
            dgvTopping_CellClick(null, null);
            dgvTopping.Enabled = false;
            btnSaveTopping.Enabled = true;
            btnCancelTopping.Enabled = true;
            btnDeleteTopping.Enabled = false;
            btnUpdateTopping.Enabled = false;
            panelTopping.Enabled = true;
            pcNameTopping.Focus();
        }

        private void btnDeleteTopping_Click(object sender, EventArgs e)
        {
            try
            {
                //// Lấy thứ tự record hiện hành
                //int r = dgvTopping.CurrentCell.RowIndex;
                //int idTopping = (int)dgvTopping.Rows[r].Cells[0].Value;
                int idTopping = int.Parse(pcIdTopping.Content.Text);
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (ToppingBUS.Instance.deleteTopping(idTopping, ref error))
                    {
                        loadListTopping();
                        reStartTopping();
                        MessageBox.Show("Đã xóa xong!");
                    }
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được \n" + ex.Message);
            }
        }

        private void btnSaveTopping_Click(object sender, EventArgs e)
        {
            string name = pcNameTopping.Content.Text;
            string price = pcPriceTopping.Content.Text;
            string note = pcNoteTopping.Content.Text;

            if (name == "" || price == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (add)
            {
                try
                {
                    Topping Topping = new Topping(1, name, int.Parse(price), note);
                    if (ToppingBUS.Instance.insertTopping(Topping, ref error))
                    {
                        loadListTopping();
                        reStartTopping();
                        MessageBox.Show("Đã thêm xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                string id = pcIdTopping.Content.Text;
                if (id == "") return;
                Topping Topping = new Topping(int.Parse(id), name, int.Parse(price), note);
                if (ToppingBUS.Instance.updateTopping(Topping, ref error))
                {
                    loadListTopping();
                    reStartTopping();
                    MessageBox.Show("Đã sửa xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void dgvTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        #endregion

        #region tabAccount

        private void reStartAccount()
        {
            dgvAccount.Enabled = true;
            btnSaveAccount.Enabled = false;
            btnCancelAccount.Enabled = false;
            btnAddAccount.Enabled = true;
            btnUpdateAccount.Enabled = true;
            btnDeleteAccount.Enabled = true;
            btnResetPass.Enabled = true;
            pcUsernameAccount.Enabled = false;
            pcIdAccount.Content.ResetText();
            pcUsernameAccount.Content.ResetText();
            pcNameAccount.Content.ResetText();
            pcDayAccount.Content.ResetText();
            pcPhoneAccount.Content.ResetText();
            pcAddressAccount.Content.ResetText();
            numericUpDownRole.Value = 2;
            panelAccount.Enabled = false;
            add = false;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            return;
            //dgvAccount.Enabled = false;
            //btnSaveAccount.Enabled = true;
            //btnCancelAccount.Enabled = true;
            //btnDeleteAccount.Enabled = false;
            //btnUpdateAccount.Enabled = false;
            //btnAddAccount.Enabled = false;
            //btnResetPass.Enabled = false;
            //pcUsernameAccount.Enabled = true;
            //pcIdAccount.Content.ResetText();
            //pcUsernameAccount.Content.ResetText();
            //pcNameAccount.Content.ResetText();
            //pcDayAccount.Content.ResetText();
            //pcPhoneAccount.Content.ResetText();
            //pcAddressAccount.Content.ResetText();
            //numericUpDownRole.Value = 2;
            //pcNameAccount.Focus();
            //panelAccount.Enabled = true;
            //add = true;
        }

        private void btnCancelAccount_Click(object sender, EventArgs e)
        {
            reStartAccount();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            dgvAccount_CellClick(null, null);
            dgvAccount.Enabled = false;
            btnSaveAccount.Enabled = true;
            btnCancelAccount.Enabled = true;
            btnDeleteAccount.Enabled = false;
            btnUpdateAccount.Enabled = false;
            panelAccount.Enabled = true;
            pcNameAccount.Focus();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành
                int idAccount = int.Parse(pcIdAccount.Content.Text);
                if (idAccount == account.Id)
                {
                    return;
                }
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (AccountBUS.Instance.deleteAccount(idAccount, ref error))
                    {
                        loadListAccount();
                        reStartAccount();
                        MessageBox.Show("Đã xóa xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được \n" + ex.Message);
            }
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            string username = pcUsernameAccount.Content.Text;
            string hoten = pcNameAccount.Content.Text;
            DateTime day = new DateTime();
            if (pcDayAccount.Content.Text != "")
            {
                day = DateTime.Parse(pcDayAccount.Content.Text);
            }
            string phone = pcPhoneAccount.Content.Text;
            string address = pcAddressAccount.Content.Text;
            int role = (int)numericUpDownRole.Value;

            if (username == "" || hoten == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (add)
            {
                try
                {
                    Account Account = new Account(1, username, "123", hoten, day, phone, address, role);
                    if (AccountBUS.Instance.insertAccount(Account, ref error))
                    {
                        loadListAccount();
                        reStartAccount();
                        MessageBox.Show("Đã thêm xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                string id = pcIdAccount.Content.Text;
                if (id == "") return;
                Account Account = new Account(int.Parse(id), username, "3244185981728979115075721453575112", hoten, day, phone, address, role);
                if (AccountBUS.Instance.updateAccount(Account, ref error))
                {
                    loadListAccount();
                    reStartAccount();
                    MessageBox.Show("Đã sửa xong!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnReloadAccount_Click(object sender, EventArgs e)
        {
            loadListAccount();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string id = pcIdAccount.Content.Text;
            if (id == "") return;
            account = AccountBUS.Instance.getAccountById(int.Parse(id));
            FormAccountProfile f = new FormAccountProfile(account);
            //this.Hide();
            f.Show();
            //this.Show();
            //loadListAccount();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            pcDayAccount.Content.Text = dateTimePicker.Value.ToString();
        }







        #endregion

       
        #region Thong Ke
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime day1 = dateTimePicker1.Value;
            DateTime day2 = dateTimePicker2.Value;
            statistics(day1, day2);
        }
        private void statistics(DateTime day1, DateTime day2)
        {
            try
            {
                dgvDoanhThu.DataSource = BillBUS.Instance.getBillStatistics(day1, day2, ref error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDaDat_Click(object sender, EventArgs e)
        {
            DateTime day1 = dateTimePicker1.Value;
            DateTime day2 = dateTimePicker2.Value;
            try
            {
                dgvDoanhThu.DataSource = BillBUS.Instance.getBillOrdering(day1, day2, ref error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDaHuy_Click(object sender, EventArgs e)
        {
            DateTime day1 = dateTimePicker1.Value;
            DateTime day2 = dateTimePicker2.Value;
            try
            {
                dgvDoanhThu.DataSource = BillBUS.Instance.getBillCanceled(day1, day2, ref error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
