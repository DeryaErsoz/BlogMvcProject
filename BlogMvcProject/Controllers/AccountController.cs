        using BlogMvcProject.Identity;
        using BlogMvcProject.Models;
        using Microsoft.AspNet.Identity;
        using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
        using System.Collections.Generic;
        using System.Linq;
using System.Security.Claims;
using System.Web;
        using System.Web.Mvc;

namespace BlogMvcProject.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> userManager;

        private RoleManager<ApplicationRole> roleManager;


        public AccountController()

        {

            BlogContext db = new BlogContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);


            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);

            roleManager = new RoleManager<ApplicationRole>(roleStore);

        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()

        {

            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Register(Register model)
        {

            if (ModelState.IsValid)

            {

                ApplicationUser user = new ApplicationUser();

                user.Name = model.Name;

                user.Surname = model.Surname;

                user.Email = model.Email;

                user.UserName = model.Username;



                IdentityResult iResult = userManager.Create(user, model.Password);

                if (iResult.Succeeded)
                {

                    // User isminde bir Role ataması yapacağız. Bu rolü ilerleyen kısımda oluşturacağız
                    userManager.AddToRole(user.Id, "Admin");
                    return RedirectToAction("Login", "Account");
                }

                else

                {
                    ModelState.AddModelError("RegisterUser", "Kullanıcı ekleme işleminde hata!");
               }
            }

            return View(model);

        }

                    public ActionResult Login()

            {

            return View();

            }

 

            [HttpPost]

            [ValidateAntiForgeryToken]

            public ActionResult Login(Login model)

            {

            if (ModelState.IsValid)

            {
                ApplicationUser user;
                try {  user = userManager.Find(model.Username, model.Password); }
                catch(Exception e)
                {
                    throw e;
                }

          


            if (user != null)

            {

            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;

            ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");

            AuthenticationProperties authProps = new AuthenticationProperties();

            authProps.IsPersistent = model.RememberMe;

            authManager.SignIn(authProps, identity);


            return RedirectToAction("AdminProfile", "Admin");

            }

            else

            {

            ModelState.AddModelError("LoginUser", "Böyle bir kullanıcı bulunamadı");
                    
            }

            }

            return View(model);

            }
            [Authorize]
            public ActionResult Logout()
            {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");

        }
}
}
        