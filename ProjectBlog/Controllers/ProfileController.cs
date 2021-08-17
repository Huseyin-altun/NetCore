using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YazilimBlog.Models;
using YazilimBlog.Models.Context;

namespace YazilimBlog.Controllers
{
    public class ProfileController : Controller
    {

        private readonly ContextDb _contextDb;
        public ProfileController(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        static string path;
        static string path2;
        public IActionResult ProfileDetails()
        {
            int? data = HttpContext.Session.GetInt32("Id");
           
            var article = _contextDb.Profiles.Where(s => s.ProfileID == data).FirstOrDefault();
            path = article.ProfileImage;
            path2 = article.CoverImage;
            return View(article);
        }
        [HttpPost]
        public IActionResult ProfileDetails(Profile profile, IFormFile formFile, IFormFile formFile2)
        {

   

            if (formFile != null)
            {
                var extent = Path.GetExtension(formFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                     formFile.CopyTo(stream);
                    profile.ProfileImage = randomName;
                }
            }
            else
            {
                profile.ProfileImage = path;
            }



            if (formFile2 != null)
            {
                var extent = Path.GetExtension(formFile2.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    formFile2.CopyTo(stream);
                    profile.CoverImage = randomName;
                }
            }
            else
            {
                profile.CoverImage = path2;
            }




            _contextDb.Update(profile);
            _contextDb.SaveChanges();
            return RedirectToAction("ProfileDetails", "Profile");

         
        }

    }
}
