using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TravelTrip.Models.Classes
{
    public class BlogComment
    {
        public IEnumerable<Blog> type1 { get; set; }
        public IEnumerable<Comments> type2 { get; set; }
        public IEnumerable<Blog> type3 { get; set; }
        public IEnumerable<Comments> type4 { get; set; }
        public IEnumerable<Blog> type5 { get; set; }
    }
}