using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        
        DashboardModel dash = new DashboardModel();
        public ActionResult Index()
        {
            return View();
        }
    }
}