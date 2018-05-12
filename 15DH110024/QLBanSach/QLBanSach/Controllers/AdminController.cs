using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using QLBanSach.DTO;
using QLBanSach.DAO;

namespace QLBanSach.Controllers
{
    public class AdminController : Controller
    {
        ThuVien tv = new ThuVien();
        DAO._Sach.ConnectClass cc = new DAO._Sach.ConnectClass();
        DAO._Admin.ConnectClass cca = new DAO._Admin.ConnectClass();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sach(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(tv.LoadSach().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ChuDe(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(cc.LoadSachCD().ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin,FormCollection collection)
        {
            admin.UserAdmin = collection["UserAdmin"];
            admin.PassAdmin = collection["password"];
            if (String.IsNullOrEmpty(admin.UserAdmin))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(admin.PassAdmin))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {

                Admin tam = cca.GetAdmin(admin);
                if (tam != null)
                {
                    Session["TaiKhaonAdmin"] = tam;
                    return RedirectToAction("Index", "Admin");

                }
                else
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Themmoisach()
        {
            ViewBag.MaCD = new SelectList(tv.LoadChuDe(), "MaCD", "TenChude");
            ViewBag.MaNXB = new SelectList(tv.LoadNHAXUATBAN(), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        public ActionResult Themmoisach(SACH sach, HttpPostedFileBase fileupload,FormCollection collection)
        {
            ViewBag.MaCD = new SelectList(tv.LoadChuDe(), "MaCD", "TenChude");
            ViewBag.MaNXB = new SelectList(tv.LoadNHAXUATBAN(), "MaNXB", "TenNXB");

            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //Lưu tên file , lưu ý bổ sung thư viện using System.IO
                    var fileName = Path.GetFileName(fileupload.FileName);
                    //Lưu đường dẫn của file
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    int a = 0;
                    if(int.TryParse(collection["MaCD"], out a))
                    {
                        sach.MaCD = a;
                        a = 0;
                        if(int.TryParse(collection["MaNXB"],out a))
                        {
                            sach.Hinhminhhoa = fileName;
                            sach.MaNXB = a;
                            if (cc.Create(sach))
                                return RedirectToAction("Sach");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Lỗi khi thêm");
                    }
                }
                
            }
            return View();
        }
        public ActionResult Chitietsach(int id)
        {
            SACH sach = tv.getSach(id);
                if (sach == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                return View(sach);
            }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            cc.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.MaCD = new SelectList(cc.LoadSachCD(), "MaCD", "TenChude");
            ViewBag.MaNXB = new SelectList(cc.LoadSachNXB(), "MaNXB", "TenNXB");

            return View(tv.getSach(id));
        }
        [HttpPost]
        public ActionResult Edit(SACH sach,FormCollection collection)
        {
            if(ModelState.IsValid)
            {
                if (cc.Edit(sach))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi khi sửa");
                }
            }
            ViewBag.MaCD = new SelectList(cc.LoadSachCD(), "MaCD", "TenChude");
            ViewBag.MaNXB = new SelectList(cc.LoadSachNXB(), "MaNXB", "TenNXB");

            return View();
        }
        /*[HttpPost, ActionName("Xoasach")]
        public ActionResult Xacnhanxoa(int id, CHUDE chude, NHAXUATBAN nxb)
        {
            SACH sach = data.SACHes.SingleOrDefault(n => n.Masach == id);
            ViewBag.Masach = sach.Masach;
            data.SACHes.DeleteOnSubmit(sach);
            data.SubmitChanges();
            return RedirectToAction("Sach");


        }
        [HttpGet]
        public ActionResult Suasach(int id)
        {
            SACH sach = data.SACHes.SingleOrDefault(n => n.Masach == id);
            ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChude");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");

            return View(sach);
        }
        [HttpPost]
        public ActionResult Suasach(SACH sach, HttpPostedFileBase fileupload)
        {
            SACH sach1 = data.SACHes.SingleOrDefault(n => n.Masach == sach.Masach);
            sach1.Masach = sach.Masach;
            data.SACHes.DeleteOnSubmit(sach1);
            ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChude");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            var fileName = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/images"), fileName);
            fileupload.SaveAs(path);
            sach.Hinhminhhoa = fileName;
            data.SACHes.InsertOnSubmit(sach);
            data.SubmitChanges();
            return RedirectToAction("Sach");

        }*/
    }
}