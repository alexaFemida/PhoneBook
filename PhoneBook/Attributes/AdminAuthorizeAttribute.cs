using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Models;
using PhoneBook.Services;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
namespace PhoneBook.Attributes
{
   public class AdminAuthorizeAttribute :AuthorizeAttribute
   {
      private readonly string[] allowedroles;
      public AdminAuthorizeAttribute(params string[] roles)
      {
         this.allowedroles = roles;
      }

      protected override bool AuthorizeCore(HttpContextBase httpContext)
      {
         return UserRoleService.IsAdmin(HttpContext.Current.User.Identity.GetUserName());
      }

      protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
      {
         filterContext.Result = new RedirectResult("/Account/AccessDenied");
      }
   }
}