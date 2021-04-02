using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class BookJsonInputModel
    {
        [Required]
        public int? Id { get; set; }
    }
}