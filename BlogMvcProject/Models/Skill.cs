using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class Skill
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Percent { get; set; }

        public bool IsActive { get; set; }

        public string Icon { get; set; }
    }
}