using SampleProject.DAL;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    
    public class LoginController : Controller
    {
        LoginModel objLogin = new LoginModel();
        // GET: Login
        [HttpGet]
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Login(LoginModel logObj)
        {
            var user = logObj.userName;
            var password = logObj.password;
            DataTable res = new DataTable(); ;
            LoginDAL logDAL = new LoginDAL();
            res = logDAL.Check(user, password);
            string userName=string.Empty;
            string pass= string.Empty;
            string LoginID=null;
            string permission = null;
            foreach (DataRow dR in res.Rows)
            {

                        userName = Convert.ToString(dR["userName"]);
                        pass = Convert.ToString(dR["password"]);
                        LoginID= Convert.ToString(dR["LOGINID"]);
                        permission= Convert.ToString(dR["Permissionid"]);
                        
            }
            if(userName== user&& pass== password)
            {
                Session["userName"] = user;
                Session["LOGINID"] = LoginID;
                Session["userType"] = permission;
                return RedirectToAction("Index", "Dashboard");
            }
            else {
                    Session["userName"] = null;
                    Session["LOGINID"] = null;
                return RedirectToAction("Login","Login");
                }
                //if (res[0]=="1")
                //{
                //    Session["Username"] = user;
                //    ViewBag.UserName = user;
                //    return RedirectToAction("Index","Dashboard");
                //}
                //else {
                //    Session["Username"] = null;
                //    return RedirectToAction("Login","Login");
                //}

            }

            public ActionResult LogOut()
        {
            //Session.Remove("Username");
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
        
        public ActionResult RegisterUser()   
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult RegisterUser(LoginModel RegLog)
        {
            string[] res = new string[10];
            // res = objLogin.Register(RegLog);
            LoginDAL logDAL = new LoginDAL();
            res = logDAL.Register(RegLog);
            ViewBag.Message = res[1];
            if (res[1] == "Exists")
            {
                return RedirectToAction("RegisterUser", "Login");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            
        }

        //public ActionResult CheckUSer(string user,string password)   //if you use ajax
        //{
        //    string[] res = new string[10];
        //    res = objLogin.Check(user, password);

        //    return Json(res,JsonRequestBehavior.AllowGet);
        //}
    }
}