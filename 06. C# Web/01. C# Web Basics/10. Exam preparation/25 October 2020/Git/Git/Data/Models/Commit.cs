using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data.Models
{
    public class Commit
    {
        [Required]
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(5)]
        public string Description { get;  set; }

        [Required]
        public DateTime CreatedOn { get;  set; }

        [Required]//not necessary
        public string CreatorId { get;  set; }
        public User Creator { get;  set; }

        [Required]//not necessary
        public string RepositoryId { get;  set; }
        public Repository Repository { get;  set; }




    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a CreatorId – a string
//•	Has Creator – a User object
//•	Has RepositoryId – a string
//•	Has Repository– a Repository object
