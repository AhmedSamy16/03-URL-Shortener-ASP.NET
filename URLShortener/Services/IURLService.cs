using URLShortener.DTOs;
using URLShortener.Models;

namespace URLShortener.Services
{
    public interface IURLService
    {
        public Task<List<ShortURL>> GetAllURLs();
        public Task<ShortURL> CreateURL(CreateShortUrl urlToCreate);
        public Task<ShortURL> GetShortURL(string shortUrl);
    }
}
