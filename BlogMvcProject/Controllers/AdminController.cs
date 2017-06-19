using BlogMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        BlogContext db = new BlogContext();
        //// GET: Admin
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult AdminProfile()
        {
            return View(db.Profiles.Where(q=>q.ID==1).FirstOrDefault());
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AdminProfile(Profile profile)
        {
            JsonResultModel jModel = new JsonResultModel();
            try
            {

                if (ModelState.IsValid)
                {
                    Profile oProfile = db.Profiles.Where(q => q.ID == 1).FirstOrDefault();
                    oProfile.Description = profile.Description;
                    oProfile.UserID = 1;
                    db.SaveChanges();


                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }
            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }


            return Json(jModel, JsonRequestBehavior.AllowGet);


        }

        public PartialViewResult _AdminSkill()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult _AdminSkill(Skill skill)
        {
            JsonResultModel jModel = new JsonResultModel();
            try
            {

                if (ModelState.IsValid)
                {
                    Skill oSkill = new Skill();
                    oSkill.Name = skill.Name;
                    oSkill.Description = skill.Description;
                    oSkill.Icon = skill.Icon;
                    oSkill.IsActive = true;
                    oSkill.UserID = 1;
                    oSkill.Percent = skill.Percent;
                    db.Skills.Add(oSkill);
                    db.SaveChanges();

                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your skill was added.";
                }
            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't added.";
            }
            return Json(jModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AdminResume()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AdminResume(Resume resume)
        {
            JsonResultModel jModel = new JsonResultModel();
            try
            {
                resume.UserID = 1;
                resume.IsActive = true;
               
                Resume oResume = new Resume();
                
                if (ModelState.IsValid)
                {
                   
                    oResume.School = resume.School;                 
                    oResume.StartDate = resume.StartDate;                 
                    oResume.EndDate = resume.EndDate;
                    oResume.Description = resume.Description;
                    oResume.IsActive = resume.IsActive;
                    oResume.UserID = resume.UserID;
                    db.Resumes.Add(resume);
                    db.SaveChanges();


                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }
            }
            catch (Exception ex)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
                throw ex;
           
            }


            return Json(jModel, JsonRequestBehavior.AllowGet);


        }



        public PartialViewResult _AdminExperience()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult _AdminExperience(Experience experience)
        {
            JsonResultModel jModel = new JsonResultModel();
            try
            {
                experience.UserID = 1;
                experience.IsActive = true;

                Experience oExperince = new Experience();

                if (ModelState.IsValid)
                {
                  
                    oExperince.IsActive = experience.IsActive;
                    oExperince.Company = experience.Company;
                    oExperince.TitleofJob = experience.TitleofJob;
                    oExperince.UserID = experience.UserID;
                    oExperince.StartDate = experience.StartDate;
                    oExperince.EndDate = experience.EndDate;
                    oExperince.Description = experience.Description;
                    db.Experiences.Add(oExperince);
                    db.SaveChanges();


                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }
            }
            catch (Exception ex)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
                throw ex;
            }


            return Json(jModel, JsonRequestBehavior.AllowGet);


        }


        public ActionResult AdminPortfolio()
        {

            var data = from p in db.JobPositionTypes
                       select new
                       {
                           TypeID = p.ID,
                           TypeName = p.TypeName
                       };


            SelectList list = new SelectList(data, "TypeID", "TypeName");
            ViewBag.Types = list;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AdminPortfolio(Portfolio portfolio)
        {


        
            JsonResultModel jModel = new JsonResultModel();
            try
            {

                if (ModelState.IsValid)
                {
                    Portfolio oPortfolio = new Portfolio();
                    oPortfolio.IsActive = true;
                    oPortfolio.ProjectName = portfolio.ProjectName;
                    oPortfolio.TypeID = portfolio.TypeID;
                    oPortfolio.ImagePath = portfolio.ImagePath;
                    oPortfolio.LinkofImage = portfolio.LinkofImage;
                    oPortfolio.UserID = 1;
                    oPortfolio.Description = portfolio.Description;

                
                    db.Portfolios.Add(oPortfolio);
                    db.SaveChanges();


                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }
            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }


            return Json(jModel, JsonRequestBehavior.AllowGet);


        }

        public PartialViewResult _AdminFeedBack()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult _AdminFeedBack(Client client)
        {



            JsonResultModel jModel = new JsonResultModel();
            try
            {

                if (ModelState.IsValid)
                {
                    Client oClient= new Client();
                    oClient.IsActive = true;
                    oClient.NameSurname = client.NameSurname;
                    oClient.Comment = client.Comment;
  
                    db.Clients.Add(oClient);
                    db.SaveChanges();


                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }
            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }


            return Json(jModel, JsonRequestBehavior.AllowGet);


        }


        public ActionResult EducationList()
        {
            return View(db.Resumes.ToList());
        }

        public ActionResult EducationListEdit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume oResume = db.Resumes.Find(id);
            if (oResume == null)
            {
                return HttpNotFound();
            }
            return View(oResume);
    
        }

        [HttpPost]
        public JsonResult EducationListEdit(Resume oresume)
        {

            JsonResultModel jModel = new JsonResultModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Resumes.Find(oresume.ID);
                    entity.School = oresume.School;
                    entity.StartDate = oresume.StartDate;
                    entity.EndDate = oresume.EndDate;
                    entity.Description = oresume.Description;
                    entity.IsActive = oresume.IsActive;

                    db.SaveChanges();

              
                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }

            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }

            return Json(jModel, JsonRequestBehavior.AllowGet);


        }


        public ActionResult EducationListDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume oResume = db.Resumes.Find(id);
            if (oResume == null)
            {
                return HttpNotFound();
            }
            return View(oResume);

        }
        // POST: EducationList/Delete/5
        [HttpPost, ActionName("EducationListDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Resume oresume = db.Resumes.Find(id);
            db.Resumes.Remove(oresume);
            db.SaveChanges();
            return RedirectToAction("EducationList");
        }




        public ActionResult ExperienceList()
        {
            return View(db.Experiences.ToList());
        }

        public ActionResult ExperienceListEdit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience oExperince = db.Experiences.Find(id);
            if (oExperince == null)
            {
                return HttpNotFound();
            }
            return View(oExperince);

        }

        [HttpPost]
        public JsonResult ExperienceListEdit(Experience oExperience)
        {

            JsonResultModel jModel = new JsonResultModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Experiences.Find(oExperience.ID);
                    entity.TitleofJob = oExperience.TitleofJob;
                    entity.Company = oExperience.Company;
                    entity.StartDate = oExperience.StartDate;
                    entity.EndDate = oExperience.EndDate;
                    entity.Description = oExperience.Description;
                    entity.IsActive = oExperience.IsActive;

                    db.SaveChanges();


                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }

            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }

            return Json(jModel, JsonRequestBehavior.AllowGet);


        }


        public ActionResult ExperienceListDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience oExperience = db.Experiences.Find(id);
            if (oExperience == null)
            {
                return HttpNotFound();
            }
            return View(oExperience);

        }
        // POST: EducationList/Delete/5
        [HttpPost, ActionName("ExperienceListDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteExperienceConfirmed(int? id)
        {
            Experience oExperience = db.Experiences.Find(id);
            db.Experiences.Remove(oExperience);
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }



        public ActionResult SkillList()
        {
            return View(db.Skills.ToList());
        }

        public ActionResult SkillListEdit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill oSkill = db.Skills.Find(id);
            if (oSkill == null)
            {
                return HttpNotFound();
            }
            return View(oSkill);

        }

        [HttpPost]
        public JsonResult SkillListEdit(Skill oSkill)
        {

            JsonResultModel jModel = new JsonResultModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Skills.Find(oSkill.ID);
                    entity.Name = oSkill.Name;
                    entity.Icon = oSkill.Icon;
                    entity.Percent = oSkill.Percent;
                    entity.Description = oSkill.Description;
                    entity.IsActive = oSkill.IsActive;
                    db.SaveChanges();


                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }

            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }

            return Json(jModel, JsonRequestBehavior.AllowGet);


        }


        public ActionResult SkillListDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill oSkill = db.Skills.Find(id);
            if (oSkill == null)
            {
                return HttpNotFound();
            }
            return View(oSkill);

        }
        // POST: EducationList/Delete/5
        [HttpPost, ActionName("SkillListDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkillConfirmed(int? id)
        {
            Skill oSkill = db.Skills.Find(id);
            db.Skills.Remove(oSkill);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }




        public ActionResult PortfolioList()
        {

            var portfolios = db.Portfolios.Include(c => c.type);
            return View(portfolios.ToList());
        }
    
        public ActionResult PortfolioListEdit(int? id)
        {

            var data = from p in db.JobPositionTypes
                       select new
                       {
                           TypeID = p.ID,
                           TypeName = p.TypeName
                       };

            SelectList list = new SelectList(data, "TypeID", "TypeName");
            ViewBag.Types = list;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio oPortfolio = db.Portfolios.Find(id);
            if (oPortfolio == null)
            {
                return HttpNotFound();
            }
            return View(oPortfolio);

        }

        [HttpPost]
        public JsonResult PortfolioListEdit(Portfolio oPortfolio)
        {

            JsonResultModel jModel = new JsonResultModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Portfolios.Find(oPortfolio.ID);
                    entity.ImagePath = oPortfolio.ImagePath;
                    entity.ProjectName = oPortfolio.ProjectName;
                    entity.LinkofImage = oPortfolio.LinkofImage;
                    entity.Description = oPortfolio.Description;
                    entity.TypeID = oPortfolio.TypeID;
                    entity.IsActive = oPortfolio.IsActive;

                    db.SaveChanges();

                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }

            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }

            return Json(jModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PortfolioListDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio oPortfolio = db.Portfolios.Find(id);
            if (oPortfolio == null)
            {
                return HttpNotFound();
            }
            return View(oPortfolio);

        }
        // POST: EducationList/Delete/5
        [HttpPost, ActionName("PortfolioListDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePortfolioConfirmed(int? id)
        {
            Portfolio oPortfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(oPortfolio);
            db.SaveChanges();
            return RedirectToAction("PortfolioList");
        }


        public ActionResult ClientCommentList()
        {

       
            return View(db.Clients.ToList());
        }

        public ActionResult ClientCommentListEdit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client oClient = db.Clients.Find(id);
            if (oClient == null)
            {
                return HttpNotFound();
            }
            return View(oClient);

        }

        [HttpPost]
        public JsonResult ClientCommentListEdit(Client oClient)
        {

            JsonResultModel jModel = new JsonResultModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = db.Clients.Find(oClient.ID);
                    entity.NameSurname = oClient.NameSurname;
                    entity.Comment = oClient.Comment;
                    entity.IsActive = oClient.IsActive;

                    db.SaveChanges();

                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }

            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }

            return Json(jModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClientCommentListDelete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client oClient = db.Clients.Find(id);
            if (oClient == null)
            {
                return HttpNotFound();
            }
            return View(oClient);

        }
        // POST: EducationList/Delete/5
        [HttpPost, ActionName("ClientCommentListDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClientCommentConfirmed(int? id)
        {
            Client oClient = db.Clients.Find(id);
            db.Clients.Remove(oClient);
            db.SaveChanges();
            return RedirectToAction("ClientCommentList");
        }




        public ActionResult AdminUser()
        {
            return View(db.Users.Where(q => q.ID == 1).FirstOrDefault());
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AdminUser(User user)
        {
            JsonResultModel jModel = new JsonResultModel();
            try
            {

                if (ModelState.IsValid)
                {
                    User oUser = db.Users.Where(q => q.ID == 1).FirstOrDefault();
                    oUser.Name = user.Name;
                    oUser.Surname = user.Surname;
                    oUser.Password = "";
                    oUser.ImagePath = user.ImagePath;
                    oUser.JobTitle = user.JobTitle;
                    oUser.FaceAccount = user.FaceAccount;
                    oUser.TwitterAccount = user.TwitterAccount;
                    oUser.LinkedinAccount = user.LinkedinAccount;
                    oUser.InstagramAccount = user.InstagramAccount;
                    oUser.GoogleAccount = user.GoogleAccount;
                    oUser.Email = user.Email;
                    oUser.Phone = user.Phone;
                    oUser.ResumePath = user.ResumePath;
                    oUser.Location = user.Location;
                    oUser.Status = true;
                    db.SaveChanges();


                    jModel.IsSuccess = true;
                    jModel.UserMessage = "Success! Your message was sent.";
                }
            }
            catch (Exception)
            {
                jModel.IsSuccess = false;
                jModel.UserMessage = "Failure! Your message wasn't sent.";
            }


            return Json(jModel, JsonRequestBehavior.AllowGet);


        }

    }
}