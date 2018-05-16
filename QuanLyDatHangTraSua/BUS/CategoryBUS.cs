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
    public class CategoryBUS
    {
        private static CategoryBUS instance;

        public static CategoryBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryBUS();
                return CategoryBUS.instance;
            }

            private set
            {
                CategoryBUS.instance = value;
            }
        }

        private CategoryBUS() { }

        //public DataTable GetListCategory()
        //{
        //    return CategoryDAO.Instance.GetListCategory();
        //}
        public List<Category> getListCategory()
        {
            return CategoryDAO.Instance.getListCategory();
        }
        public bool insertCategory(Category category, ref string error)
        {
            return CategoryDAO.Instance.insertCategory(category, ref error);
        }
        public bool deleteCategory(int id, ref string error)
        {
            return CategoryDAO.Instance.deleteCategory(id,ref error);
        }

        public bool updateCategory(Category category, ref string error)
        {
            return CategoryDAO.Instance.updateCategory(category, ref error);
        }

        public Category getCategoryById(int id)
        {
            return CategoryDAO.Instance.getCategoryById(id);
        }
        public Category getCategoryByName(string name)
        {
            return CategoryDAO.Instance.getCategoryByName(name);
        }
            public DataSet getListCategoryDS()
        {
            return CategoryDAO.Instance.getListCategoryDS();
        }
    }
}
