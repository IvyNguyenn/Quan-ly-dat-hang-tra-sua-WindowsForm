using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class Drink
    {
        private int id;
        private string name;
        private int idCategory;
        private int price;
        private string ghichu;
        private int maHinh;

        public Drink(int id, string name, int idCategory, int price, string ghichu)
        {
            this.Id = id;
            this.Name = name;
            this.IdCategory = idCategory;
            this.Price = price;
            this.Ghichu = ghichu;
        }

        public Drink(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Name = row["tenThucUong"].ToString();
            this.IdCategory = Convert.ToInt32(row["idLThucUong"]);
            this.Price = Convert.ToInt32(row["donGia"]);
            this.Ghichu = row["ghichu"].ToString();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int Price { get => price; set => price = value; }
        public int MaHinh { get => maHinh; set => maHinh = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
    }
}
