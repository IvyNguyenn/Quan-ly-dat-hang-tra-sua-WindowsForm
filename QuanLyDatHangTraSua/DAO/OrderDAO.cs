using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderDAO();
                return OrderDAO.instance;
            }

            private set
            {
                OrderDAO.instance = value;
            }
        }

        private OrderDAO() { }

        public int insertOrder(Order order, ref string error)
        {
            string query = string.Format("INSERT INTO NGOCHOANG2.ORDERS (IDTHUCUONG,TONGTIEN,GHICHU) VALUES ({0},{1},'{2}')",
                                         order.IdDrink,order.Price,order.Ghichu);
            return DataProvider.Instance.ExecuteNonQuery(query,ref error);
        }
        public int deleteOrder()
        {
            return 1;
        }

        public long tinhTienOrder(string thucUong, string topping, int count)
        {
            string query = string.Format("NGOCHOANG2.fn_TinhTienOrder('{0}','{1}',{2})", thucUong, topping, count);
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public List<Order> loadOrderList()
        {
            List<Order> orderList = new List<Order>();
            string query = "SELECT * FROM NGOCHOANG2.ORDERS ORDER BY ID ASC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Order order = new Order(item);
                orderList.Add(order);
            }

            return orderList;
        }

        public List<Order> loadListOrderByUserId(int idUser)
        {
            List<Order> orderList = new List<Order>();
            string query = string.Format("SELECT * FROM TABLE( NGOCHOANG2.fn_getOrderByUserId({0}))", idUser);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Order order = new Order(item);
                orderList.Add(order);
            }

            return orderList;
        }

        public Order getLastOrder()
        {
            List<Order> listOrder = loadOrderList();
            return listOrder[listOrder.Count - 1];
        }
        
        public List<Drink> LoadOrderListDrink(Order order)
        {
            List<Drink> orderListDrink = new List<Drink>();
            string query = string.Format("SELECT * FROM NGOCHOANG2.DRINKS D where D.ID={0}", order.IdDrink);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);
                orderListDrink.Add(drink);
            }

            return orderListDrink;
        }

        public List<Topping> loadOrderListTopping(Order order)
        {
            List<Topping> orderListTopping= new List<Topping>();
            string query = string.Format("SELECT * FROM NGOCHOANG2.THEM D where D.ID={0}", order.IdDrink);
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
