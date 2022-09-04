using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities1 db=new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Tbl_Urunler p1)
        {
            var ktg = db.Tbl_Kategoriler.Where(m => m.KategoriID == p1.Tbl_Kategoriler.KategoriID).FirstOrDefault();
            p1.Tbl_Kategoriler = ktg;
            db.Tbl_Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var urun=db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.Tbl_Urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urun);
        }

        public ActionResult Guncelle(Tbl_Urunler p)
        {
            var urun=db.Tbl_Urunler.Find(p.UrunID); 
            urun.UrunAd=p.UrunAd;
            urun.Marka = p.Marka;
            //urun.UrunKategori=p.UrunKategori;
            var ktg = db.Tbl_Kategoriler.Where(m => m.KategoriID == p.Tbl_Kategoriler.KategoriID).FirstOrDefault();
            urun.UrunKategori = ktg.KategoriID;
            urun.Fiyat = p.Fiyat;
            urun.Stok = p.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}