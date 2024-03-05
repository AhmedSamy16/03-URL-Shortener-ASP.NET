using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class ShortURL
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; } = Guid.NewGuid().ToString();
        public int Clicks { get; set; } = 0;
    }
}
