using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MembersAPIController : ApiController
    {
        private WebApplication2Context db = new WebApplication2Context();

        // GET: api/MembersAPI
        public IQueryable<Member> GetMembers()
        {
            return db.Members;
        }

        // GET: api/MembersAPI/5
        [ResponseType(typeof(Member))]
        public IHttpActionResult GetMember(string id)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/MembersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMember(string id, Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.id)
            {
                return BadRequest();
            }

            db.Entry(member).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/MembersAPI
        [ResponseType(typeof(Member))]
        public IHttpActionResult PostMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Members.Add(member);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MemberExists(member.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = member.id }, member);
        }

        // DELETE: api/MembersAPI/5
        [ResponseType(typeof(Member))]
        public IHttpActionResult DeleteMember(string id)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            db.Members.Remove(member);
            db.SaveChanges();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberExists(string id)
        {
            return db.Members.Count(e => e.id == id) > 0;
        }
    }
}