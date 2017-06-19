using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class Resume
    {

        public int ID { get; set; }

        [Display(Name = "School Name")]
        public string School { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int UserID { get; set; }

    }
}