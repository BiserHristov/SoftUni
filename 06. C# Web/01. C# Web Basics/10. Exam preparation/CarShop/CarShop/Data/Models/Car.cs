using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Car
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

       // [Required]: It is not necessary to have Required attribute,
       // because int has a default value
        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(8)]
        [RegularExpression("[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public IEnumerable<Issue> Issues { get; init; } = new HashSet<Issue>();


    }
}
