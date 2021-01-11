using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Classes;

namespace TravelTrip.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string BlogImage { get; set; }
        public ICollection<Comments> Comment { get; set; }
    }
}