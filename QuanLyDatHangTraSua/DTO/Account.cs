using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DTO
{
    public class Account
    {
        private int id;
        private string userName;
        private string passWord;
        private string hoten;
        private DateTime ngaysinh;
        private string sdt;
        private string diachi;
        private int role;

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public int Role { get => role; set => role = value; }
        public int Id { get => id; set => id = value; }

        public Account(int id,string userName, string passWord, 
            string hoten, DateTime ngaysinh, string sdt, string diachi, int role)
        {
            this.Id = id;
            this.UserName = userName;
            this.PassWord = passWord;
            this.Hoten = hoten;
            this.Ngaysinh = ngaysinh;
            this.Sdt = sdt;
            this.Diachi = diachi;
            this.Role = role;
        }
        public Account (Account cus)
        {
            this.Id = cus.Id;
            this.UserName = cus.UserName;
            this.Hoten = cus.Hoten;
            this.Ngaysinh = cus.Ngaysinh;
            this.Sdt = cus.Sdt;
            this.Diachi = cus.Diachi;
            this.Role = cus.Role;
        }
        public Account()
        {

        }
        public Account(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.UserName = row["UserName"].ToString();
            this.PassWord = row["PassWord"].ToString();
            this.Hoten = row["Hoten"].ToString();
            this.Ngaysinh = (DateTime)row["NgSinh"];
            this.Sdt = row["SDT"].ToString();
            this.Diachi = row["Diachi"].ToString();
            this.Role = Convert.ToInt32(row["ROLE"]);
        }

       
    }
}
