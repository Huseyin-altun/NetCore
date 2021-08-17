using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YazilimBlog.Models;
using YazilimBlog.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace YazilimBlog.ViewCompoents
{
    public class BlogTop : ViewComponent
    {
        private readonly ContextDb _contextDb;
        public BlogTop(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public IViewComponentResult Invoke()
        {
         
            var articles = _contextDb.Articles.OrderByDescending(f => f.ArticlesID).Take(6).ToList();
            
         
         






            // article id artcatry id ==  2 tane cıkacak 
            // id dızıde toplasam 
            // where uyusan category ısımlerını getırsem 






            return View(articles);

        }



    }



}
