using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class CartDAO
    {
        private static CartDAO instance;

        public static CartDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CartDAO();
                return CartDAO.instance;
            }

            private set
            {
                CartDAO.instance = value;
            }
        }

        private CartDAO() { }

        public bool insertCart(Cart cart, ref string error)
        {
            string query = string.Format("INSERT INTO NGOCHOANG2.GIOHANG (IDUSER,IDORDER,SOLUONG,GHICHU) VALUES ({0},{1},{2},'{3}')",
                                         cart.IdUser,cart.IdOrder,cart.Count,cart.Ghichu);
            int result =  DataProvider.Instance.ExecuteNonQuery(query, ref error);
            return result > 0;

        }
        public bool deleteCart(int idOrder, ref string error)
        {
            string query = string.Format("DELETE NGOCHOANG2.GIOHANG WHERE IDORDER ={0}", idOrder);
            int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);
            return result != 0;

        }

        public List<Cart> loadCartList(int idUser)
        {
            List<Cart> cartList = new List<Cart>();
            string query = string.Format("SELECT * FROM NGOCHOANG2.GIOHANG WHERE IDUSER = {0} ORDER BY ID ASC", idUser);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Cart cart = new Cart(item);
                cartList.Add(cart);
            }

            return cartList;
        }
        public Cart getLastCart(int idUser)
        {
            List<Cart> listCart = loadCartList(idUser);
            return listCart[listCart.Count - 1];
        }
        public Cart getCartByOrderId(int idOrder)
        {
            string query = string.Format("SELECT * FROM NGOCHOANG2.GIOHANG WHERE IDORDER={0}", idOrder);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Cart(data.Rows[0]);
        }
    }
}
