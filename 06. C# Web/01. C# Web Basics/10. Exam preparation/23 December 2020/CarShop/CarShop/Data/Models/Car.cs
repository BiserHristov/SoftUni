using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CarShop.Data.DataConstants;

namespace CarShop.Data.Models
{
    public class Car
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(CarMaxLength)]
        public string Model { get; set; }

       // [Required]: It is not necessary to have Required attribute,
       // because int has a default value
        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(CarMaxPlateNumberLength)]
        //[RegularExpression("[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public IEnumerable<Issue> Issues { get; init; } = new HashSet<Issue>();


    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Model – a string with min length 5 and max length 20 (required)
//•	Has a Year – a number (required)
//•	Has a PictureUrl – string (required)
//•	Has a PlateNumber – a string – Must be a valid Plate number (2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters (required)
//•	Has a OwnerId – a string (required)
//•	Has a Owner – a User object
//•	Has Issues collection – an Issue type

