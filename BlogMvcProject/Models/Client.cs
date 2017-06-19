using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class Client
    {

        public int ID { get; set; }

        public string NameSurname { get; set; }

        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }
}