using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.API.Models
{
    public class State
    {
        public int Id { get; set; }

        public string StateName { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
