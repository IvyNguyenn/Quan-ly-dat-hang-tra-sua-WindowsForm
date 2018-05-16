using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return BillInfoDAO.instance;
            }

            private set
            {
                BillInfoDAO.instance = value;
            }
        }

        private BillInfoDAO() { }

        
        public int insertBillInfo(BillInfo billInfo, ref string error)
        {
            string query = string.Format("INSERT INTO NGOCHOANG2.CHITIETHOADON (IDHOADON,IDORDER,SOLUONG) VALUES ({0},{1},{2})",
                                         billInfo.IdBill,billInfo.IdOrder,billInfo.Count);
            return DataProvider.Instance.ExecuteNonQuery(query, ref error);


        }
        
        public List<BillInfo> loadBillInfoList()
        {
            List<BillInfo> billInfoList = new List<BillInfo>();
            string query = "SELECT * FROM NGOCHOANG2.ORDERS ORDER BY ID ASC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);
                billInfoList.Add(billInfo);
            }

            return billInfoList;
        }
        public BillInfo getLastBillInfo()
        {
            List<BillInfo> listBillInfo = loadBillInfoList();
            return listBillInfo[listBillInfo.Count - 1];
        }
       
    }
}
