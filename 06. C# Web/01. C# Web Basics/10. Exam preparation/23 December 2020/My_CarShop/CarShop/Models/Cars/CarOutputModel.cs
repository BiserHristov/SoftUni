﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Cars
{
    public class CarOutputModel
    {
        public string Id { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
        public string Image { get; init; }
        public string PlateNumber { get; init; }
        public int RemainingIssues { get; init; }
        public int FixedIssues { get; init; }


    }
}
