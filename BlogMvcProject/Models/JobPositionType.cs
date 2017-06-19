using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class JobPositionType
    {
        [Key]
        public int ID { get; set; }

        public string TypeName { get; set; }

        public bool IsActive { get; set; }

        public List<Portfolio> Portfolios { get; set; }
    }
}