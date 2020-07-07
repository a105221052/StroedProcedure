using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using searchArea.Models;

namespace searchArea.Controllers
{
    //連線字串
    public class Global
    {
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
    }

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int Area_Amount(string area)
        {         
            Model model = new Model(Global.conn);
            int result = model.Area_Amount(area);          
            return result;
        }
    }
}