using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YazilimBlog.Models;
using YazilimBlog.Models.Context;

namespace YazilimBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {

        private readonly ContextDb _contextDb;
        public BlogController(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public IActionResult Index(int page = 1, int pageSize = 6)
        {

            PagedList<Article> model = new PagedList<Article>(_contextDb.Articles.OrderByDescending(x => x.ArticlesID), page, pageSize);
        
            return View(model);
        }
       

    }
}
