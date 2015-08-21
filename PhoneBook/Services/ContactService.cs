using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PhoneBook.DB_Access;
using PhoneBook.Models;

namespace PhoneBook.Services
{
   public class ContactService : IContactService
   {
      public IEnumerable<Contact> GetAll()
      {
         using (var dataContext = new ApplicationDbContext())
         {
            return dataContext.Contacts.ToList();
         }
      }

      public int GetTotalCount()
      {
         using (var dataContext = new ApplicationDbContext())
         {
            var contacts = dataContext.Contacts.OrderBy(p => p.FirstName);
            return contacts.Count();
         }
      }

      public IEnumerable<Contact> GetPagedContacts(int startPage, int countPerPage, string searchString)
      {
         using (var dataContext = new ApplicationDbContext())
         {
            var contacts = dataContext.Contacts.Include("ZipLocation").Select(x=>x);
            if (!String.IsNullOrEmpty(searchString))
            {
               contacts = contacts.Where(s => s.LastName.Contains(searchString)||
                                              s.FirstName.Contains(searchString)||
                                              s.UserName.Contains(searchString)||
                                              s.Street.Contains(searchString)||
                                              s.PhoneNumber.Contains(searchString)||
                                              s.RoleName.Contains(searchString)
                                              ).OrderBy(x=>x.UserId);
            }
            else{
              contacts = contacts.OrderBy(x => x.UserId);
            }
            return contacts.Skip(startPage).Take(countPerPage).ToList();
         }
      }

      public PagedData<Contact> GetContacts(int currentPage, int pageSize, string searchString)
      {
         using (var dataContext = new ApplicationDbContext())
         {
            var contacts = dataContext.Contacts.OrderBy(p => p.UserId);

            if (!String.IsNullOrEmpty(searchString))
            {
               contacts = (IOrderedQueryable<Contact>)contacts.Where(s => s.UserName.Contains(searchString));
            }

            int totalItemsCount = contacts.Count();

            return new PagedData<Contact>
            {
               TotalItemsCount = totalItemsCount,
               CurrentPage = currentPage,
               PageSize = pageSize,
               Data = contacts.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
            };
         }
      }

      public Contact Get(int contactId)
      {
         using (var dataContext = new ApplicationDbContext())
         {
            return dataContext.Contacts.FirstOrDefault(p => p.UserId == contactId);
         }
      }

      public int Insert(Contact contact)
      {
         using (var dataContext = new ApplicationDbContext())
         {
            dataContext.Contacts.Add(contact);
            dataContext.SaveChanges();
            return Convert.ToInt32(contact.UserId);
         }
      }

      public void Delete(int contactId)
      {
         using (var dataContext = new ApplicationDbContext())
         {
            var contactToDelete = new Contact() { UserId = contactId };
            dataContext.Contacts.Attach(contactToDelete);
            dataContext.Contacts.Remove(contactToDelete);
            dataContext.SaveChanges();
         }
      }

      public void Update(Contact contact)
      {
         using (var dataContext = new ApplicationDbContext())
         {
            dataContext.Contacts.AddOrUpdate(contact);
            dataContext.SaveChanges();
         }
      }
   }
}