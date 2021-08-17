using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models
{
    public class Article
    {
        [Key]
        public int ArticlesID { get; set; }
        [StringLength(100)]
        public string WriteTitle { get; set; }
        [StringLength(100)]
        public string Write { get; set; }

        public string WriteLength { get; set; }


        public string CoverImage { get; set; }
        public int Stat { get; set; }

        public int Star { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
     
        public virtual ICollection<ArticleCategory> ArticleCategory { get; set; }
    }
}
