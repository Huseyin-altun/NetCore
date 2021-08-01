using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarListMvc.Models
{
    public class Car
    {




        [Key]
        public int CarID { get; set; }
        [Required]
        public string Model { get; set; }

      
       
        public decimal Price { get; set; }



        public bool Popular { get; set; }





    }
}
