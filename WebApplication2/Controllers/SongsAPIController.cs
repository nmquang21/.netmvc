using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SongsAPIController : ApiController
    {
        private MyDbContext db = new MyDbContext();
        // GET: api/SongsAPI
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<Song> GetSongs()
        {
            return db.Songs;
        }

        // GET: api/SongsAPI/5
        [ResponseType(typeof(Song))]
        public IHttpActionResult GetSong(string id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        // PUT: api/SongsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSong(string id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.id)
            {
                return BadRequest();
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SongsAPI
        [ResponseType(typeof(Song))]
        public IHttpActionResult PostSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            song.createAt= DateTimeOffset.Now.ToUnixTimeMilliseconds();
            db.Songs.Add(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SongExists(song.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = song.id }, song);
        }

        // DELETE: api/SongsAPI/5
        [ResponseType(typeof(Song))]
        public IHttpActionResult DeleteSong(string id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            db.Songs.Remove(song);
            db.SaveChanges();

            return Ok(song);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongExists(string id)
        {
            return db.Songs.Count(e => e.id == id) > 0;
        }
    }
}