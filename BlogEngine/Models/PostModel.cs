using Microsoft.Build.Framework;

namespace BlogEngine.Models
{
    public class PostModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public string Content { get; set; }


        [Required]
        public int IdCategory { get; set; }
    }
}
