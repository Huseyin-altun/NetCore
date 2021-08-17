
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YazilimBlog.Models;
using YazilimBlog.Models.Context;

namespace YazilimBlog.Controllers
{
    public class PanelController : Controller
    {


        private readonly ContextDb _contextDb;

        private readonly INotyfService _notyf;
        public PanelController(ContextDb contextDb, INotyfService notyf)
        {
                _notyf = notyf;
                _contextDb = contextDb;
        }

        public IActionResult pp(int id)
        {


            var category = _contextDb.Articles.Where(s => s.ArticlesID == id).FirstOrDefault();
            if (category.Star == 1)
            {
                category.Star = 0;
                _contextDb.Update(category);
                _contextDb.SaveChanges();
                _notyf.Success("Başarılı işlem Artık Popüler Değil", 4);
                return RedirectToAction("Yazilar");
            }
            category.Star = 1;
            _contextDb.Update(category);
            _notyf.Success("Başarılı işlem Popüler Oldu ", 4);
            _contextDb.SaveChanges();
            return RedirectToAction("Yazilar");

        }
        public IActionResult Index()
        {
    

            var articles = _contextDb.Articles.ToList();
            ViewBag.a = articles.Count();
            return View(articles);
        }


        public IActionResult Mesaj(int page = 1, int pageSize = 6)
        {
         
            PagedList<Message> model = new PagedList<Message>(_contextDb.Messages.OrderByDescending(x=>x.MessageID), page, pageSize);

            return View(model);
        }



        public IActionResult Yazilar(int page = 1, int pageSize = 6)
        {
         
            PagedList<Article> model = new PagedList<Article>(_contextDb.Articles.OrderByDescending(x => x.ArticlesID), page, pageSize);
         
            return View(model);
        }
    
        [HttpGet]
        public IActionResult YaziEkle()
        {

   
   
            ViewBag.CatName = new SelectList(_contextDb.Categories, "CategoryID", "CategoryName");
     
            return View();
        }


        [HttpPost]
        public IActionResult YaziEkle(Article article,ManipulationArticle mart, ArticleCategory art)
        {
            ViewBag.CatName = new SelectList(_contextDb.Categories, "CategoryID", "CategoryName");
            if (!ModelState.IsValid)
            {
                _notyf.Warning("Bilgiler Eksık", 4);
                return View();
            }
    
            int ctgryid=mart.Key;


          
            art.CategoryID = ctgryid;





            var social = _contextDb.Articles.Add(article);



            _contextDb.SaveChanges();
            art.ArticlesID = _contextDb.Articles.Max(u => u.ArticlesID);
            var a = _contextDb.ArticleCategories.Add(art);
            _contextDb.SaveChanges();
            _notyf.Success("Başarılı Bir Şekilde Eklendi", 4);
            return RedirectToAction("Yazilar");
        }

 

       [HttpGet]
        public IActionResult YaziGuncelle(int id)
        {



 


            ViewBag.CatName = new SelectList(_contextDb.Categories, "CategoryID", "CategoryName");
            var articleS = _contextDb.Articles.Where(s => s.ArticlesID == id).FirstOrDefault();

            return View(articleS);
        }

        [HttpPost]
        public IActionResult YaziGuncelle(Article article, ArticleCategory art)
        {

            ViewBag.CatName = new SelectList(_contextDb.Categories, "CategoryID", "CategoryName");

            if (!ModelState.IsValid)
            {
                _notyf.Warning("Eksik Yada Hatalı Alanlar Var", 3);
                return View();
            }


            int catid = article.Stat;
            art.ArticlesID = article.ArticlesID;
            art.CategoryID = catid;

            if (art.CategoryID!=0)
            {
                var a = _contextDb.ArticleCategories.Update(art);
            }
            

            article.Date= DateTime.Parse(DateTime.Now.ToShortDateString()); 
            _contextDb.Update(article);
            _contextDb.SaveChanges();
            _notyf.Success("Başarılı Bir Şekilde Güncelendi", 3);
            return RedirectToAction("Yazilar");

        }


        public IActionResult YaziSil(int id)
        {

            _notyf.Success("Başarılı Bir Şekilde Silindi", 3);
            var article = _contextDb.Articles.Where(s => s.ArticlesID == id).FirstOrDefault();

            _contextDb.Remove(article);

            _contextDb.SaveChanges();
            return RedirectToAction("Yazilar");
        }

        public IActionResult Kategori(int page = 1, int pageSize = 6)
        {
            PagedList<Category> model = new PagedList<Category>(_contextDb.Categories.OrderByDescending(x => x.CategoryID), page, pageSize);

            return View(model);
        }


        [HttpGet]
        public IActionResult KategoriGuncele(int id)
        {
         
            var articleS = _contextDb.Categories.Where(s => s.CategoryID == id).FirstOrDefault();

            return View(articleS);
        }


        [HttpPost]
        public IActionResult KategoriGuncele(Category category )
        {


            if (!ModelState.IsValid)
            {
                _notyf.Warning("Başarısız Veriler Eksik", 4);
                return View();
            }


            _notyf.Success("Başarılı işlem Kategori Güncelendi", 4);

            _contextDb.Update(category);
            _contextDb.SaveChanges();
            return RedirectToAction("Kategori");

        }


        public IActionResult KategoriSil(int id)
        {


            var category = _contextDb.Categories.Where(s => s.CategoryID == id).FirstOrDefault();

            _contextDb.Remove(category);

            _contextDb.SaveChanges();
            return RedirectToAction("Kategori");
        }

        [HttpGet]
        public IActionResult KategoriEkle()
        {



            var categories = _contextDb.Categories;

        



            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(Category category)
        {



            if (!ModelState.IsValid)
            {
                return View();
            }


            _contextDb.Add(category);



            _contextDb.SaveChanges();

            _notyf.Success("Başarılı işlem Kategori Eklendi", 4);
            return RedirectToAction("Kategori");
        }


   



      


    }
}
