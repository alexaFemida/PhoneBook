using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneBook.DB_Access;
using PhoneBook.Models;

namespace PhoneBook.Services
{
   public static class UserRoleService
   {
      static ApplicationDbContext _context = new ApplicationDbContext();

      public static bool IsAdmin(string userName)
      {
         var user = _context.Contacts.FirstOrDefault(x => x.UserName == userName);
         return user != null && user.RoleName == "Admin";
      }
   }
}