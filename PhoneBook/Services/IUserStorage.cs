using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Services
{
   interface IUserStorage
   {
      Contact GetByNameAndPassword(string userName, string password);
   }
}
