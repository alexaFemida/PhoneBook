using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
      readonly IContactService _contactService;
      readonly IZipLocationService _zipLocationService;

      public HomeController(IContactService contactService, IZipLocationService zipLocationService)
      {
         _contactService = contactService;
         _zipLocationService = zipLocationService;
      }
        //
        // GET: /Home/
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
                         select new[] { c.FirstName, c.LastName, c.Street, c.PhoneNumber, c.ZipLocation.City };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allContacts.Count(),
                iTotalDisplayRecords = allContacts.Count(),
                aaData = result
            },
                                JsonRequestBehavior.AllowGet);
        }
	}
}