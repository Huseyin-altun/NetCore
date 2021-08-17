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
    public class PopularPost : ViewComponent
    {
        private readonly ContextDb _contextDb;
        public PopularPost(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public IViewComponentResult Invoke()
        {
         
            var articles = _contextDb.Articles.OrderByDescending(f => f.ArticlesID).Take(3).Where(x=>x.Star==1).ToList();
            
       



            return View(articles);

        }



    }



}
