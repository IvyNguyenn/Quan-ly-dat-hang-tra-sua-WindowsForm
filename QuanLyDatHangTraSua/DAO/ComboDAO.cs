using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class ComboDAO
    {
        private static ComboDAO instance;

        public static ComboDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ComboDAO();
                return ComboDAO.instance;
            }

            private set
            {
                ComboDAO.instance = value;
            }
        }

        private ComboDAO() { }

        public int insertCombo(Bill bill, ref string error)
        {
            //string query = string.Format("EXECUTE sp_addOrder({0},{1},{2})", idthucUong, idtopping, count);
            //return DataProvider.Instance.ExecuteNonQuery(query, ref error);

            string query = string.Format("INSERT INTO HOADON (IDUSER,NGAY,TONGTIEN) VALUES ({0},SYSDATE,{1})",
                                         bill.IdCustomer, bill.Price);
            return DataProvider.Instance.ExecuteNonQuery(query, ref error);


        }
        
        public List<Combo> loadComboList()
        {
            List<Combo> comboList = new List<Combo>();
            string query = "SELECT * FROM HOADON ORDER BY ID ASC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Combo combo = new Combo(item);
                comboList.Add(combo);
            }

            return comboList;
        }
        public Combo getLastcombo()
        {
            List<Combo> listCombo = loadComboList();
            return listCombo[listCombo.Count - 1];
        }
    }
}
