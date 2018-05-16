using QuanLyDatHangTraSua.DAO;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.BUS
{
    public class BillBUS
    {
        private static BillBUS instance;

        public static BillBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillBUS();
                return BillBUS.instance;
            }

            private set
            {
                BillBUS.instance = value;
            }
        }

        private BillBUS() { }

        public long tinhTienOrder(string thucUong, string topping, int count)
        {
            return BillBUS.Instance.tinhTienOrder(thucUong, topping, count);
        }

        public bool insertBill(Bill bill, ref string error)
        {
            return BillDAO.Instance.insertBill(bill, ref error);
        }

        public bool deleteBill(Bill bill, ref string error)
        {
            return BillDAO.Instance.deleteBill(bill, ref error);
        }
        public bool payedBill(Bill bill, ref string error)
        {
            return BillDAO.Instance.payedBill(bill, ref error);
        }
        public List<Bill> loadBillListByUserId(int id)
        {
            return BillDAO.Instance.loadBillListByUserId(id);
        }

        public Bill getLastBill(int id)
        {
            List<Bill> lb =  BillDAO.Instance.loadBillListByUserId(id);
            return lb[0];
        }

        public bool checkAllBill(ref string error)
        {
            return BillDAO.Instance.checkAllBill(ref error);
        }

        public DataTable getBillStatistics(DateTime day1, DateTime day2,ref string error)
        {
            return BillDAO.Instance.getBillStatistics(day1, day2,ref error);
        }
        public DataTable getBillOrdering(DateTime day1, DateTime day2, ref string error)
        {
            return BillDAO.Instance.getBillOrdering(day1, day2, ref error);
        }
        public DataTable getBillCanceled(DateTime day1, DateTime day2, ref string error)
        {
            return BillDAO.Instance.getBillCanceled(day1, day2, ref error);
        }
    }
}
