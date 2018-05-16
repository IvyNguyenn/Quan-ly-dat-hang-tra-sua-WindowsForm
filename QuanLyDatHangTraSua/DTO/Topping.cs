using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class Topping
    {
        private int id;
        private string name;
        private int price;
        private string ghichu;

        public Topping(int id, string name, int price,string ghichu)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.Ghichu = ghichu;
        }

        public Topping(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Name = row["TENHAT"].ToString();
            this.Price = Convert.ToInt32(row["DONGIA"]);
            this.Ghichu = row["ghichu"].ToString();
        }

        public Topping() { }


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
    }
}
