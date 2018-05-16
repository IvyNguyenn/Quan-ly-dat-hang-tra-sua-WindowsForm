using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class Cart
    {
        private int idUser;
        private int idOrder;
        private int count;
        private string ghichu;

        public Cart(int idUser, int idOrder, int count, string ghichu)
        {
            this.IdUser = idUser;
            this.IdOrder = idOrder;
            this.Count = count;
            this.Ghichu = ghichu;
        }
        public Cart(DataRow row)
        {
            this.IdUser = Convert.ToInt32(row["idUser"]);
            this.IdOrder = Convert.ToInt32(row["idOrder"]);
            this.Count = Convert.ToInt32(row["soluong"]);
            this.Ghichu = row["ghichu"].ToString();
        }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
        public int Count { get => count; set => count = value; }
    }
}
