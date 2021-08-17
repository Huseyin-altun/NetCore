using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models
{
    public class SocialMedia
    {
        [Key]
        public int SocialID { get; set; }
        public string SocialIcon { get; set; }

        public string SocialLink { get; set; }




    }
}
