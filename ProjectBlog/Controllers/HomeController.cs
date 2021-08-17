using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YazilimBlog.Models;
using YazilimBlog.Models.Context;

namespace YazilimBlog.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ContextDb _contextDb;
        public HomeController(ContextDb contextDb, INotyfService notyf)
        {

            _notyf = notyf;
            _contextDb = contextDb;
        }
        [HttpGet]
        public IActionResult Index()
        {
          
            return View();

        }
        [HttpPost]
        public IActionResult Index(Message message)
        {
            _notyf.Success("Mesajınız Başarılı bir şekilde gönderildi", 4);
            var social = _contextDb.Messages.Add(message);
            _contextDb.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BlogDetails(int id)
        {

            var article = _contextDb.Articles.Where(s => s.ArticlesID == id).FirstOrDefault();

            return View(article);
        }

        [HttpGet]
        public IActionResult CategoryList(int id)
        {



            var commentsOfMember = _contextDb.ArticleCategories
                .Where(mc => mc.ArticlesID == id)
                .Select(mc => mc.Category)
                .ToList();

            return View(commentsOfMember);
        }

        public PartialViewResult SocialIcon()
        {

            var socialMedias = _contextDb.Socials.ToList();

            return PartialView(socialMedias);
        }

        public IActionResult BlogFulList()
        {
  




            var blogfull = _contextDb.Articles.OrderByDescending(x => x.Date).ToList();

            return View(blogfull);
        }


        public List<Category> GetCategory(int id)
        {

            return _contextDb.Articles.Join(_contextDb.ArticleCategories, artic => artic.ArticlesID, articcategory => articcategory.ArticleCategoryID,
                   (art, artcat) => new
                   {
                       artic = art,
                       articcategory = artcat
                   }).Join(_contextDb.Categories, twotable => twotable.articcategory.CategoryID, category => category.CategoryID,
                   (artcat, cat) => new
                   {
                       artic = artcat.artic,
                       category = cat,
                       articcategory = artcat.articcategory
                   }).Where(I => I.artic.ArticlesID == id).Select(I => new Category
                   {
                       CategoryName = I.category.CategoryName,
                       CategoryID = I.category.CategoryID

                   }).ToList();
        }



    }
}
