using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MemberController : Controller
    {
        private static List<Member> listMembers = new List<Member>();

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
                Data = _myDbContext.Members.ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }
        [HttpPost]
        public ActionResult Create(Member member)
        {
            member.id = DateTime.Now.Millisecond.ToString();
            _myDbContext.Members.Add(member);
            _myDbContext.SaveChanges();
            //listMembers.Add(member);
            return new JsonResult()
            {
                Data = member,
            };
        }
    }
}