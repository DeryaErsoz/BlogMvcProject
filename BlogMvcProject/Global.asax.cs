using BlogMvcProject.Identity;
using BlogMvcProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BlogMvcProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

 

BlogContext db = new BlogContext();
          
            RoleStore < ApplicationRole > roleStore = new RoleStore<ApplicationRole>(db);
         
            RoleManager < ApplicationRole > roleManager = new RoleManager<ApplicationRole>(roleStore);
           


if (!roleManager.RoleExists("Admin"))
                
{
                
ApplicationRole adminRole = new ApplicationRole("Admin", "Sistem yöneticisi");
               
                roleManager.Create(adminRole);
                
}
            


if (!roleManager.RoleExists("User"))
                
{
                
ApplicationRole userRole = new ApplicationRole("User", "Sistem kullanıcısı, yorum eklemek için gereklidir");
              
                roleManager.Create(userRole);
                
}
            
// Rol tanımlama adımları
        }
    }
}
