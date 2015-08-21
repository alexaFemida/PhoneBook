using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace PhoneBook.Models
{
      [Table("Contact")]
   public class Contact : IUser
      {
         [Key]
         public int UserId { get; set; }
         [Required]
         [MaxLength(50)]
         public string FirstName { get; set; }
         [Required]
         [MaxLength(50)]
         public string LastName { get; set; }
         public string UserName { get; set; }
         public string Password { get; set; }
         
         [NotMapped]
         public string PasswordHash { get; set; }
         [NotMapped]
         public string Id
         {
            get { return UserId.ToString(); }
         }
         public string Street { get; set; }
         public string PhoneNumber { get; set; }
         public int ZipLocationId { get; set; }
         public string RoleName { get; set; }
         [ForeignKey("ZipLocationId")]
         public virtual ZipLocation ZipLocation { get; set; }
   }
}