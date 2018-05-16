using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class Category
    {
        private int id;
        private string name;
        private string ghichu;

        public Category(int id, string name,string ghichu)
        {
            this.Id = id;
            this.Name = name;
            this.Ghichu = ghichu;
        }
        public Category(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Name = row["tenLThucUong"].ToString();
            this.Ghichu = row["ghichu"].ToString();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
    }
}
