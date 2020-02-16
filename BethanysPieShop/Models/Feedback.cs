using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "It doesn't look like valid e-mail addres.")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        public bool ContactMe { get; set; }
    }
}
