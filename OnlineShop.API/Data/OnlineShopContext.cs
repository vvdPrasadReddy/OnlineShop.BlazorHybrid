using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.API.Models;

namespace OnlineShop.API.Data
{
    public class OnlineShopContext : IdentityDbContext<IdentityUser>
    {
        public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        
    }
}
