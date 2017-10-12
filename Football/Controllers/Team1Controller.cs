using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Football.Models;

namespace Football.Controllers
{
    public class Team1Controller : Controller
    {


       
        public ActionResult Index()
        {
            SoccerEntities teamcontext = new SoccerEntities();
            List<Team1>teams=teamcontext.Team1.ToList();
            if (User.Identity.IsAuthenticated)
            { string username = User.Identity.Name;
                ViewBag.User = username; }

         
            return View(teams);
        }
        //EDIT
       
        public ActionResult Edit(int teamId)
        {
            SoccerEntities teamcontext = new SoccerEntities();
            Team1 team = teamcontext.Team1.Single(m => m.ID == teamId);

            return View(team);
        }
      
        [HttpPost]
        public ActionResult Edit(Team1 team)
        {
            SoccerEntities db = new SoccerEntities();
            if (ModelState.IsValid)
            {
                db.Entry(team).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }
        //DETAILS
       
        public ActionResult Details(int teamId)
        {
            SoccerEntities footballcontext = new SoccerEntities();
            Team1 team = footballcontext.Team1.Single(py => py.ID == teamId);
            IEnumerable<Player> players = footballcontext.Players.Where(model => model.TeamID == teamId).ToList();
            return View(team);
        }
        public ActionResult Delete(int teamId)
        {
            SoccerEntities teamcontext = new SoccerEntities();
           

            return View();
        }
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_p(int teamId)
        {
            SoccerEntities footballcontext = new SoccerEntities();
            Team1 team = footballcontext.Team1.Single(py => py.ID == teamId);
           IEnumerable<Player> players = footballcontext.Players.Where(pl => pl.TeamID == teamId);
            foreach (var Item in players)
            { footballcontext.Players.Remove(Item); }
            footballcontext.Team1.Remove(team);

            footballcontext.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team1 team)
        {
            SoccerEntities footballcontext = new SoccerEntities();
            if (ModelState.IsValid)
            {
                try
                {
                    footballcontext.Team1.Add(team);
                    footballcontext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
            return View(team);
        }
    }
}