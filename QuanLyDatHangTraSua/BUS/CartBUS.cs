using QuanLyDatHangTraSua.DAO;
using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.BUS
{
    public class CartBUS
    {
        private static CartBUS instance;

        public static CartBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new CartBUS();
                return CartBUS.instance;
            }

            private set
            {
                CartBUS.instance = value;
            }
        }

        private CartBUS() { }
                
        public bool insertCart(Cart cart, ref string error)
        {
            return CartDAO.Instance.insertCart(cart, ref error);
        }
        public bool deleteCart(int idOrder, ref string error)
        {
            return CartDAO.Instance.deleteCart(idOrder,ref error);
        }
        public List<Cart> loadCartList(int idUser)
        {
            return CartDAO.Instance.loadCartList(idUser);
        }
        public Cart getCartByOrderId(int idOrder)
        {
            return CartDAO.Instance.getCartByOrderId(idOrder);
        }
    }
}
