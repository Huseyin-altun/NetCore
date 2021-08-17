using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models
{
    public class ManipulationArticle
    {

        public int ArticlesID { get; set; }
     
        public string WriteTitle { get; set; }
     
        public string Write { get; set; }

        public string WriteLength { get; set; }


        public string CoverImage { get; set; }

        public string Image { get; set; }
     
        public DateTime Date { get; set; }

        public int Key { get; set; }

    }
}
