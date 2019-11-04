
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Song
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string singer { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string link { get; set; }
        public long createAt { get; set; }
        public long updatedAt { get; set; }
        public long deletedAt { get; set; }
        public int status { get; set; }

        public enum SongStatus { Active = 1, Deactive = 0, Deleted = -1 }
    }
}