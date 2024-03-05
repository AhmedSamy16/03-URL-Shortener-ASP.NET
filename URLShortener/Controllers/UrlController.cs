using Microsoft.AspNetCore.Mvc;
using URLShortener.DTOs;
using URLShortener.Services;

namespace URLShortener.Controllers
{
    [Route("api/urls")]
    [ApiController]
    public class UrlController(IURLService urlService) : ControllerBase
    {
        private readonly IURLService _urlService = urlService;
        [HttpGet]
        public async Task<IActionResult> GetAllUrls()
        {
            var result = await _urlService.GetAllURLs();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShortUrl([FromBody] CreateShortUrl urlToCreate)
        {
            var url = await _urlService.CreateURL(urlToCreate);
            return Ok(url);
        }
        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> GetShortUrl([FromRoute] string shortUrl)
        {
            var url = await _urlService.GetShortURL(shortUrl);
            if (url is null)
                return NotFound("url not found");

            return Ok(url);
        }
    }
}
