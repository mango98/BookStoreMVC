using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBookStore.Models;
using PagedList;
using PagedList.Mvc;

namespace MVCBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        DBQuanLyBanSachDataContext data = new DBQuanLyBanSachDataContext();

        private List<SACH> Laysachmoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        // GET: BookStore
        public ActionResult Index(int ? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);

            var sachmoi = Laysachmoi(15);
            return View(sachmoi.ToPagedList(pageNum,pageSize));
        }

        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }

        public ActionResult Nhaxuatban()
        {
            var nhaxuatban = from cd in data.NHAXUATBANs select cd;
            return PartialView(nhaxuatban);
        }

        public ActionResult SPtheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }

        public ActionResult SPtheonhaxuatban(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }

        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes where s.Masach == id select s;
            return View(sach.Single()); 
        }
    }
}