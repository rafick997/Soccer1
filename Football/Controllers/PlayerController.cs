using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using Football.Models;

    namespace Football.Controllers
    {
        public class PlayerController : Controller
        {
        public ActionResult playerOfTeam(int teamId)
        {
            SoccerEntities footballcontext = new SoccerEntities();
            List<Player> players = footballcontext.Players.Where(m=>m.TeamID==teamId).ToList();
            ViewBag.teamId = teamId;
            return View(players);
        }


        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
            {
            ViewBag.SortNameParameter=string.IsNullOrEmpty(sortBy)?"Name desc":"";
            ViewBag.SortAgeParameter = sortBy == "Age" ? "Age desc" : "Age";
            

            SoccerEntities footballcontext = new SoccerEntities();
            var players = footballcontext.Players.AsQueryable();

            if (searchBy == "Team")
            {

                players=players.Where(x => x.Name.StartsWith(search) || search == null);
            }
            else
            {


                players = players.Where(x => x.Name.StartsWith(search) || search == null);
            }

            switch(sortBy)
            {
                case "Age":
                    players = players.OrderBy(x => x.Age);
                    break;
                case "Name desc":
                    players = players.OrderByDescending(x => x.Name);
                    break;
                case "Age desc":
                    players = players.OrderByDescending(x => x.Age);
                    break;
                default:
                    players = players.OrderBy(x => x.Name);
                    break;

            }
            return View(players.ToPagedList(page ?? 1, 5));
        }
     
        [HttpGet, ActionName("Delete")]
        public ActionResult Delete_g(int playerId, int teamId)
        {
            Player p1 = new Player();
            p1.ID = playerId;

            return View(p1);
        }
      
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_p(int playerId, int teamId)
        {
            SoccerEntities footballcontext = new SoccerEntities();
            Player player = footballcontext.Players.Single(pl => pl.ID == playerId);



                    footballcontext.Players.Remove(player);
                    footballcontext.SaveChanges();
                    return RedirectToAction("Index", new { teamId = player.TeamID });
            
        }

     
        public ActionResult Create()
        {
            SoccerEntities db = new SoccerEntities();
            ViewBag.Teams = new SelectList(db.Team1, "ID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Player player)
        {
            SoccerEntities footballcontext = new SoccerEntities();
            if (ModelState.IsValid)
            {try
                {
                    player.Photo = "~/Photo.anonim.png";
                    footballcontext.Players.Add(player);
                    footballcontext.SaveChanges();
                    return RedirectToAction("Index",new { teamId=player.TeamID});
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
            return View(player);
        }
        public ActionResult CreateForTeam(int teamId)
        {
            Player p1 = new Player();
            p1.TeamID = teamId;
            return View(p1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForTeam(Player player)
        {
            SoccerEntities footballcontext = new SoccerEntities();
            if (ModelState.IsValid)
            {
                try
                {
                    player.Photo = "~/Photo.anonim.png";
                    footballcontext.Players.Add(player);
                    footballcontext.SaveChanges();
                    return RedirectToAction("Index", new { teamId = player.TeamID });
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
            return View(player);
        }


        public ActionResult Details(int playerId)
        {
            SoccerEntities footballcontext = new SoccerEntities();
           Player player = footballcontext.Players.Single(py => py.ID == playerId);
   
           

            return View(player);
        }
        public ActionResult All()
        {

            SoccerEntities footballcontext = new SoccerEntities();
            List<Player> players = footballcontext.Players.ToList();
            return View(players);
        }
        public ActionResult Edit(int playerId)
        {
            SoccerEntities db = new SoccerEntities();
            Player player = db.Players.Single(m => m.ID == playerId);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);

        }
        [HttpPost]
        public ActionResult Edit(Player player)
        {
            SoccerEntities db = new SoccerEntities();
           
            {
                db.Entry(player).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { teamId=player.TeamID});
            }
         //   return View(player);
        }
    }
    }