using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities1 db=new MvcDbStokEntities1();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler=db.Tbl_Kategoriler.ToList(); //DB nesnemdeki Kategorilerin içindeki veriyi listeleme
            var degerler = db.Tbl_Kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]   //GET methodu kullanıldığında istekler URL kısmında gönderilir. Gönderilen bilgiler URL’de görüntülendiği için             güvenlik riski yüksektir ancak POST metoduna göre daha hızlıdır.
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]    //Ekle butonuna bastığımda bu işlemi gerçekleştirmek için 
                     // POST metodu ise URL'de görüntülenmesi istemediğimiz istekler için kullanılır.
        public ActionResult YeniKategori(Tbl_Kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Tbl_Kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            db.Tbl_Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Tbl_Kategoriler.Find(id);
            return View("KategoriGetir", ktgr);

        }
        public ActionResult Guncelle(Tbl_Kategoriler p1)
        {
            var ktg = db.Tbl_Kategoriler.Find(p1.KategoriID);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}