using QuanLyDatHangTraSua.DAO;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.BUS
{
    public class AddInfoBUS
    {
        private static AddInfoBUS instance;

        public static AddInfoBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new AddInfoBUS();
                return AddInfoBUS.instance;
            }

            private set
            {
                AddInfoBUS.instance = value;
            }
        }

        private AddInfoBUS() { }

        public long tinhTienOrder(string thucUong, string topping, int count)
        {
            return AddInfoBUS.Instance.tinhTienOrder(thucUong, topping, count);
        }

        public bool insertAddInfo(AddInfo addInfo, ref string error)
        {
            return AddInfoDAO.Instance.insertAddInfo(addInfo, ref error);
        }

        public List<AddInfo> LoadOrderList()
        {
            return AddInfoBUS.Instance.LoadOrderList();
        }
        
        public List<Topping> loadOrderListTopping(AddInfo addInfo)
        {
            return AddInfoDAO.Instance.loadAddInfoListTopping(addInfo);
        }
    }
}
