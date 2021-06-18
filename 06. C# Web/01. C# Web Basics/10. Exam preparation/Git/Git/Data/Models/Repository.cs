using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data.Models
{
    public class Repository
    {

        [Required]
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; private set; }

        [Required]
        public DateTime CreatedOn { get; private set; }

        [Required]
        public bool IsPublic { get; private set; }

        public string OwnerId { get; private set; }
        public User Owner { get; private set; }
        public IEnumerable<Commit> Commits { get; private set; } = new HashSet<Commit>();

    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 3 and max length 10 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a IsPublic – bool (required)
//•	Has a OwnerId – a string
//•	Has a Owner – a User object
//•	Has Commits collection – a Commit type
