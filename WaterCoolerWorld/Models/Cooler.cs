using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace WaterCoolerWorld.Models
{
    public class Cooler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CoolerCatergory Categrory { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public virtual WcwImage Image { get; set; }
        public bool InStock { get; set; }
    }

    public enum CoolerCatergory
    {
        BottleCooler,
        MainsCooler,
        CoffeeMachine
    }
}