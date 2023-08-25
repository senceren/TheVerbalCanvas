using System.ComponentModel.DataAnnotations;

namespace TheVerbalCanvas.Areas.Admin.Models
{
    public class PostViewModel
    {

        [MaxLength(400)]
        public string Title { get; set; } = null!;
        public string? Content { get; set; }

        public IFormFile? PostImage { get; set; }

    }
}
