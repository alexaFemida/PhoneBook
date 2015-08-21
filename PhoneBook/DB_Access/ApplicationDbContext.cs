using System.Data.Entity;
using PhoneBook.Models;

namespace PhoneBook.DB_Access
{
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext()
         : base("PhoneBookConnectionString")
      {
         Database.SetInitializer<ApplicationDbContext>(new ApplicationDBInitializer());
         //Database.SetInitializer<ApplicationDbContext>(null);
      }
      public DbSet<Contact> Contacts { get; set; }
      public virtual DbSet<ZipLocation> ZipLocations { get; set; }     
   }
}