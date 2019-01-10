using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MembershipTypeController : Controller
    {
        // GET: MembershipType
        public ActionResult Index()
        {
            return View();
        }
    }
}