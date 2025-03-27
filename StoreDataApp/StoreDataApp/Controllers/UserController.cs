using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreDataApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace StoreDataApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user, HttpPostedFileBase file)
        {
            string mainCon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection mycon = new SqlConnection(mainCon);
            string sqlquery = "INSERT INTO [dbo].[UserData]([userName],[phoneNo],[address],[email],[password],[re-password],[gender],[dp])VALUES(@userName,@phoneNo,@address,@email,@password,@rePassword,@gender,@dp)";
            SqlCommand cmd = new SqlCommand(sqlquery, mycon);
            mycon.Open();
            //@userName,@phoneNo,@address,@email,@password,@re-password,@gender,@dp
            cmd.Parameters.AddWithValue("@userName", user.userName);
            cmd.Parameters.AddWithValue("@phoneNo", user.phoneNo);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@rePassword", user.rePassword);
            cmd.Parameters.AddWithValue("@gender", user.gender);
            string filePath=Path.GetFullPath(file.FileName);
            cmd.Parameters.AddWithValue("@dp", filePath);
            cmd.ExecuteNonQuery();
            mycon.Close();
            ViewData["Message"] = "User Data " + user.userName + " Saved Sucessufully !";
            return View();
        }
    }
}