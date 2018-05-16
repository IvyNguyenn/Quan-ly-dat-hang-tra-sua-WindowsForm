using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class ToppingDAO
    {
        private static ToppingDAO instance;

        public static ToppingDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ToppingDAO();
                return ToppingDAO.instance;
            }

            private set
            {
                ToppingDAO.instance = value;
            }
        }

        private ToppingDAO() { }
        
        public List<Topping> getListTopping()
        {
            List<Topping> listTopping = new List<Topping>();
            string query = string.Format("SELECT * FROM NGOCHOANG2.THEM ORDER BY ID");
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Topping topping = new Topping(item);
                listTopping.Add(topping);
            }
            return listTopping;
        }
        public DataSet getListToppingDS()
        {
            return DataProvider.Instance.ExecuteQueryDS("SELECT TENHAT FROM NGOCHOANG2.THEM");
        }
        public List<Topping> getListToppingByOrderId(int idOrder)
        {
            List<Topping> listTopping = new List<Topping>();
            string query = string.Format("SELECT * FROM NGOCHOANG2.THEM T, NGOCHOANG2.CHITIETTHEM C WHERE T.ID=C.IDTHEM AND C.IDORDER={0} ORDER BY ID", idOrder);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Topping topping = new Topping(item);
                listTopping.Add(topping);
            }
            return listTopping;
        }
        public bool updateTopping(Topping topping, ref string error)
        {
            try
            {
                //string query = string.Format("UPDATE v_THEM SET TENHAT='{0}',DONGIA={1},,GHICHU='{2}' WHERE id={3}",
                //                              topping.Name,topping.Price,topping.Ghichu,topping.Id);
                //int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);
                //return result > 0;

                string query = string.Format("NGOCHOANG2.SP_updateThem TENHAT$ DONGIA$ GHICHU$ ID$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { topping.Name, topping.Price, topping.Ghichu, topping.Id });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool insertTopping(Topping topping, ref string error)
        {
            try
            {
                //string query = string.Format("INSERT INTO V_THEM (TENHAT,DONGIA,GHICHU) VALUES ('{0}',{1},'{2}')",
                //                            topping.Name,topping.Price,topping.Ghichu);
                //int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);
                //return result > 0;

                string query = string.Format("NGOCHOANG2.SP_insertThem TENHAT$ DONGIA$ GHICHU$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { topping.Name, topping.Price, topping.Ghichu });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool deleteTopping(int id, ref string error)
        {
            try
            {
                //string query = string.Format("DELETE FROM V_THEM WHERE ID = {0}", id);
                //int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);
                //return result > 0;

                string query = string.Format("NGOCHOANG2.SP_deleteThem ID$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { id });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public int testFunction()
        {
            string query = "NGOCHOANG2.fn_checkAddBill";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int result = int.Parse(data.Rows[0].ToString());

            return result;
        }
    }
}
