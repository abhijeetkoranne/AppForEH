using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AppContacts.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public String FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public String LastName { get; set; }
        [MaxLength(50)]
        public String Email { get; set; }
        [MaxLength(15)]
        public String Phone { get; set; }
        public bool Status { get; set; }
        public String Address { get; set; }
    }
}