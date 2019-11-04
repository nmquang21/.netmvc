using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Sensor
    {
        public string id { get; set; }
        public float temperature { get; set; }
        public float humid { get; set; }
        public long createAt { get; set; }
        public long updatedAt { get; set; }
        public long deletedAt { get; set; }
        public int status { get; set; }

        public enum MemberStatus { Active = 1, Deactive = 0, Deleted = -1 }
    }
}