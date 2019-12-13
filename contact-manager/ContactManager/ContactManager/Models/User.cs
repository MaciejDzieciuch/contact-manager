using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManager.Models
{
    public enum CategoryType { Business, Private, Other }

    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Surname { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[@#!$%^()*&+=]).*$", ErrorMessage = "Invalid password format(Required: at least eight characters, one uppercase, one lowercase, special character)")]
        public String Password { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        [Phone]
        public String PhoneNumber { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }
    }
}