using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.API.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string? MobileNumber { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        public int StateId { get; set; }

        public string? City { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual Country Country { get; set; }

    }
}
