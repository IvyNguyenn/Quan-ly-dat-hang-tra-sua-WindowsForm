using Oracle.DataAccess.Client;
using QuanLyDatHangTraSua.BUS;
using QuanLyDatHangTraSua.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDatHangTraSua.GUI
{
    public partial class FormConnection : Form
    {
        //tạo đối tượng conection
        OracleConnection con = null;
        string error;
        public FormConnection()
        {
            InitializeComponent();
            GetIP();
            cbIP.Text = "192.168.56.1";   
            txtService.Text = "orcl";
            txtUsername.Text = "tshoangvy";
            txtPassword.Text = "12345";
        }
        private void btnTest_connect_Click(object sender, EventArgs e)
        {
            string Host_name = cbIP.Text;
            string Service = txtService.Text;
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            if (Host_name == "" || Service == "" || Username == "" || Password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            con = new OracleConnection();
            con.ConnectionString = string.Format(@"Data Source = " +
            "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = 1521))" +
            "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = {1})));User ID = {2}; Password={3};", Host_name, Service, Username, Password);
      
            DataProvider.Instance.setConnectionSTR(Host_name, Service, Username, Password);
            
            try
            {
                //mở kết nối và đưa vào trang mua hàng
                con.Open();
                checkAllBill();
                FormMain f = new FormMain(Username);
                f.Show();
                
            }
            //Xử lý khi không mở kết nối được
            catch (Exception ex)
            {
                MessageBox.Show("False: "+ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                
            }
            finally
            {
                con.Close();
                txtPassword.ResetText();
            }


        }
        
        private void GetIP()
        {
            foreach (var arp in GetARPResult().Split(new char[] { '\n', '\r' }))
            {
                if (!string.IsNullOrEmpty(arp))
                {
                    var pieces = (from piece in arp.Split(new char[] { ' ', '\t' })
                                  where !string.IsNullOrEmpty(piece)
                                  select piece).ToArray();
                    if (pieces.Length == 3 )
                    {
                        cbIP.Items.Add(pieces[0]);
                    }
                }
            }
            var host = Dns.GetHostEntry(Dns.GetHostName());
            
        }
        private static string GetARPResult()
        {
            Process p = null;
            string output = string.Empty;

            try
            {
                p = Process.Start(new ProcessStartInfo("arp", "-a")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                });

                output = p.StandardOutput.ReadToEnd();

                p.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("IPInfo: Error Retrieving 'arp -a' Results", ex);
            }
            finally
            {
                if (p != null)
                {
                    p.Close();
                }
            }

            return output;
        }
                
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkAllBill()
        {
            if (BillBUS.Instance.checkAllBill(ref error) == false)
                MessageBox.Show(error);
        }
        // IP máy Vy: 192.186.137.1
        //&& pieces[2] == "dynamic")
    }
}
