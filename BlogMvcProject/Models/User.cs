using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string ImagePath { get; set; }

        public string JobTitle { get; set; }

        public string FaceAccount { get; set; }

        public string TwitterAccount { get; set; }

        public string LinkedinAccount { get; set; }

        public string InstagramAccount { get; set; }

        public string GoogleAccount { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ResumePath { get; set; }

        public string Location { get; set; }

        public bool Status { get; set; }


        public List<Resume> Resumes { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Profile> Profiles { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<Experience> Experiences { get; set; }



    }
}