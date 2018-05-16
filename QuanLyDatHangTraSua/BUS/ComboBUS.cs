using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.BUS
{
    public class ComboBUS
    {
        private static ComboBUS instance;

        public static ComboBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ComboBUS();
                return ComboBUS.instance;
            }

            private set
            {
                ComboBUS.instance = value;
            }
        }

        private ComboBUS() { }

        public List<Combo> loadListCombo(int idUser,ref int totalPrice)
        {
            totalPrice = 0;
            List<Combo> lcb = new List<Combo>();
            List<Order> listOrder = OrderBUS.Instance.loadListOrderByUserId(idUser);
            foreach(Order order in listOrder)
            {
                Drink drink = DrinkBUS.Instance.getDrinkByOrderId(order.Id);
                int count = CartBUS.Instance.getCartByOrderId(order.Id).Count;
                List < Topping > listTopping = ToppingBUS.Instance.getListToppingByOrderId(order.Id);
                lcb.Add(new Combo(order.Id, drink, listTopping, count, order.Price));
                totalPrice += order.Price;
            }
            return lcb;
        }
    }
}
