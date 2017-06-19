using BlogMvcProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcProject.Controllers
{
    public class HomeController : Controller
    {
        BlogContext context = new BlogContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(context.Users.ToList());
        }

        public PartialViewResult _Profile()
        {
           return PartialView(context.Profiles.ToList());
        }

        public PartialViewResult _Skills()
        {
            return PartialView(context.Skills.Where(q=>q.IsActive==true).ToList());
        }

        public PartialViewResult _Resume()
        {
            return PartialView(context.Resumes.Where(q => q.IsActive == true).ToList());
        }

        public PartialViewResult _Portfolio()
        {

            var jobtype = context.JobPositionTypes.FirstOrDefault();

            //var portfolio = context.Portfolios
            //              .Select(i =>
            //                  new PortfolioJobTypeModel()
            //                  {
            //                      ID = i.ID,
            //                      PortfolioDescription = i.Description,
            //                      PortfolioImagePath = i.ImagePath,
            //                      PortfolioIsActive = i.IsActive,
            //                      PortfolioTypeID = i.TypeID,
            //                      PortfolioLinkofImage = i.LinkofImage,
            //                      JobName = jobtype.Name,
            //                      JobIsActive=jobtype.IsActive

            //                  }
            //              );
            //return PartialView(portfolio.ToList());
            return PartialView(context.Portfolios.Where(q=>q.IsActive==true).ToList());
        }

        [HttpGet]
        public ActionResult _Contact()
        {
            return PartialView();
        }


        [HttpPost]
        public JsonResult _Contact(FeedBack feedback)
        {
            
            JsonResultModel jModel = new JsonResultModel();
            try
            {
                if (ModelState.IsValid)
                {
                    FeedBack oFeedback = new FeedBack();
                    oFeedback.NameSurname = feedback.NameSurname;
                    oFeedback.Email = feedback.Email;
                    oFeedback.Comment = feedback.Comment;
                    context.FeedBacks.Add(oFeedback);
                    context.SaveChanges();
                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }
             
            }
            catch(Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }

            return Json(jModel, JsonRequestBehavior.AllowGet);


        }

        public PartialViewResult _Experience()
        {
            return PartialView(context.Experiences.Where(q => q.IsActive == true).ToList());
        }

        public PartialViewResult _SkillPercent()
        {
            return PartialView(context.Skills.Where(q => q.IsActive == true).ToList());
        }


        public PartialViewResult _ProjectTypes()
        {
            return PartialView(context.JobPositionTypes.ToList());
        }



        public PartialViewResult _ContactInfo()
        {
            return PartialView(context.Users.ToList());
        }


        public PartialViewResult _Client()
        {
            return PartialView(context.Clients.Where(q => q.IsActive == true).ToList());
        }

        public ActionResult Download()
        {
            string[] files = Directory.GetFiles(Server.MapPath("/Files"));
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }
            ViewBag.Files = files;
            return View();
        }

        public FileResult DownloadFile()
        {

            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(Url.Content("~/Content/example.pdf")));
            string fileName = "example.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}