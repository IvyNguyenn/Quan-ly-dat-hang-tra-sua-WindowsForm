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
    public class ToppingBUS
    {
        private static ToppingBUS instance;

        public static ToppingBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ToppingBUS();
                return ToppingBUS.instance;
            }

            private set
            {
                ToppingBUS.instance = value;
            }
        }

        private ToppingBUS() { }

        public List<Topping> getListTopping()
        {
            return ToppingDAO.Instance.getListTopping();
        }
        public List<Topping> getListToppingByOrderId(int idOrder)
        {
            return ToppingDAO.Instance.getListToppingByOrderId(idOrder);
        }
        public bool updateTopping(Topping topping, ref string error)
        {
            return ToppingDAO.Instance.updateTopping(topping,ref error);
        }

        public bool insertTopping(Topping topping, ref string error)
        {
            return ToppingDAO.Instance.insertTopping(topping,ref error);
        }

        public bool deleteTopping(int id, ref string error)
        {
            return ToppingDAO.Instance.deleteTopping(id, ref error);
        }
        public DataSet getListToppingDS()
        {
            return ToppingDAO.Instance.getListToppingDS();
        }
    }
}
