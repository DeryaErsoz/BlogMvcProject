using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class FeedBack
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Name Surname is required!")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Comment is required!")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Please enter valid email.")]
        public string Email{ get; set; }
    }
}