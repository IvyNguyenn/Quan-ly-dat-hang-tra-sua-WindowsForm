using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return BillDAO.instance;
            }

            private set
            {
                BillDAO.instance = value;
            }
        }

        private BillDAO() { }

        public bool insertBill(Bill bill, ref string error)
        {
            string query = string.Format("NGOCHOANG2.sp_insertBill IDUSER$ NGAY$ TONGTIEN$");
            int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { bill.IdCustomer, bill.Date, bill.Price });
            return result != 0;
        }
        public bool deleteBill(Bill bill, ref string error)
        {
            string query = string.Format("NGOCHOANG2.sp_cancelBill BILLID$");
            int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { bill.Id });
            return result != 0;
        }
        public bool payedBill(Bill bill, ref string error)
        {
            string query = string.Format("NGOCHOANG2.sp_payedBill BILLID$");
            int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { bill.Id });
            return result != 0;
        }
        public long tinhTienBill(string thucUong, string topping, int count)
        {
            string query = string.Format("NGOCHOANG2.fn_TinhTienOrder('{0}','{1}',{2})", thucUong, topping, count);
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<Bill> loadBillListByUserId(int id)
        {
            List<Bill> billList = new List<Bill>();
            string query = string.Format("SELECT * FROM NGOCHOANG2.HOADON WHERE IDUSER = {0} ORDER BY ID DESC", id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                billList.Add(bill);
            }

            return billList;
        }
        public Bill getLastBill(int id)
        {
            List<Bill> listBill = loadBillListByUserId(id);
            return listBill[listBill.Count - 1];
        }
        public bool checkAllBill(ref string error)
        {
            string query = string.Format("NGOCHOANG2.sp_checkAllBill");
            int result = DataProvider.Instance.ExecuteProcedure(query, ref error, null);
            return result != 0;
        }
        public DataTable getBillStatistics(DateTime day1, DateTime day2, ref string error)
        {
            try
            {
                string query = string.Format("SELECT * FROM TABLE( NGOCHOANG2.fn_ThongKeHoaDon('{0}','{1}')) ORDER BY ID DESC", string.Format("{0:dd-MMM-yyyy}", day1), string.Format("{0:dd-MMM-yyyy}",day2));
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }

        public DataTable getBillOrdering(DateTime day1, DateTime day2, ref string error)
        {
            try
            {
                string query = string.Format("SELECT * FROM TABLE( NGOCHOANG2.fn_getListBillOrdering('{0}','{1}')) ORDER BY ID DESC", string.Format("{0:dd-MMM-yyyy}", day1), string.Format("{0:dd-MMM-yyyy}", day2));
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
        public DataTable getBillCanceled(DateTime day1, DateTime day2, ref string error)
        {
            try
            {
                string query = string.Format("SELECT * FROM TABLE( NGOCHOANG2.fn_getListBillCanceled('{0}','{1}')) ORDER BY ID DESC", string.Format("{0:dd-MMM-yyyy}", day1), string.Format("{0:dd-MMM-yyyy}", day2));
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
