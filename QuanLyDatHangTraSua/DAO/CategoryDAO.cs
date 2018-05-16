using QuanLyDatHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAO();
                return CategoryDAO.instance;
            }

            private set
            {
                CategoryDAO.instance = value;
            }
        }

        private CategoryDAO() { }

        public List<Category> getListCategory()
        {
            List<Category> catList = new List<Category>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM NGOCHOANG2.LOAITHUCUONG ORDER BY ID");
            foreach (DataRow item in data.Rows)
            {
                Category cat = new Category(item);
                catList.Add(cat);
            }
            return catList;
        }

        public bool insertCategory(Category category, ref string error)
        {
            try
            {
                //string query = string.Format("INSERT INTO v_LOAITHUCUONG(tenLThucUong,ghichu) VALUES ('{0}','{1}')",
                //                              category.Name, category.Ghichu);
                //int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);
                //return result > 0;
                string query = string.Format("NGOCHOANG2.sp_insertLoaiThucUong TenLThucUong$ GHICHU$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { category.Name, category.Ghichu });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool deleteCategory(int id, ref string error)
        {
            try
            {
                //string query = string.Format("DELETE V_LoaiThucuong WHERE ID={0}", id);
                //int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);
                //return result > 0;
                string query = string.Format("NGOCHOANG2.SP_DELETELoaiThucuong ID$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { id });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool updateCategory(Category category, ref string error)
        {
            try
            {
                //string query = string.Format("update v_LOAITHUCUONG set tenLThucUong='{0}',GhiChu='{1}' WHERE id={2}",
                //                             category.Name, category.Ghichu, category.Id);
                //int result = DataProvider.Instance.ExecuteNonQuery(query, ref error);
                //return result > 0;
                string query = string.Format("NGOCHOANG2.SP_updateLoaiThucUong tenLThucUong$ GhiChu$ ID$");
                int result = DataProvider.Instance.ExecuteProcedure(query, ref error, new object[] { category.Name, category.Ghichu, category.Id });
                return result != 0;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public Category getCategoryById(int id)
        {
            Category category = null;
            string query = string.Format("SELECT * FROM v_LoaiThucuong WHERE ID={0}", id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }
        public Category getCategoryByName(string name)
        {
            Category category = null;
            string query = string.Format("SELECT * FROM NGOCHOANG2.LoaiThucuong WHERE tenLThucUong ='{0}'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }
        public DataSet getListCategoryDS()
        {
            string query = "select name from v_LoaiThucuong";
            return DataProvider.Instance.ExecuteQueryDS(query);
            //return DataProvider.Instance.ExecuteQueryDS(query).Tables[0];
        }

    }
}
