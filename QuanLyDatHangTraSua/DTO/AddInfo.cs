using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class AddInfo
    {
        private int idOrder;
        private int idThem;
        private int count;

        public AddInfo(int idOrder, int idThem, int count)
        {
            this.IdOrder = idOrder;
            this.IdThem = idThem;
            this.Count = count;
        }
        public AddInfo(DataRow row)
        {
            this.IdOrder = Convert.ToInt32(row["idOrder"]);
            this.IdThem = Convert.ToInt32(row["idThem"]);
            this.Count = Convert.ToInt32(row["SOLUONG "]);
        }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        public int IdThem { get => idThem; set => idThem = value; }
        public int Count { get => count; set => count = value; }
    }
}
