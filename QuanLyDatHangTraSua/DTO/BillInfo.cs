using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class BillInfo
    {
        private int idBill;
        private int idOrder;
        private int count;

        public BillInfo(int idBill, int idOrder, int count)
        {
            this.IdBill = idBill;
            this.IdOrder = idOrder;
            this.Count = count;
        }

        public BillInfo (DataRow row)
        {
            this.IdOrder = Convert.ToInt32(row["idHoaDon"]);
            this.IdBill = Convert.ToInt32(row["idOrder"]);
            this.Count = Convert.ToInt32(row["soluong"]);
        }


        public int IdBill { get => idBill; set => idBill = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        public int Count { get => count; set => count = value; }
    }
}
