using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }

       public DbSet<SocialMedia> Socials { get; set; }
        public DbSet<Article> Articles { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        internal IEnumerable<object> GetCategory(int articlesID)
        {
            throw new NotImplementedException();
        }
    }
}
