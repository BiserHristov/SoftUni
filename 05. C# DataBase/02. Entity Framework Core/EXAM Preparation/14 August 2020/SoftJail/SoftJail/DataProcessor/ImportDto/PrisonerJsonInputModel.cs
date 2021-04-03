using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerJsonInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("The [A-Z][a-z]{2,}")]
        public string Nickname { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }
        public int? CellId { get; set; }

        public ICollection<MailJsonInputModel> Mails { get; set; }


    }
}

//    "FullName": null,
//    "Nickname": "The Null",
//    "Age": 38,
//    "IncarcerationDate": "12/09/1967",
//    "ReleaseDate": "07/02/1989",
//    "Bail": 93934.2,
//    "CellId": 4,
//    "Mails"
