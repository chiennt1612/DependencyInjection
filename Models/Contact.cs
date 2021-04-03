using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public class Contact
    {
        public long ID { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Mobile { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

       public string Content { get; set; }
    }
}