using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anand_Classes.Models;

namespace Anand_Classes.Controllers
{
    public class HomeController : Controller
    {

        Anand_ClassesEntities db = new Anand_ClassesEntities();

        //
        // GET: /Home/



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Faculty()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            List<Table_Gallery> img = null;
            img = db.Table_Gallery.ToList();

            return View(img);
        }
        public ActionResult Upload_Image()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload_Image(Table_Gallery img)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["Image"];
                img.Image = file.FileName;
                file.SaveAs(Server.MapPath("~/content/Gallery/" + file.FileName));

                img.Upload_Date = DateTime.Now.ToString();
                db.Table_Gallery.Add(img);
                db.SaveChanges();
                Response.Write("<script>alert('Image Uploaded.');window.location.href='/Home/Gallery'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Code is not working.');</script>");

            }
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Table_Contact con)
        {
            try
            {
                con.Contact_Date = DateTime.Now.ToString();

                db.Table_Contact.Add(con);
                db.SaveChanges();
                Response.Write("<script>alert('Form Submitted Successfully');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Code is not working.');</script>");
            }
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(Table_Feedback fee)
        {
            try
            {
                fee.Feedback_Date = DateTime.Now.ToString();
                db.Table_Feedback.Add(fee);
                db.SaveChanges();
                Response.Write("<script>alert('Form Submitted Successfully.')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Code is not working.')</script>");
            }
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Table_Registration reg, string hdn1, string ct1)
        {
            try
            {
                if (hdn1 == ct1)
                {
                    HttpPostedFileBase file = Request.Files["Profile"];
                    reg.Profile = file.FileName;
                    file.SaveAs(Server.MapPath("~/content/Profile_Image/" + file.FileName));

                    reg.Registration_Date = DateTime.Now.ToString();
                    db.Table_Registration.Add(reg);
                    db.SaveChanges();
                    Response.Write("<script>alert('Registration Successful.');window.location.href='/Home/Login'</script>");
                }

                else
                {
                    Response.Write("<script>alert(' Enter captcha carefully ! ')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Code is not working.');</script>");
            }
            return View();
        }










        public ActionResult Login()
        {
            return View();
        }
       

        [HttpPost]
        public ActionResult Login(Table_Registration lg, Table_Teacher_Login log, string loginType, string Email, string Password)
        {
            if (loginType == "student")
            {
                // Handle student login logic
                try
                {
                    Table_Registration t1 = db.Table_Registration.Where(x => x.S_Email == lg.S_Email && x.S_Password == lg.S_Password).SingleOrDefault();
                    if (t1 != null)
                    {
                        Session["aid"] = lg.S_Email;                //  set of session  

                        Response.Write("<script>alert(' Welcome to Your Student Dashboard  '); window.location.href='/Student/Index' </script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Email ID or Password ! ')</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('There are Error in code !   ')</script>");
                }
            }
            else if (loginType == "teacher")
            {
                // Handle teacher login logic
                try
                {
                    Table_Teacher_Login t1 = db.Table_Teacher_Login.Where(x => x.T_Email == log.T_Email && x.T_Password == log.T_Password).SingleOrDefault();
                    if (t1 != null)
                    {
                        Session["aid"] = log.T_Email;                //  set of session  

                        Response.Write("<script>alert(' Welcome to Teacher Dashboard  '); window.location.href='/admin/index' </script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Email ID or Password ! ')</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('There are Error in code !  ! ')</script>");
                }
            }

            // Invalid login, return to the login page with an error message
            TempData["ErrorMessage"] = "Invalid Email ID or Password!";
            return View("Login");
        }















    }

}

