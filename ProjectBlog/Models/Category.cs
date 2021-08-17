using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<ArticleCategory> ArticleCategory { get; set; }

    }
}
