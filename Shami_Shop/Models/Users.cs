using Shami_Shop.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Shami_Shop.Models
{

    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(11)]
        public string MobilePhone { get; set; }
        [Required]
        [MaxLength(5)]
        public Random Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}
