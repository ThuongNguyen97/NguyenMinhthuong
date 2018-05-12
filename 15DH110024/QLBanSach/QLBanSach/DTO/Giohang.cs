using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLBanSach.DAO;
using QLBanSach.DAO._Sach;

namespace QLBanSach.DTO
{
    public class Giohang
    {
        ThuVien tv = new ThuVien();
        ConnectClass cc = new ConnectClass();
        public int Masach { set; get; }
        public string Tensach { set; get; }
        public string Anhbia { set; get; }
        public Double Dongia { set; get; }
        public int Soluong { set; get; }
        public Double ThanhTtien
        {
            get { return Soluong * Dongia; }
        }

        public Giohang(int Masach)
        {
            this.Masach = Masach;
            SACH sach = tv.getSach(Masach);
            Tensach = sach.Tensach;
            Anhbia = sach.Hinhminhhoa;
            Dongia = double.Parse(sach.Dongia.ToString());
            Soluong = 1;
        }
    }
}