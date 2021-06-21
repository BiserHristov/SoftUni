using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Issue
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        
        public bool IsFixed { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a IsFixed – a bool indicating if the issue has been fixed or not (required)
//•	Has a CarId – a string (required)
//•	Has Car – a Car object

