using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Member
    {
        public string id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string avatar { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public string introduction { get; set; }

        public string gender { get; set; }

        public string birthday { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public long createAt { get; set; }
        public long updatedAt { get; set; }
        public long deletedAt { get; set; }
        public int status { get; set; }

        public enum MemberStatus { Active = 1, Deactive = 0, Deleted =-1}
    }
}