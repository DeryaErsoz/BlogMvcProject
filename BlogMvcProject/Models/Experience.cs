using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class Experience
    {
        public int ID { get; set; }

        public string TitleofJob { get; set; }

        public string Company { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        //Foreign Key
        public int UserID { get; set; }
        public  User user { get; set; }
    }
}