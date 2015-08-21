using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PhoneBook.Models;

namespace PhoneBook.DB_Access
{
    public class ApplicationDBInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            IList<ZipLocation> defaultStandards = new List<ZipLocation>();

            defaultStandards.Add(new ZipLocation() { City = "Lviv", Code = "3222", Region = "Lviv" });
            defaultStandards.Add(new ZipLocation() { City = "Kyiv", Code = "4232", Region = "Kyiv" });

            foreach (ZipLocation std in defaultStandards)
                context.ZipLocations.Add(std);

            base.Seed(context);
        }
    }
}