using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BlogEngine.Models
{
    public class CategoryModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
    }
}
