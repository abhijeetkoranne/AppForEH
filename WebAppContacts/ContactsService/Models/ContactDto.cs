using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ContactsService.Models
{
    public class ContactDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public bool Status { get; set; }
        public String Address { get; set; }


    }
}