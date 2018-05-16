namespace QuanLyDatHangTraSua.GUI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnShow = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblDrink = new System.Windows.Forms.Label();
            this.cbTopping2 = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.drinkname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toppingname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowBill = new DevExpress.XtraEditors.SimpleButton();
            this.btnDatHang = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuyDatHang = new DevExpress.XtraEditors.SimpleButton();
            this.btnThanhToan = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txttotalprice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCountOrder = new System.Windows.Forms.NumericUpDown();
            this.cbTopping = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbThucUong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLoaiThucUong = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddOrder = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.tileNavPane2 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.navbtnAdmin = new DevExpress.XtraBars.Navigation.NavButton();
            this.navbtnThongTinTaiKhoang = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton5 = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnShow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOrder)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.AliceBlue;
            this.btnShow.Controls.Add(this.panel1);
            this.btnShow.Controls.Add(this.listView1);
            this.btnShow.Controls.Add(this.groupBox2);
            this.btnShow.Controls.Add(this.groupBox1);
            this.btnShow.Location = new System.Drawing.Point(0, 32);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(1274, 686);
            this.btnShow.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.lblDrink);
            this.panel1.Controls.Add(this.cbTopping2);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(12, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 46);
            this.panel1.TabIndex = 18;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.White;
            this.lblCount.Location = new System.Drawing.Point(854, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(26, 21);
            this.lblCount.TabIndex = 19;
            this.lblCount.Text = " 1";
            // 
            // lblDrink
            // 
            this.lblDrink.AutoSize = true;
            this.lblDrink.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblDrink.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrink.ForeColor = System.Drawing.Color.White;
            this.lblDrink.Location = new System.Drawing.Point(6, 12);
            this.lblDrink.Name = "lblDrink";
            this.lblDrink.Size = new System.Drawing.Size(106, 21);
            this.lblDrink.TabIndex = 18;
            this.lblDrink.Text = "Thức uống ";
            // 
            // cbTopping2
            // 
            this.cbTopping2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTopping2.FormattingEnabled = true;
            this.cbTopping2.Location = new System.Drawing.Point(343, 9);
            this.cbTopping2.Name = "cbTopping2";
            this.cbTopping2.Size = new System.Drawing.Size(298, 29);
            this.cbTopping2.TabIndex = 17;
            this.cbTopping2.Click += new System.EventHandler(this.cbTopping2_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(996, 9);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(251, 28);
            this.txtPrice.TabIndex = 16;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.drinkname,
            this.toppingname,
            this.count,
            this.price});
            this.listView1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(12, 282);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1250, 393);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // id
            // 
            this.id.Text = "IdOrder";
            this.id.Width = 0;
            // 
            // drinkname
            // 
            this.drinkname.Text = "Thức uống";
            this.drinkname.Width = 220;
            // 
            // toppingname
            // 
            this.toppingname.Text = "Topping";
            this.toppingname.Width = 367;
            // 
            // count
            // 
            this.count.Text = "Số lượng";
            this.count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.count.Width = 130;
            // 
            // price
            // 
            this.price.Text = "Đơn giá";
            this.price.Width = 215;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowBill);
            this.groupBox2.Controls.Add(this.btnDatHang);
            this.groupBox2.Controls.Add(this.btnHuyDatHang);
            this.groupBox2.Controls.Add(this.btnThanhToan);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Location = new System.Drawing.Point(860, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 210);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thanh toán";
            // 
            // btnShowBill
            // 
            this.btnShowBill.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnShowBill.ImageOptions.Image")));
            this.btnShowBill.Location = new System.Drawing.Point(221, 99);
            this.btnShowBill.Name = "btnShowBill";
            this.btnShowBill.Size = new System.Drawing.Size(158, 45);
            this.btnShowBill.TabIndex = 20;
            this.btnShowBill.Text = "Xem đơn hàng";
            this.btnShowBill.Click += new System.EventHandler(this.btnShowBill_Click);
            // 
            // btnDatHang
            // 
            this.btnDatHang.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatHang.Appearance.Options.UseFont = true;
            this.btnDatHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDatHang.ImageOptions.Image")));
            this.btnDatHang.Location = new System.Drawing.Point(20, 100);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Size = new System.Drawing.Size(195, 45);
            this.btnDatHang.TabIndex = 19;
            this.btnDatHang.Text = "Xác nhận đặt hàng ";
            this.btnDatHang.Click += new System.EventHandler(this.btnDatHang_Click);
            // 
            // btnHuyDatHang
            // 
            this.btnHuyDatHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuyDatHang.ImageOptions.Image")));
            this.btnHuyDatHang.Location = new System.Drawing.Point(221, 149);
            this.btnHuyDatHang.Name = "btnHuyDatHang";
            this.btnHuyDatHang.Size = new System.Drawing.Size(158, 45);
            this.btnHuyDatHang.TabIndex = 19;
            this.btnHuyDatHang.Text = "Hủy";
            this.btnHuyDatHang.Click += new System.EventHandler(this.btnHuyDatHang_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Appearance.Options.UseFont = true;
            this.btnThanhToan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThanhToan.ImageOptions.Image")));
            this.btnThanhToan.Location = new System.Drawing.Point(20, 151);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(195, 46);
            this.btnThanhToan.TabIndex = 19;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txttotalprice);
            this.panel4.Location = new System.Drawing.Point(6, 22);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(390, 71);
            this.panel4.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(143, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tổng Tiền";
            // 
            // txttotalprice
            // 
            this.txttotalprice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalprice.Location = new System.Drawing.Point(14, 27);
            this.txttotalprice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttotalprice.Name = "txttotalprice";
            this.txttotalprice.ReadOnly = true;
            this.txttotalprice.Size = new System.Drawing.Size(359, 32);
            this.txttotalprice.TabIndex = 10;
            this.txttotalprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnAddOrder);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 210);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.numericUpDownCountOrder);
            this.panel3.Controls.Add(this.cbTopping);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbThucUong);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbLoaiThucUong);
            this.panel3.Location = new System.Drawing.Point(6, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(421, 179);
            this.panel3.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Loại thức uống";
            // 
            // numericUpDownCountOrder
            // 
            this.numericUpDownCountOrder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCountOrder.Location = new System.Drawing.Point(137, 137);
            this.numericUpDownCountOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownCountOrder.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCountOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountOrder.Name = "numericUpDownCountOrder";
            this.numericUpDownCountOrder.Size = new System.Drawing.Size(271, 32);
            this.numericUpDownCountOrder.TabIndex = 4;
            this.numericUpDownCountOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCountOrder.ValueChanged += new System.EventHandler(this.numericUpDownCountOrder_ValueChanged);
            // 
            // cbTopping
            // 
            this.cbTopping.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTopping.FormattingEnabled = true;
            this.cbTopping.Location = new System.Drawing.Point(136, 95);
            this.cbTopping.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTopping.Name = "cbTopping";
            this.cbTopping.Size = new System.Drawing.Size(272, 29);
            this.cbTopping.TabIndex = 2;
            this.cbTopping.Text = "Chọn Topping";
            this.cbTopping.SelectedIndexChanged += new System.EventHandler(this.cbTopping_SelectedIndexChanged);
            this.cbTopping.Click += new System.EventHandler(this.cbTopping_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(4, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số lượng order";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(3, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Topping";
            // 
            // cbThucUong
            // 
            this.cbThucUong.DisplayMember = "name";
            this.cbThucUong.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThucUong.FormattingEnabled = true;
            this.cbThucUong.Location = new System.Drawing.Point(137, 50);
            this.cbThucUong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbThucUong.Name = "cbThucUong";
            this.cbThucUong.Size = new System.Drawing.Size(272, 29);
            this.cbThucUong.TabIndex = 1;
            this.cbThucUong.Text = "Chọn thức uống ";
            this.cbThucUong.ValueMember = "name";
            this.cbThucUong.SelectedIndexChanged += new System.EventHandler(this.cbThucUong_SelectedIndexChanged);
            this.cbThucUong.Click += new System.EventHandler(this.cbThucUong_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(4, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Thức uống";
            // 
            // cbLoaiThucUong
            // 
            this.cbLoaiThucUong.DisplayMember = "loaithucuong";
            this.cbLoaiThucUong.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiThucUong.FormattingEnabled = true;
            this.cbLoaiThucUong.Location = new System.Drawing.Point(137, 5);
            this.cbLoaiThucUong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLoaiThucUong.Name = "cbLoaiThucUong";
            this.cbLoaiThucUong.Size = new System.Drawing.Size(271, 29);
            this.cbLoaiThucUong.TabIndex = 0;
            this.cbLoaiThucUong.Text = "Chọn loại thức uống ";
            this.cbLoaiThucUong.SelectedIndexChanged += new System.EventHandler(this.cbLoaiThucUong_SelectedIndexChanged);
            this.cbLoaiThucUong.Click += new System.EventHandler(this.cbLoaiThucUong_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(433, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 125);
            this.panel2.TabIndex = 18;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::QuanLyDatHangTraSua.Properties.Resources.tocoloogo;
            this.pictureBox3.Location = new System.Drawing.Point(3, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(395, 117);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // btnXoa
            // 
            this.btnXoa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(666, 153);
            this.btnXoa.MaximumSize = new System.Drawing.Size(170, 48);
            this.btnXoa.MinimumSize = new System.Drawing.Size(170, 48);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(170, 48);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Tag = "3";
            this.btnXoa.Text = "Xóa nước";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOrder.ImageOptions.Image")));
            this.btnAddOrder.Location = new System.Drawing.Point(433, 152);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(208, 48);
            this.btnAddOrder.TabIndex = 16;
            this.btnAddOrder.Tag = "1";
            this.btnAddOrder.Text = "Thêm nước";
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "navBarGroup1";
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // tileNavPane2
            // 
            this.tileNavPane2.Buttons.Add(this.navbtnAdmin);
            this.tileNavPane2.Buttons.Add(this.navbtnThongTinTaiKhoang);
            this.tileNavPane2.Buttons.Add(this.navButton5);
            // 
            // tileNavCategory2
            // 
            this.tileNavPane2.DefaultCategory.Name = "tileNavCategory2";
            this.tileNavPane2.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane2.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane2.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane2.Name = "tileNavPane2";
            this.tileNavPane2.Size = new System.Drawing.Size(1275, 40);
            this.tileNavPane2.TabIndex = 22;
            this.tileNavPane2.Text = "tileNavPane2";
            // 
            // navbtnAdmin
            // 
            this.navbtnAdmin.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.navbtnAdmin.Caption = "Admin";
            this.navbtnAdmin.Name = "navbtnAdmin";
            this.navbtnAdmin.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navbtnAdmin_ElementClick);
            // 
            // navbtnThongTinTaiKhoang
            // 
            this.navbtnThongTinTaiKhoang.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.navbtnThongTinTaiKhoang.Caption = "Thông tin tài khoảng";
            this.navbtnThongTinTaiKhoang.Name = "navbtnThongTinTaiKhoang";
            this.navbtnThongTinTaiKhoang.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navbtnThongtintaikhoang_ElementClick);
            // 
            // navButton5
            // 
            this.navButton5.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton5.Caption = "| Thoát";
            this.navButton5.Name = "navButton5";
            this.navButton5.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navbtnthoat_ElementClick);
            // 
            // FormMain
            // 
            this.AcceptButton = this.btnAddOrder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnXoa;
            this.ClientSize = new System.Drawing.Size(1275, 718);
            this.Controls.Add(this.tileNavPane2);
            this.Controls.Add(this.btnShow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1293, 765);
            this.MinimumSize = new System.Drawing.Size(1293, 765);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trà sữa Tocotoco";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.btnShow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountOrder)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel btnShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownCountOrder;
        private System.Windows.Forms.ComboBox cbTopping;
        private System.Windows.Forms.ComboBox cbThucUong;
        private System.Windows.Forms.ComboBox cbLoaiThucUong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttotalprice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblDrink;
        private System.Windows.Forms.ComboBox cbTopping2;
        private DevExpress.XtraEditors.SimpleButton btnAddOrder;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnThanhToan;
        private DevExpress.XtraEditors.SimpleButton btnHuyDatHang;
        private DevExpress.XtraEditors.SimpleButton btnDatHang;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane2;
        private DevExpress.XtraBars.Navigation.NavButton navbtnThongTinTaiKhoang;
        private DevExpress.XtraBars.Navigation.NavButton navButton5;
        private DevExpress.XtraBars.Navigation.NavButton navbtnAdmin;
        private DevExpress.XtraEditors.SimpleButton btnShowBill;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader drinkname;
        private System.Windows.Forms.ColumnHeader toppingname;
        private System.Windows.Forms.ColumnHeader count;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel3;
    }
}