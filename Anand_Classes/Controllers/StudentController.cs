using Anand_Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anand_Classes.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        Anand_ClassesEntities db = new Anand_ClassesEntities();

        public ActionResult Index()
        {
            if (Session["aid"] != null)
            {
                // Retrieve the email of the currently logged-in user
                string userEmail = Session["aid"].ToString();

                // Retrieve the user's data from the database based on the email
                Table_Registration user = db.Table_Registration.SingleOrDefault(u => u.S_Email == userEmail);

                if (user != null)
                {
                    // Pass the user object to the view
                    return View(user);
                }
                else
                {
                    // Handle the case where the user's data is not found
                    return HttpNotFound();
                }
            }
            else
            {
                Response.Write("<script>alert('Log In first. Then go to User Dashboard . '); window.location.href='/home/Public_login' </script>");
            }
            List<Table_Registration> lst = null;
            lst = db.Table_Registration.ToList();

            return View(lst);

        }

      public ActionResult Material()
        {
            
                if (Session["aid"] != null)
                {

                }
                else
                {
                    Response.Write("<script>alert('Log In first.'); window.location.href='/Home/login' </script>");
                }
                List<Table_Material> lst = null;
                lst = db.Table_Material.ToList();

                return View(lst);
        }

      public ActionResult Student_Profile()
      {


          if (Session["aid"] != null)
          {
              // Retrieve the email of the currently logged-in user
              string userEmail = Session["aid"].ToString();

              // Retrieve the user's data from the database based on the email
              Table_Registration user = db.Table_Registration.SingleOrDefault(u => u.S_Email == userEmail);

              if (user != null)
              {
                  // Pass the user object to the view
                  return View(user);
              }
              else
              {
                  // Handle the case where the user's data is not found
                  return HttpNotFound();
              }
          }
          else
          {
              Response.Write("<script>alert('Log In first. Then go to User Dashboard . '); window.location.href='/home/Public_login' </script>");
          }
          List<Table_Registration> lst = null;
          lst = db.Table_Registration.ToList();

          return View(lst);


      }
      public ActionResult Student_Edit()
      {
         
          return View();

      }
       







    }
}
