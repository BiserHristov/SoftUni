using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static BattleCards.Data.DataConstants;

namespace BattleCards.Data.Models
{
    public class Card
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public int Id { get; init; }

        [Required]
        [MaxLength(CardNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }
        
        public int Attack { get; set; }

        public int Health { get; set; }

        [Required]
        [MaxLength(CardDescripttionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserCard> Users = new HashSet<UserCard>();


    }
}
//•	Has Id – an int, Primary Key
//•	Has Name – a string (required); min.length: 5, max.length: 15
//•	Has ImageUrl – a string (required)
//•	Has Keyword – a string (required)
//•	Has Attack – an int (required); cannot be negative
//•	Has Health – an int (required); cannot be negative
//•	Has a Description – a string with max length 200 (required)
//•	Has UserCard collection
