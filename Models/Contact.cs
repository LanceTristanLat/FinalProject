using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid format.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Required field.")]
        public string ContactNum { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
