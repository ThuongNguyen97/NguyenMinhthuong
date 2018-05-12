using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using QLBanSach.DAO;
using QLBanSach.DAO._Sach;
using QLBanSach.DTO;

namespace QLBanSach.Controllers
{
    public class BookStoreController : Controller
    {
        ThuVien tv = new ThuVien();
        ConnectClass cc = new ConnectClass();
        // GET: BookStore
        
        public ActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            List<SACH> sachmoi = tv.LoadSach(24);
            return View(sachmoi.ToPagedList(pageNum,pageSize));
        }
        public ActionResult ChuDe()
        {
            return PartialView(tv.LoadChuDe());
        }
        public ActionResult NhaXuatBan()
        {
            return PartialView(tv.LoadNHAXUATBAN());
        }
        public ActionResult SanPhamTheoChuDe(int id)
        {
            return PartialView(cc.LoadSachCD(id));
        }
        public ActionResult SanPhamTheoNXB(int id)
        {
            return PartialView(cc.LoadSachNXB(id));
        }
        public ActionResult Details(int id)
        {
            return View(tv.getSach(id));
        }
    }
}