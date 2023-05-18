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
        public bool IsAdmin { get; set; }

    }
}
