using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Anand_Classes.Models;

namespace Anand_Classes.Controllers
{
    public class AdminController : Controller
    {

        Anand_ClassesEntities db = new Anand_ClassesEntities();

        //
        // GET: /Admin/


        public ActionResult Index()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Log In first.'); window.location.href='/Home/login' </script>");
            }
            return View();
        }
        public ActionResult RegistrationMGMT()
        {
            {

                if (Session["aid"] != null)
                {

                }
                else
                {
                    Response.Write("<script>alert('Log In first.'); window.location.href='/Home/login' </script>");
                }

                List<Table_Registration> rege = null;
                rege = db.Table_Registration.ToList();

                return View(rege);
            }
        }
        public ActionResult GalleryMGMT()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Log In first.'); window.location.href='/Home/login' </script>");
            }
            List<Table_Gallery> img = null;
            img = db.Table_Gallery.ToList();
            return View(img);
        }
        public ActionResult ContactMGMT()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Log In first.'); window.location.href='/Home/login' </script>");
            }
            List<Table_Contact> lst = null;
            lst = db.Table_Contact.ToList();

            return View(lst);
        }
        public ActionResult FeedbackMGMT()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Log In first.'); window.location.href='/Home/login' </script>");
            }
            List<Table_Feedback> lst = null;
            lst = db.Table_Feedback.ToList();

            return View(lst);
        }
        public ActionResult Change_Password()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Log In first.'); window.location.href='/Home/login' </script>");
            }
            return View();
        }
        [HttpPost]

        public ActionResult Change_Password(string Old_Password, string New_Password, string Confirm_Password)
        {

            if (New_Password == Confirm_Password && New_Password != Old_Password)
            {
                string Email = Session["aid"].ToString();

                Table_Teacher_Login lg = db.Table_Teacher_Login.Where(d => d.T_Password == Old_Password && d.T_Email == d.T_Email).SingleOrDefault();
                lg.T_Password = New_Password;
                db.SaveChanges();
                Response.Write("<script>alert('Your password changed '); window.location.href='/Home/Login' </script>");
            }

            else
            {
                Response.Write("<script>alert('Please enter valid password '); </script>");
            }
            return View();
        }


        public void Delete()
        {
            try
            {
                string m = Request.QueryString["m"];
                Table_Registration tbl = db.Table_Registration.SingleOrDefault(x => x.S_Email == m);
                db.Table_Registration.Remove(tbl);
                db.SaveChanges();
                Response.Write("<script>alert(' Record Successfully deleted '); window.location.href='/admin/RegistrationMGMT' </script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong ! '); window.location.href='/admin/RegistrationMGMT' </script>");

            }

        }

        public void Image_Delete()
        {
            try
            {
                int m = int.Parse(Request.QueryString["m"]);
                Table_Gallery tbl = db.Table_Gallery.SingleOrDefault(x => x.Id == m);
                db.Table_Gallery.Remove(tbl);
                db.SaveChanges();
                Response.Write("<script>alert(' Image deleted '); window.location.href='/admin/GalleryMGMT' </script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong ! '); window.location.href='/admin/RegistrationMGMT' </script>");

            }

        }

        [HttpGet]
        public ActionResult Update_Student_Data()
        {
            string aid = Request.QueryString["U"];
            Table_Registration reg = db.Table_Registration.SingleOrDefault(a => a.S_Email == aid);
            return View(reg);
        }

        [HttpPost]
        public void Update_Student_Data(Table_Registration reg, string S_Email)
        {
            Table_Registration rg = db.Table_Registration.SingleOrDefault(a => a.S_Email == S_Email);
            try
            {
                HttpPostedFileBase file = Request.Files["Profile"];
                if (file.FileName != "")
                {
                    rg.Name = reg.Name;
                    rg.Father_Name = reg.Father_Name;
                    rg.Mobile = reg.Mobile;
                    rg.Profile = file.FileName;
                    rg.DOB = reg.DOB;
                    rg.S_Password = reg.S_Password;
                    rg.Address = reg.Address;
                    rg.Education = reg.Education;
                    rg.Registration_Date = DateTime.Now.ToString();

                    db.SaveChanges();
                    file.SaveAs(Server.MapPath("~/content/Profile_Image/" + file.FileName));
                    Response.Write("<script>alert('Record Updated Successfully ! ');  window.location.href='/admin/RegistrationMGMT' </script>");

                }
                else
                {
                    Table_Registration dd = db.Table_Registration.SingleOrDefault(x => x.S_Email == S_Email);

                    dd.Name = reg.Name;
                    dd.Father_Name = reg.Father_Name;
                    dd.Mobile = reg.Mobile;
                    //    rg.Profile_Picture = file.FileName;
                    dd.DOB = reg.DOB;
                    dd.S_Password = reg.S_Password;
                    dd.Address = reg.Address;
                    dd.Education = reg.Education;
                    dd.Registration_Date = DateTime.Now.ToString();

                    db.SaveChanges();
                    //    file.SaveAs(Server.MapPath("~/content/Profile_Pictures/" + file.FileName));
                    Response.Write("<script>alert('Record Updated Successfully ! ');  window.location.href='/Admin/RegistrationMGMT' </script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record Not Updated ! ');  </script>");

            }
        }



        public void Logout()
        {

            Session.Abandon();
            Response.Write("<script>alert('Loged Out'); window.location.href='/home/Index' </script>");
        }


        // for student study marterial 

        public ActionResult MaterialMGMT()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Log In first.'); window.location.href='/Home/login' </script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult MaterialMGMT(Table_Material mt)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["Image"];
                mt.Image = file.FileName;
                file.SaveAs(Server.MapPath("~/content/Material/" + file.FileName));

                mt.Upload_Date = DateTime.Now.ToString();
                db.Table_Material.Add(mt);
                db.SaveChanges();
                Response.Write("<script>alert('Uploaded Successful.');window.location.href='/Admin/Index'</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong !'); window.location.href='/Admin/MaterialMGMT' </script>");
            }
            return View();
        }


    }
}
