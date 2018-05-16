using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class AddInfoDAO
    {
        private static AddInfoDAO instance;

        public static AddInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AddInfoDAO();
                return AddInfoDAO.instance;
            }

            private set
            {
                AddInfoDAO.instance = value;
            }
        }

        private AddInfoDAO() { }

        public bool insertAddInfo(AddInfo addInfo, ref string error)
        {
            //string query = string.Format("EXECUTE sp_addOrder({0},{1},{2})", idthucUong, idtopping, count);
            //return DataProvider.Instance.ExecuteNonQuery(query, ref error);

            string query = string.Format("INSERT INTO NGOCHOANG2.CHITIETTHEM (IDORDER,IDTHEM,SOLUONG) VALUES ({0},{1},{2})",
                                         addInfo.IdOrder,addInfo.IdThem,addInfo.Count);
            int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);

            return result > 0;
        }
        
        public List<AddInfo> loadOrderList()
        {
            List<AddInfo> addInfoList = new List<AddInfo>();
            string query = "SELECT * FROM NGOCHOANG2.Orders";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                AddInfo addInfo = new AddInfo(item);
                addInfoList.Add(addInfo);
            }

            return addInfoList;
        }
        public List<Topping> loadAddInfoListTopping(AddInfo addInfo)
        {
            List<Topping> orderListTopping = new List<Topping>();
            string query = string.Format("SELECT * FROM NGOCHOANG2.THEM D where D.ID={0}");
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Topping topping = new Topping(item);
                orderListTopping.Add(topping);
            }

            return orderListTopping;
        }
    }
}
