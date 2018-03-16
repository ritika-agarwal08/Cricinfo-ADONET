using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class CricinfoController : Controller
    {
        // GET: Cricinfo
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Upcoming()
        {
            return View();
        }
        public ActionResult Past()
        {
            return View();
        }
        public ActionResult Ranking()
        {
            return View();
        }
        public ActionResult Search(Search person,string button)
        {
            string PlayerName = person.PlayerName;
            if (button == "Search")
            {
                ViewBag.Button = "Search";
                if(PlayerName==null)
                {
                    ViewBag.Message = "Enter Player Name";
                }
                else
                { 
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source=localhost;initial catalog=SearchPlayer;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                    con.Open();
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand("select * from Search where Player=@player", con);
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@player";
                        param.Value = PlayerName;
                        cmd.Parameters.Add(param);
                        SqlDataReader rd = cmd.ExecuteReader();

                        while (rd.Read())

                        {
                            person.Country = Convert.ToString(rd.GetSqlValue(1));

                            person.Link = Convert.ToString(rd.GetSqlValue(2));
                            ViewBag.Message = string.Format("Player: {0}\\nTeam: {1}\\nLink: {2}", PlayerName, person.Country, person.Link);
                        }
                    }
                    
                }
            }
            else
            {
                if(button == "Insert")
                {
                    ViewBag.PlayerName = PlayerName;
                    ViewBag.Button = "Insert";
                    if (PlayerName == null)
                    {
                        ViewBag.Message = "Enter Player Name";
                    }
                    else
                    {
                        string Country = person.Country;
                        string Link = person.Link;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = "data source=localhost;initial catalog=SearchPlayer;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                        con.Open();
                        using (con)
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO Search VALUES(@player, @country ,@Link)", con);
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@player";
                            param.Value = PlayerName;
                            cmd.Parameters.Add(param);
                            SqlParameter param1 = new SqlParameter();
                            param1.ParameterName = "@country";
                            param1.Value = Country;
                            cmd.Parameters.Add(param1);
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@Link";
                            param2.Value = Link;
                            cmd.Parameters.Add(param2);
                            SqlDataReader rd = cmd.ExecuteReader();
                            while (rd.Read())

                            {
                                person.Country = Convert.ToString(rd.GetSqlValue(1));

                                person.Link = Convert.ToString(rd.GetSqlValue(2));
                            }

                            ViewBag.Message = "Entry Inserted";
                        }

                    }
                }
                if(button == "Delete")
                {
                    ViewBag.PlayerName = PlayerName;
                    ViewBag.Button = "Delete";
                    if (PlayerName == null)
                    {
                        ViewBag.Message = "Enter Player Name";
                    }
                    else
                    {
                        string Country = person.Country;
                        string Link = person.Link;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = "data source=localhost;initial catalog=SearchPlayer;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                        con.Open();
                        using (con)
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM Search where Player=@player", con);
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@player";
                            param.Value = PlayerName;
                            cmd.Parameters.Add(param);
                            SqlDataReader rd = cmd.ExecuteReader();
                            ViewBag.Message = "Entry Deleted";
                        }

                    }
                }
            }
            return View();
        }

    }
}