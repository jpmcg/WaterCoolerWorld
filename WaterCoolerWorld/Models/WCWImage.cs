using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterCoolerWorld.Models
{
    public class WcwImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int CoolerId { get; set; }
    }
}