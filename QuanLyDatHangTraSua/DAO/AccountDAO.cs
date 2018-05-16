using QuanLyDatHangTraSua.BUS;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return AccountDAO.instance;
            }

            private set
            {
                AccountDAO.instance = value;
            }
        }

        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = string.Format("SELECT * FROM TABLE( NGOCHOANG2.fn_Login ('{0}', '{1}'))", username, password);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return (result.Rows.Count > 0);
        }

        public Account getAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(String.Format("SELECT * FROM NGOCHOANG2.KhachHang WHERE UserName = '{0}'", username));
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public Account getAccountById(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(String.Format("SELECT * FROM NGOCHOANG2.KhachHang WHERE ID = {0}", id));
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public DataTable getListAccount()
        {
            string query = "SELECT ID,USERNAME,HOTEN,NGSINH,SDT,DIACHI,ROLE FROM NGOCHOANG2.KhachHang ORDER BY ID";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool updateAccount(Account account, ref string error)
        {
            try
            {
                string query = string.Format("NGOCHOANG2.SP_updateKhachHang NGSINH$ SDT$ DIACHI$ ROLE$ ID$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { string.Format("{0:dd-MMM-yyyy}", account.Ngaysinh), account.Sdt, account.Diachi, account.Role, account.Id });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool insertAccount(Account account, ref string error)
        {
            try
            {
                string query = string.Format("CREATE USER {0} IDENTIFIED BY {1}", account.UserName, account.PassWord);
                int result = DataProvider.Instance.ExecuteNonQuery(query,ref error);
                query = string.Format("GRANT CONNECT, RESOURCE TO {0}", account.UserName);

                result = DataProvider.Instance.ExecuteNonQuery(query,ref error);

                query = string.Format("NGOCHOANG2.SP_insertKhachHang USERNAME$ PASSWORD$ HOTEN$ NGSINH$ SDT$ DIACHI$ ROLE$");
                result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { account.UserName, account.PassWord, account.Hoten, string.Format("{0:dd-MMM-yyyy}",account.Ngaysinh), account.Sdt, account.Diachi, account.Role });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool insertAdminAccount(Account account, ref string error)
        {
            try
            {
                string query = string.Format("CREATE USER {0} IDENTIFIED BY {1}", account.UserName, account.PassWord);
                int result = DataProvider.Instance.ExecuteNonQuery(query,ref error);
                query = string.Format("GRANT Adminitrator TO {0}", account.UserName);
                result = DataProvider.Instance.ExecuteNonQuery(query,ref error);

                query = string.Format("NGOCHOANG2.SP_insertKhachHang USERNAME$ PASSWORD$ HOTEN$ NGSINH$ SDT$ DIACHI$ ROLE$");
                result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { account.UserName, account.PassWord, account.Hoten, string.Format("{0:dd-MMM-yyyy}", account.Ngaysinh), account.Sdt, account.Diachi, account.Role });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool deleteAccount(int id, ref string error)
        {
            try
            {
                //string query = string.Format("DELETE FROM V_KHACHHANG WHERE ID = {0}", id);
                //int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);
                //return result > 0;
                Account account = AccountDAO.instance.getAccountById(id);
                string query = string.Format("NGOCHOANG2.SP_deleteKhachHang ID$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { id });
                
                query = string.Format("DROP USER {0}", account.UserName);
                result = DataProvider.Instance.ExecuteNonQuery(query,ref error);
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool resetPass(Account account,ref string error)
        {
            string query = string.Format("ALTER USER {0} IDENTIFIED BY {1}",account.UserName,account.PassWord);
            int result = DataProvider.Instance.ExecuteNonQuery(query,ref error);
            if (result == 0) return false;

            query = "NGOCHOANG2.sp_resetPassword USERNAME$ PASS$ HOTEN$ NGAYSINH$ SDT$ DIACHI$ ID$";
            result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { account.UserName, AccountBUS.Instance.MD5password(account.PassWord), account.Hoten, account.Ngaysinh, account.Sdt, account.Diachi, account.Id });

            return result != 0;

        }

        public bool isAdmin(ref string error)
        {
                string query = "NGOCHOANG2.sp_isAdmin a$";
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { "Admin!"});
                return result != 0;
        }
    }
}
