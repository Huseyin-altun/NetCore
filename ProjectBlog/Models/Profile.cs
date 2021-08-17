using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models
{
    public class Profile
    {
        [Key]
        public int ProfileID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CoverImage { get; set; }
        public string About { get; set; }
    }
}
