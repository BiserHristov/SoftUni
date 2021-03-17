using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class CustomerInputModel
    {
        public string Name { get; set; }

        public DateTime birthDate { get; set; }

        public bool isYoungDriver { get; set; }
    }

    //"name": "Natalie Poli",
    //"birthDate": "1990-10-04T00:00:00",
    //"isYoungDriver": false
}
