using System.ComponentModel.DataAnnotations;

namespace URLShortener.DTOs
{
    public class CreateShortUrl
    {
        [Required(ErrorMessage = "url is required")]
        public string Url { get; set; }
    }
}
