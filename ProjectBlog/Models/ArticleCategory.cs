using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models
{
    public class ArticleCategory
    {
    
        public int ArticlesID { get; set; }
   
        public int CategoryID { get; set; }
        [Key]
        public int ArticleCategoryID { get; set; }
        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }

    }
}
