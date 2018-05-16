
using QuanLyDatHangTraSua.DAO;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.BUS
{
    public class AccountBUS
    {
        private static AccountBUS instance;

        public static AccountBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountBUS();
                return AccountBUS.instance;
            }

            private set
            {
                AccountBUS.instance = value;
            }
        }
        
        private AccountBUS() { }

        public bool Login(string username, string password)
        {
            username = checkString(username);
            password = checkString(password);
            password = MD5password(password);

            return AccountDAO.Instance.Login(username, password);
        }

        public Account getAccountByUserName(string username)
        {
            username = checkString(username);
            return AccountDAO.Instance.getAccountByUserName(username);
        }
        public Account getAccountById(int id)
        {
            return AccountDAO.Instance.getAccountById(id);
        }
        public DataTable getListAccount()
        {
            return AccountDAO.Instance.getListAccount();
        }

        public bool updateAccount(Account account, ref string error)
        {
            //account.Ngaysinh = formatDateTime(account.Ngaysinh);
            return AccountDAO.Instance.updateAccount(account, ref error);
        }

        public bool insertAccount(Account account, ref string error)
        {
            //account.Ngaysinh = formatDateTime(account.Ngaysinh);
            return AccountDAO.Instance.insertAccount(account, ref error);
        }
        public bool insertAdminAccount(Account account, ref string error)
        {
            return AccountDAO.Instance.insertAdminAccount(account,ref error);
        }
        public bool deleteAccount(int id, ref string error)
        {
            return AccountDAO.Instance.deleteAccount(id, ref error);
        }

        public bool resetPass(Account account,ref string error)
        {
            return AccountDAO.Instance.resetPass(account, ref error);
        }

        private string checkString(string s)
        {
            s = s.Replace("'", "");
            s = s.Replace("or", "");
            s = s.Replace('=', ' ');
            s = s.Replace('-', ' ');
            s = s.Replace('#', ' ');
            s = s.Replace("/*", "");
            s = s.Replace('"', ' ');
            s = s.Replace(')', ' ');

            return s;
        }

        private string formatDateTime(string d)
        {
            string[] dmy = d.Split('/');
            string[] m = { "", "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

            return dmy[1] + "-" + m[int.Parse(dmy[0])] + "-" + dmy[2][2] + dmy[2][3];
        }

        public string MD5password(string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }
    }
}
