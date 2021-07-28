using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PartyInvitesFriend2.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "lütfen e-mail adresinizi giriniz")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen telefon numaranızı girin")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "Lütfen katılacağınızı belirtin")]
        public bool? WillAttend { get; set; }
    }
}
