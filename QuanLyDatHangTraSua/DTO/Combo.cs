using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class Combo
    {
        private int idOrder;
        private Drink drink;
        private List<Topping> listTopping;
        private int count;
        private int price;

        public Combo(int idorder,Drink drink, List<Topping> listTopping,int count, int price)
        {
            this.IdOrder = idorder;
            this.Drink = drink;
            this.ListTopping = listTopping;
            this.Count = count;
            this.Price = price;
        }

        public Combo (DataRow row)
        {
            this.IdOrder = Convert.ToInt32(row["idorder"]);
            this.Drink = (Drink)row["drink"];
            this.ListTopping = (List<Topping>)row["listTopping"];
            this.Count = Convert.ToInt32(row["count"]);
        }

        public Drink Drink { get => drink; set => drink = value; }
        public List<Topping> ListTopping { get => listTopping; set => listTopping = value; }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
    }
}
