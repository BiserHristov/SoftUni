using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Cars
{
   public class CarInputAddModel
    {
        public string Model { get; init; }
        public int Year { get; init; }
        public string Image { get; set; }
        public string PlateNumber { get; init; }

    }
}
