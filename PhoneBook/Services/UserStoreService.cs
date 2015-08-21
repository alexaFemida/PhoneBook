using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PhoneBook.DB_Access;
using PhoneBook.Models;

namespace PhoneBook.Services
{
      public class UserStoreService : IUserStore<Contact>,
                                      IUserPasswordStore<Contact>,
                                      IUserStorage
      {
         ApplicationDbContext _context;
         public UserStoreService(ApplicationDbContext context)
         {
            _context = context;
         }

         public Contact GetByNameAndPassword(string userName, string password)
         {
            return _context.Contacts.FirstOrDefault(x => x.UserName == userName && x.Password == password);
         
         }

         public Task CreateAsync(Contact user)
         {

            _context.Contacts.Add(user);

            _context.Configuration.ValidateOnSaveEnabled = false;

            return _context.SaveChangesAsync();


         }
         public Task DeleteAsync(Contact user)
         {
            throw new NotImplementedException();
         }
         public Task<Contact> FindByIdAsync(string userId)
         {
            throw new NotImplementedException();
         }
         public Task<Contact> FindByNameAsync(string userName)
         {
            Task<Contact> task =
            _context.Contacts.Where(apu => apu.UserName == userName)
            .FirstOrDefaultAsync();

            return task;
         }
         public Task UpdateAsync(Contact user)
         {
            throw new NotImplementedException();
         }
         public void Dispose()
         {
            _context.Dispose();
         }
         public Task<string> GetPasswordHashAsync(Contact user)
         {
            if (user == null)
            {
               throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.Password);
         }
         public Task<bool> HasPasswordAsync(Contact user)
         {
            return Task.FromResult(user.Password != null);
         }
         public Task SetPasswordHashAsync(
           Contact user, string passwordHash)
         {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
         }
      
   }
}