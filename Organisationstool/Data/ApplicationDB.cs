using Microsoft.EntityFrameworkCore;
using Organisationstool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Organisationstool.Data
{
    public class ApplicationDB : IdentityDbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {

        }
       


        public DbSet<Veranstaltungen> Veranstaltungen { get; set; }
        public DbSet<Organisator> Organisatoren { get; set; }
        public DbSet<Gast> Gäste { get; set; }
        public DbSet<Mitwirkende> Mitwirkenden { get; set; }
        public DbSet<M_Aufgaben> MitwirkendenAufgaben { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Buchungen> Buchungen { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<MitwirkendeAufgaben> MitwirkendeAufgaben { get; set; }










    }
}

