using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class Portfolio
    {
        [Key]
        public int ID { get; set; }       
    
        public string ProjectName { get; set; }

        public string ImagePath { get; set; }

        public string LinkofImage { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int TypeID { get; set; }
        public JobPositionType type { get; set; }
        
        public int UserID { get; set; }
        public  User user { get; set; }

    }
}