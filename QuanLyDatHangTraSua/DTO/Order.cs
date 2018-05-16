using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class Order
    {
        private int id;
        private int idDrink;
        private int price;
        private string ghichu;

        public int Id { get => id; set => id = value; }
        public int IdDrink { get => idDrink; set => idDrink = value; }
        public int Price { get => price; set => price = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }

        public Order(int id, int idDrink, int price, string ghichu)
        {
            this.Id = id;
            this.IdDrink = idDrink;
            this.Price = price;
            this.Ghichu = ghichu;
        }

        public Order(DataRow row)
        {
            this.Id = Convert.ToInt32(row["Id"]);
            this.IdDrink = Convert.ToInt32(row["IDTHUCUONG"]);
            this.Price = Convert.ToInt32(row["TONGTIEN"]);
            this.Ghichu = row["GHICHU"].ToString();
        }
        
    }
}
