using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Services
{
   public interface IContactService
   {
      IEnumerable<Contact> GetAll();
      int GetTotalCount();
      IEnumerable<Contact> GetPagedContacts(int startPage, int countPerPage, string serchString);
      PagedData<Contact> GetContacts(int currentPage, int pageSize, string searchString);
      Contact Get(int contactId);
      int Insert(Contact contact);
      void Delete(int contactId);
      void Update(Contact contact);
   }
}
