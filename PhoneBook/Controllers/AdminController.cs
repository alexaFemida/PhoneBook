using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;
using PhoneBook.Attributes;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Controllers
{
   [AdminAuthorize]
   public class AdminController : Controller
   {
      readonly IContactService _contactService;
      readonly IZipLocationService _zipLocationService;
       
      public AdminController(IContactService contactService, IZipLocationService zipLocationService)
      {
         _contactService = contactService;
         _zipLocationService = zipLocationService;
      }
      public ActionResult Index()
      {
         return View();
      }
      public ActionResult AjaxHandler(jQueryDataTableParamModel param)
      {
         var allContacts = _contactService.GetAll().ToList();
         var displayedCompanies = _contactService.GetPagedContacts(
            param.iDisplayStart, param.iDisplayLength, param.sSearch);

         var result = from c in displayedCompanies
                      select new[] { c.FirstName.ToString(), c.LastName.ToString(), c.UserName, c.Password, c.Street, c.PhoneNumber, c.ZipLocation.City.ToString(), c.RoleName, "<a style='font-family:arial' href='" + "/Admin/Edit/ " + c.UserId + "' />Edit</a>|<a style='font-family:arial' href='" + "/Admin/Delete/" + c.UserId + "' />Delete</a>" };

         return Json(new
         {
            sEcho = param.sEcho,
            iTotalRecords = allContacts.Count(),
            iTotalDisplayRecords = allContacts.Count(),
            aaData = result
         },
                             JsonRequestBehavior.AllowGet);
      }

      public int AddData(string firstName, string lastName, string userName, string password, string street, string phoneNumber, string locationId, string roleName)
      {
         var contact = new Contact()
         {
            FirstName = firstName,
            LastName = lastName,
            UserName = userName,
            Password =  password,
            Street = street,
            PhoneNumber = phoneNumber,
            ZipLocationId = Convert.ToInt32(locationId),
            RoleName = roleName
         };
         return _contactService.Insert(contact);
      }
      public ActionResult About()
      {
         ViewBag.Message = "Your application description page.";

         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Your contact page.";

         return View();
      }
      public ActionResult Edit(int id)
      {
         var contact = _contactService.Get(id);
         ViewBag.LocationId = new SelectList(_zipLocationService.GetAll(), "Id", "City", contact.ZipLocationId);
        
          return View(contact);
      }

      [HttpPost]
      public ActionResult Edit(Contact contact)
      {
         try
         {
            if (ModelState.IsValid)
            {
                ViewBag.LocationId = new SelectList(_zipLocationService.GetAll(), "Id", "City", contact.ZipLocationId);
               _contactService.Update(contact);
               return RedirectToAction("Index");
            }
         }
         catch (DataException)
         {
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
         }
         return View(contact);
      }
      public ActionResult Delete(int id, bool? saveChangesError)
      {
         if (saveChangesError.GetValueOrDefault())
         {
            ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
         }
         Contact contact = _contactService.Get(id);
         return View(contact);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
         try
         {
            _contactService.Delete(id);
         }
         catch (DataException)
         {
            return RedirectToAction("Delete",
                new RouteValueDictionary { 
                { "id", id }, 
                { "saveChangesError", true } });
         }
         return RedirectToAction("Index");
      }
   }
}