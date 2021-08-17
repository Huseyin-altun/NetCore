using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YazilimBlog.Controllers;
using YazilimBlog.Models;
using YazilimBlog.Models.Context;

namespace YazilimBlog.TagHelpers
{
    [HtmlTargetElement("getcategories")]
    public class CategoryName : TagHelper
    {

        ContextDb _contextDb;
        public CategoryName(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public int ArticlesID { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
         var getCat=GetCategory(ArticlesID).Select(I=>I.CategoryName);
            List<string> data = new List<string>();
            foreach (var item in getCat)
            {
                data.Add(item);
            }

            foreach (var item2 in data)
            {
                output.Content.AppendHtml("<span class='tag tag-teal'>"+item2+"</span>");
            }
          
        }
        public List<Category> GetCategory(int id)
        {
      

            return _contextDb.Articles.Join(_contextDb.ArticleCategories, artic => artic.ArticlesID,
                 articcategory => articcategory.ArticlesID,
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
