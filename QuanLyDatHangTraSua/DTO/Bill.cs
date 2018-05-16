using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class Bill
    {
        private int id;
        private int idCustomer;
        private DateTime date;
        private int price;
        string status;

        public Bill(int id, int idCustomer, DateTime date, int price,string status)
        {
            this.Id = id;
            this.IdCustomer = idCustomer;
            this.Date = date;
            this.Price = price;
            this.Status = status;
        }
        public Bill (DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.IdCustomer = Convert.ToInt32(row["IDUSER"]);
            this.date = (DateTime)(row["Ngay"]);
            this.Price = Convert.ToInt32(row["tongtien"]);
            this.Status = row["tinhtrang"].ToString();
        }
        public int Id { get => id; set => id = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Price { get => price; set => price = value; }
        public string Status { get => status; set => status = value; }
    }
}
