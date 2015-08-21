using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneBook.DB_Access;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public class ZipLocationService : IZipLocationService
    {
        public IEnumerable<ZipLocation> GetAll()
        {
            using (var dataContext = new ApplicationDbContext())
            {
                return dataContext.ZipLocations.ToList();
            }
        }
    }
}