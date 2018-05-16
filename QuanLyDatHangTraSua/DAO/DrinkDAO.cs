using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class DrinkDAO
    {
        private static DrinkDAO instance;

        public static DrinkDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DrinkDAO();
                return DrinkDAO.instance;
            }

            private set
            {
                DrinkDAO.instance = value;
            }
        }

        private DrinkDAO() { }
        
        public DataTable getListDrink()
        {
            string query = string.Format("SELECT * FROM TABLE( NGOCHOANG2.fn_getListDrink)");
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Drink getDrinkByOrderId(int idorder)
        {
            string query = string.Format("SELECT * from NGOCHOANG2.ThucUong T, NGOCHOANG2.ORDERS O WHERE T.ID=O.IDTHUCUONG AND O.ID = {0}", idorder);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            Drink drink = new Drink(data.Rows[0]);
            return drink;
        }

        public List<Drink> getListDrinkByCategoryId(int categoryId)
        {
            List<Drink> listDrink = new List<Drink>();
            string query = string.Format("SELECT * FROM NGOCHOANG2.THUCUONG T WHERE T.IDLTHUCUONG={0} ORDER BY idLThucUong", categoryId);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);
                listDrink.Add(drink);
            }
            return listDrink;
        }

        public DataSet getListDrinkDS()
        {
            return DataProvider.Instance.ExecuteQueryDS("SELECT tenThucUong from NGOCHOANG2.THUCUONG");
        }

        public bool updateDrink(Drink drink, ref string error)
        {
            try
            {
                //string query = string.Format("UPDATE v_THUCUONG set tenThucUong='{0}',IDLTHUCUONG={1},DONGIA={2},GhiChu='{3}' WHERE id={4}",
                //                              drink.Name, drink.IdCategory, drink.Price, drink.Ghichu, drink.Id);
                //int result = DataProvider.Instance.ExecuteNonQuery(query,ref error);
                //return result > 0;

                string query = string.Format("NGOCHOANG2.SP_updateThucUong tenThucUong$ IDLTHUCUONG$ DONGIA$ GhiChu$ ID$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { drink.Name, drink.IdCategory, drink.Price, drink.Ghichu, drink.Id });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool insertDrink(Drink drink, ref string error)
        {
            try
            {
                //string query = string.Format("INSERT INTO V_THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('{0}',{1},{2},'{3}')",
                //                            drink.Name, drink.IdCategory, drink.Price, drink.Ghichu);
                //int result = DataProvider.Instance.ExecuteNonQuery(query,ref error);
                //return result > 0;

                string query = string.Format("NGOCHOANG2.SP_insertThucUong tenThucUong$ IDLTHUCUONG$ DONGIA$ GHICHU$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { drink.Name, drink.IdCategory, drink.Price, drink.Ghichu });
                return result != 0;

            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool deleteDrink(int id, ref string error)
        {
            try
            {
                //string query = string.Format("DELETE V_THUCUONG WHERE ID={0}", id);
                //int result = DataProvider.Instance.ExecuteNonQuery(query,ref error);
                //return result > 0;

                string query = string.Format("NGOCHOANG2.sp_deleteThucUong ID$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { id });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
