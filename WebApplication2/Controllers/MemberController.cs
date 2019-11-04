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
    public class MemberController : Controller
    {
        //private static List<Member> listMembers = new List<Member>();

        private MyDbContext _myDbContext = new MyDbContext();
        // GET: Member
        [HttpGet]
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
                Data = _myDbContext.Members.Where(member => member.status != (int)Member.MemberStatus.Deleted),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }
        [HttpPost]
        public ActionResult Create(Member member)
        {
            member.id = DateTime.Now.Millisecond.ToString();
            _myDbContext.Members.Add(member);
            member.createAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            member.status = (int)Member.MemberStatus.Active;
            _myDbContext.SaveChanges();
            //listMembers.Add(member);
            return new JsonResult()
            {
                Data = member,
            };
        }
        [HttpPut]
        public ActionResult Update(string id, Member updateMember)
        {
            Member existMember = _myDbContext.Members.Find(id);
            if (existMember == null)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(new { success = false, message = "Member is not found" }, JsonRequestBehavior.AllowGet);
            }
            existMember.email = updateMember.email;
            existMember.password = updateMember.password;
            existMember.updatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            _myDbContext.Members.AddOrUpdate(existMember);
            _myDbContext.SaveChanges();
            return new JsonResult()
            {
                Data = existMember,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            Member existMember = _myDbContext.Members.Find(id);
            if (existMember == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(new { success = false, message = "Member is not found" }, JsonRequestBehavior.AllowGet);

            }
            existMember.deletedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            existMember.status = (int)Member.MemberStatus.Deleted;
            _myDbContext.Members.AddOrUpdate(existMember);
            _myDbContext.SaveChanges();
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}