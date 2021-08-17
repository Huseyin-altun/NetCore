using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models
{
    public class Message
    {

        [Key]
        public int MessageID { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
        public string Messages { get; set; }
    }
}
