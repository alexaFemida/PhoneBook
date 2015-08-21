using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using PhoneBook.Services;

namespace PhoneBook.Modules
{
   public class ContactModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder.RegisterType<ContactService>().As<IContactService>();
         builder.RegisterType<ZipLocationService>().As<IZipLocationService>();
         base.Load(builder);
      }
   }
}