using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTrip.Models.Classes
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string Location { get; set; }

    }
}