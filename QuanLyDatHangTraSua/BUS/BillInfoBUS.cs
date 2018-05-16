using QuanLyDatHangTraSua.DAO;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.BUS
{
    class BillInfoBUS
    {
        private static BillInfoBUS instance;

        public static BillInfoBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoBUS();
                return BillInfoBUS.instance;
            }

            private set
            {
                BillInfoBUS.instance = value;
            }
        }

        private BillInfoBUS() { }


        public int insertBillInfo(BillInfo billInfo, ref string error)
        {
            return BillInfoDAO.Instance.insertBillInfo(billInfo, ref error);
        }

        public List<BillInfo> loadBillInfoList()
        {
            return BillInfoDAO.Instance.loadBillInfoList();
        }
        public BillInfo getLastBillInfo()
        {
            return BillInfoDAO.Instance.getLastBillInfo();
        }
    }
}
