using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class Profile
    {
        [Key]
        public int ID { get; set; }

      
        public string Description { get; set; }

        public int UserID { get; set; }
        public User user { get; set; }

    }
}