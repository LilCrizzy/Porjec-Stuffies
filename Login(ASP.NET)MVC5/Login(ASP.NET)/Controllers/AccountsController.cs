using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_ASP.NET_.Models;
using System.Data.SqlClient;

namespace Login_ASP.NET_.Controllers
{
 
    public class AccountsController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Accounts
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-APN7BF4; database=logindb; integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(Accounts acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from LoginTable where username ='"+acc.Name+" and password='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            
            
        }
    }
}