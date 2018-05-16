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
    public class DrinkBUS
    {
        private static DrinkBUS instance;

        public static DrinkBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DrinkBUS();
                return DrinkBUS.instance;
            }

            private set
            {
                DrinkBUS.instance = value;
            }
        }

        private DrinkBUS() { }

        public DataTable getListDrink()
        {
            return DrinkDAO.Instance.getListDrink();
        }

        public List<Drink> getListDrinkByCategoryId(int categoryId)
        {
            return DrinkDAO.Instance.getListDrinkByCategoryId(categoryId);
        }

        public DataSet getListDrinkDS()
        {
            return DrinkDAO.Instance.getListDrinkDS();
        }
        public Drink getDrinkByOrderId(int idorder)
        {
            return DrinkDAO.Instance.getDrinkByOrderId(idorder);
        }
        public bool insertDrink(Drink drink,ref string error)
        {
            return DrinkDAO.Instance.insertDrink(drink,ref error);
        }
        public bool updateDrink(Drink drink, ref string error)
        {
            return DrinkDAO.Instance.updateDrink(drink,ref error);
        }
        public bool deleteDrink(int id, ref string error)
        {
            return DrinkDAO.Instance.deleteDrink(id, ref error);
        }
    }
}
