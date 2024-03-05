using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.DTOs;
using URLShortener.Models;

namespace URLShortener.Services
{
    public class URLService(ApplicationDbContext context) : IURLService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ShortURL> CreateURL(CreateShortUrl urlToCreate)
        {
            ShortURL url = new()
            {
                Url = urlToCreate.Url,
            };
            await _context.ShortURLs.AddAsync(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public Task<List<ShortURL>> GetAllURLs()
        {
            return _context.ShortURLs.AsNoTracking().ToListAsync();
        }

        public async Task<ShortURL> GetShortURL(string shortUrl)
        {
            var url = await _context.ShortURLs.FirstOrDefaultAsync(s => s.ShortUrl == shortUrl);
            if (url is null)
                return null;

            url.Clicks++;
            await _context.SaveChangesAsync();
            return url;
        }
    }
}
