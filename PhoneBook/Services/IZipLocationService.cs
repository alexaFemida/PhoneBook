using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IZipLocationService
    {
        IEnumerable<ZipLocation> GetAll();
    }
}
