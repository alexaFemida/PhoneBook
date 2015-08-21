using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
   public class ZipLocation
   {
      [Key]
      public int Id { get; set; }
      [Required]
      [MaxLength(50)]
      public string City { get; set; }
      public string Region { get; set; }
      public string Code { get; set; }
   }
}