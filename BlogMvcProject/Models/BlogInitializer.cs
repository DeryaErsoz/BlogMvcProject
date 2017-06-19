using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class BlogInitializer: DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
#region  Users
            //Users sample
            List<User> users = new List<User>()
            {
                new User()
                {
                    Name ="John",
                    Surname="Doe",
                    JobTitle="Graphic Designer",
                    Email="test@gmail.com",
                    ImagePath="/folder",
                    Phone="5555555555",
                    Location="121 King St Melbourne VIC",
                    ResumePath="",
                    InstagramAccount="",
                    LinkedinAccount="",
                    FaceAccount="",
                    TwitterAccount="",
                    GoogleAccount="",
                    Status=true,
                }
            };
            foreach (var item in users)
            {
                context.Users.Add(item);
            }
            context.SaveChanges();
            #endregion
#region Skills
            //Skills Sample
            List<Skill> skills = new List<Skill>()
            {
                new Skill(){Name="Photoshop",Description="Sed mi sem, sagi eros ac, laoreet commodo diam. Morbi id est in urna facilisis dictum. Mauris rutrum mollis neque a sodales. Mauris sed ipsum nec turpis finibus.",IsActive=true,UserID=1,Percent="60%",Icon="fa fa-eyedropper"},
                new Skill(){Name="Illustrator",Description="Vivamus et rhoncus mauris, suscipit efficitur elementum ex. Interdum et malesuada ipsum primis in faucibus. Nullam odio libero, cursus ac ligula suscipit maximus.",IsActive=true,UserID=1,Percent="%65",Icon="fa fa-eye"},
                new Skill(){Name="Dreamweaver",Description="Praesent ac varius ante, eu suscipit odio. Vesmolito modo pretium scelerisque. Sed vulputate ac varius ante dapibus tempor. Maecenas ut cursus aug suscipit malesuada felis.",IsActive=true,UserID=1,Percent="80%",Icon="fa fa-wrench"},
                new Skill(){Name="Design",Description="Nunc egestas sed efficitur nulla a sodales. Pellentesque tincidunt diam quam, rhoncus congue pellentesque eu, faucibus nec turpis. Quisque laoreet tincidunt turpis dolor tempus.",IsActive=true,UserID=1,Percent="55%",Icon="fa fa-code"},
                new Skill(){Name="Development",Description="Vestibulum dictum tincidunt pulvinar elementum. Etiam urna massa, vestibulum id purus id, vehicula placerat dui. Aenean sit amet pulvinar urna. Ut at mi semper, eleifend.",IsActive=true,UserID=1,Percent="90%",Icon="fa fa-lightbulb-o"},
                new Skill(){Name="Coding",Description="Vestibulum tincidunt sed dapibus elit, sed accumsan libero. Nam vulputate tincidunt quam quis nibh porttitor, a tincidunt lacinia. Nulla turpis arcu, hendrerit volutpat tincidunt at, eget est.",IsActive=true,UserID=1,Percent="85%",Icon="fa fa-rocket"}
            };
            foreach (var item in skills)
            {
                context.Skills.Add(item);
            }
            context.SaveChanges();
            #endregion
#region Resume
            //Resume Sample
            DateTime startdate = new DateTime(2013, 10, 18);
            DateTime enddate = new DateTime(2017, 11, 18);
            DateTime startdate1 = new DateTime(2013, 10, 12);
            DateTime enddate1 = new DateTime(2017, 11, 13);
            DateTime startdate2 = new DateTime(2013, 10, 14);
            DateTime enddate2 = new DateTime(2017, 11, 15);
            List<Resume> resumes = new List<Resume>()
            {
                new Resume(){UserID=1,School="University of Graphics",StartDate=startdate,EndDate=enddate, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris et pulvinar ligula. Praesent maximus ornare quam, id consectetur dui eleifend nec. Nam consectetur orci id nulla varius, quis facilisis dui vulputate. Sed ultrices eu erat non mollis. Phasellus ut libero.",IsActive=true},
                new Resume(){UserID=1,School="University of Graphics1",StartDate=startdate1,EndDate=enddate1, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris et pulvinar ligula. Praesent maximus ornare quam, id consectetur dui eleifend nec. Nam consectetur orci id nulla varius, quis facilisis dui vulputate. Sed ultrices eu erat non mollis. Phasellus ut libero.",IsActive=true},
                new Resume(){UserID=1,School="University of Graphics1",StartDate=startdate2,EndDate=enddate2, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris et pulvinar ligula. Praesent maximus ornare quam, id consectetur dui eleifend nec. Nam consectetur orci id nulla varius, quis facilisis dui vulputate. Sed ultrices eu erat non mollis. Phasellus ut libero.",IsActive=true}
            };

            foreach (var item in resumes)
            {
                context.Resumes.Add(item);
            }
            context.SaveChanges();
            #endregion
#region Experience
            //Experience Sample
            List<Experience> experiences = new List<Experience>()
            {
                 new Experience(){UserID=1,TitleofJob="Senior Web Designer ",Company= "Lorem Ipsum, Inc.",StartDate=startdate,EndDate=enddate,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris et pulvinar ligula. Praesent maximus ornare quam, id consectetur dui eleifend nec. Nam consectetur orci id nulla varius, quis facilisis dui vulputate. Sed ultrices eu erat non mollis. Phasellus ut libero.",IsActive=true},
                new Experience(){UserID=1,TitleofJob="Senior Web Designer ",Company= "Lorem Ipsum, Inc.",StartDate=startdate,EndDate=enddate,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris et pulvinar ligula. Praesent maximus ornare quam, id consectetur dui eleifend nec. Nam consectetur orci id nulla varius, quis facilisis dui vulputate. Sed ultrices eu erat non mollis. Phasellus ut libero.",IsActive=true},
                new Experience(){UserID=1,TitleofJob="Senior Web Designer ",Company= "Lorem Ipsum, Inc.",StartDate=startdate,EndDate=enddate,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris et pulvinar ligula. Praesent maximus ornare quam, id consectetur dui eleifend nec. Nam consectetur orci id nulla varius, quis facilisis dui vulputate. Sed ultrices eu erat non mollis. Phasellus ut libero.",IsActive=true},

            };

            foreach (var item in experiences)
            {
                context.Experiences.Add(item);
            }
            context.SaveChanges();

            #endregion
#region  Profile
            //Profile Sample
            List<Profile> profiles = new List<Profile>()
            {
                new Profile(){UserID=1,Description=@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent volutpat enim arcu, eget tempor nibh congue a. Maecenas faucibus sagittis nibh, in bibendum ex. Donec eu ornare augue, nec cursus arcu. Vivamus accumsan mauris nec nulla bibendum, et eleifend nisl tristique. Pellentesque fringilla lorem id nibh auctor sagittis. Suspendisse non nisl at velit malesuada bibendum.

Quisque in tempor sapien, et cursus neque. Nunc pulvinar diam ac dapibus mollis. Etiam id iaculis lorem. Donec bibendum volutpat ante, eu consequat nisi suscipit at. Etiam interdum augue dolor, id auctor felis volutpat sed. Phasellus id ex ultrices, tempus leo eget, volutpat diam. In sit amet magna faucibus, molestie nisi in, hendrerit libero. Morbi auctor velit sagittis, elementum lorem eget, imperdiet nisl.

Curabitur pharetra tincidunt lobortis. Duis dolor felis, sollicitudin ac dapibus quis, hendrerit ut est. Sed faucibus neque iaculis nisi accumsan, et condimentum nunc scelerisque. Etiam interdum augue dolor, id auctor felis volutpat sed. Phasellus id ex ultrices, tempus leo eget, volutpat diam. In sit amet magna faucibus, molestie nisi in, hendrerit libero. Morbi auctor velit sagittis, elementum lorem eget, imperdiet nisl. Fusce elementum orci in dignissim cursus."}
            };
            foreach (var item in profiles)
            {
                context.Profiles .Add(item);
            }
            context.SaveChanges();

            #endregion
#region  Client
            //Client Sample
            List<Client> clients = new List<Client>()
            {
                new Client(){NameSurname="John Peterson",Comment="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ullamcorper aliquet nulla, eget feugiat mi pellentesque sed. In neque erat, vulputate eu justo et, posuere scelerisque nulla.",IsActive=true},
                new Client(){NameSurname="John Peterson1",Comment="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ullamcorper aliquet nulla, eget feugiat mi pellentesque sed. In neque erat, vulputate eu justo et, posuere scelerisque nulla.",IsActive=true},
                new Client(){NameSurname="John Peterson2",Comment="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ullamcorper aliquet nulla, eget feugiat mi pellentesque sed. In neque erat, vulputate eu justo et, posuere scelerisque nulla.",IsActive=true},
                new Client(){NameSurname="John Peterson3",Comment="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ullamcorper aliquet nulla, eget feugiat mi pellentesque sed. In neque erat, vulputate eu justo et, posuere scelerisque nulla.",IsActive=true},

            };
            foreach (var item in clients)
            {
                context.Clients.Add(item);
            }
            context.SaveChanges();

            #endregion
            #region  JobPositionType
            //JobPositionType Sample
            List<JobPositionType> types = new List<JobPositionType>()
            {
                new JobPositionType(){TypeName="Web Development",IsActive=true},
                new JobPositionType(){TypeName="Web Design",IsActive=true},
                new JobPositionType(){TypeName="Graphic Design",IsActive=true},
            };


            foreach (var item in types)
            {
                context.JobPositionTypes.Add(item);
            }
            context.SaveChanges();

            #endregion
            #region  Portfolio
            //Portfolio Sample
            List<Portfolio> portfolios = new List<Portfolio>()
            {
                new Portfolio(){UserID=1,ProjectName="Projectname",LinkofImage="",Description="Quisque in tempor sapien, et cursus neque. Nunc pulvinar diam ac dapibus mollis. Etiam id iaculis lorem. Donec bibendum volutpat ante, eu consequat nisi suscipit at. Etiam interdum augue dolor, id auctor felis volutpat sed. Phasellus id ex ultrices, tempus leo eget, volutpat diam. In sit amet magna faucibus, molestie nisi in, hendrerit libero. Morbi auctor velit sagittis, elementum lorem eget, imperdiet nisl.",ImagePath="",TypeID=1,IsActive=true },
                new Portfolio(){UserID=1,ProjectName="Projectname",LinkofImage="",Description="Quisque in tempor sapien, et cursus neque. Nunc pulvinar diam ac dapibus mollis. Etiam id iaculis lorem. Donec bibendum volutpat ante, eu consequat nisi suscipit at. Etiam interdum augue dolor, id auctor felis volutpat sed. Phasellus id ex ultrices, tempus leo eget, volutpat diam. In sit amet magna faucibus, molestie nisi in, hendrerit libero. Morbi auctor velit sagittis, elementum lorem eget, imperdiet nisl.",ImagePath="",TypeID=1,IsActive=true },
                new Portfolio(){UserID=1,ProjectName="Projectname",LinkofImage="",Description="Quisque in tempor sapien, et cursus neque. Nunc pulvinar diam ac dapibus mollis. Etiam id iaculis lorem. Donec bibendum volutpat ante, eu consequat nisi suscipit at. Etiam interdum augue dolor, id auctor felis volutpat sed. Phasellus id ex ultrices, tempus leo eget, volutpat diam. In sit amet magna faucibus, molestie nisi in, hendrerit libero. Morbi auctor velit sagittis, elementum lorem eget, imperdiet nisl.",ImagePath="",TypeID=1,IsActive=true },
                new Portfolio(){UserID=1,ProjectName="Projectname",LinkofImage="",Description="Quisque in tempor sapien, et cursus neque. Nunc pulvinar diam ac dapibus mollis. Etiam id iaculis lorem. Donec bibendum volutpat ante, eu consequat nisi suscipit at. Etiam interdum augue dolor, id auctor felis volutpat sed. Phasellus id ex ultrices, tempus leo eget, volutpat diam. In sit amet magna faucibus, molestie nisi in, hendrerit libero. Morbi auctor velit sagittis, elementum lorem eget, imperdiet nisl.",ImagePath="",TypeID=1,IsActive=true },
                new Portfolio(){UserID=1,ProjectName="Projectname",LinkofImage="",Description="Quisque in tempor sapien, et cursus neque. Nunc pulvinar diam ac dapibus mollis. Etiam id iaculis lorem. Donec bibendum volutpat ante, eu consequat nisi suscipit at. Etiam interdum augue dolor, id auctor felis volutpat sed. Phasellus id ex ultrices, tempus leo eget, volutpat diam. In sit amet magna faucibus, molestie nisi in, hendrerit libero. Morbi auctor velit sagittis, elementum lorem eget, imperdiet nisl.",ImagePath="",TypeID=1,IsActive=true }
            };


                foreach (var item in portfolios)
            {
                context.Portfolios.Add(item);
            }
            context.SaveChanges();


            #endregion

 
            base.Seed(context);
        }
    }
}