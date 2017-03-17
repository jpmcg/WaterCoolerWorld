using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterCoolerWorld.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string Quote { get; set; }
        public string CustomerName { get; set; }
        public bool Active { get; set; }
    }
}