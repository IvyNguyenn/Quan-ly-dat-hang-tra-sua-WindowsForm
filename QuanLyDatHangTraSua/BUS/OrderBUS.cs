using QuanLyDatHangTraSua.DAO;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.BUS
{
    public class OrderBUS
    {
        private static OrderBUS instance;

        public static OrderBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderBUS();
                return OrderBUS.instance;
            }

            private set
            {
                OrderBUS.instance = value;
            }
        }
        
        private OrderBUS() { }

        public long tinhTienOrder(string thucUong, string topping, int count)
        {
            return OrderDAO.Instance.tinhTienOrder(thucUong,topping,count);
        }

        public bool themOrder(Order order,List<Topping> listTopping,Account account,int count, ref string error)
        {
            try
            {
                OrderDAO.Instance.insertOrder(order, ref error);
                Order lastOrder = OrderDAO.Instance.getLastOrder();
                CartDAO.Instance.insertCart(new Cart(account.Id, lastOrder.Id,count, null),ref error);
                foreach (Topping topping in listTopping)
                {
                    AddInfo addInfo = new AddInfo(lastOrder.Id, topping.Id, 1);
                    AddInfoDAO.Instance.insertAddInfo(addInfo, ref error);
                }
                return true;
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
        public int addOrder(Bill bill,List<Combo> listCombo,Account cus,ref string error)
        {
            foreach(Combo com in listCombo)
            {
                try
                {
                    Order order = new Order(1, com.Drink.Id, com.Drink.Price, com.Drink.Ghichu);
                    OrderDAO.Instance.insertOrder(order, ref error);
                    order = OrderDAO.Instance.getLastOrder();
                    BillInfo billInfo = new BillInfo(bill.Id, order.Id, com.Count);
                    BillInfoBUS.Instance.insertBillInfo(billInfo, ref error);
                    CartBUS.Instance.insertCart(new Cart(cus.Id, order.Id,com.Count, order.Ghichu),ref error);

                    foreach(Topping top in com.ListTopping)
                    {
                        AddInfo addInfo = new AddInfo(order.Id, top.Id, 1);
                        AddInfoBUS.Instance.insertAddInfo(addInfo, ref error);
                    }
                }
                catch(Exception ex)
                {
                    error = ex.Message;
                    return 0;
                }
            }
            return 1;
        }
        public List<Order> loadOrderList()
        {
            return OrderDAO.Instance.loadOrderList();
        }
        public List<Order> loadListOrderByUserId(int idUser)
        {
            return OrderDAO.Instance.loadListOrderByUserId(idUser);
        }
        public Order getLastOrder()
        {
            return OrderDAO.Instance.getLastOrder();
        }
        public List<Drink> loadOrderListDrink(Order order)
        {
            return OrderDAO.Instance.LoadOrderListDrink(order);
        }
        public List<Topping> loadOrderListTopping(Order order)
        {
            return OrderDAO.Instance.loadOrderListTopping(order);
        }
    }
}
