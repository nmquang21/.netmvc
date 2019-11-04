using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SongController : Controller
    {
        private MyDbContext _myDbContext = new MyDbContext();
        // GET: Song
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return new JsonResult()
            {
                //Data = _myDbContext.Members.ToList(),
                Data = _myDbContext.Songs.Where(Song => Song.status != (int)Song.SongStatus.Deleted),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }
        [HttpPost]
        public ActionResult Create(Song song)
        {
            song.id = DateTime.Now.Millisecond.ToString();
            _myDbContext.Songs.Add(song);
            song.createAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            song.status = (int)Member.MemberStatus.Active;
            _myDbContext.SaveChanges();
            //listMembers.Add(member);
            return new JsonResult()
            {
                Data = song,
            };
        }
        [HttpPut]
        public ActionResult Update(string id, Song updateSong)
        {
            Song existSong = _myDbContext.Songs.Find(id);
            if (existSong == null)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(new { success = false, message = "Song is not found" }, JsonRequestBehavior.AllowGet);
            }

            existSong.description = updateSong.description;
            existSong.name = updateSong.name;
            existSong.author = updateSong.author;
            existSong.link = updateSong.link;
            existSong.singer = updateSong.singer;
            existSong.updatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            _myDbContext.Songs.AddOrUpdate(existSong);
            _myDbContext.SaveChanges();
            return new JsonResult()
            {
                Data = existSong,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            Song existSong = _myDbContext.Songs.Find(id);
            if (existSong == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(new { success = false, message = "Song is not found" }, JsonRequestBehavior.AllowGet);

            }
            existSong.deletedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            existSong.status = (int)Member.MemberStatus.Deleted;
            _myDbContext.Songs.AddOrUpdate(existSong);
            _myDbContext.SaveChanges();
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}