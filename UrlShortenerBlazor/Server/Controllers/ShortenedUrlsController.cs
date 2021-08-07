using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortenerBlazor.ControllerServices.Interfaces;
using UrlShortenerBlazor.Shared.Models;

namespace UrlShortenerBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenedUrlsController : ControllerBase
    {
        private readonly IShortenedUrlService _shortenedUrlService;

        public ShortenedUrlsController(IShortenedUrlService shortenedUrlService)
        {
            _shortenedUrlService = shortenedUrlService;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrlAsync(ShortenUrlRequestModel model)
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _shortenedUrlService.AddToDatabaseAsync(model);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost("reverse")]
        public async Task<IActionResult> ReverseShortenedUrlAsync(FullUrlRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _shortenedUrlService.GetByShortUrlAsync(model);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

#if DEBUG
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(_shortenedUrlService.GetAllAsync());
        }
    }
#endif
}
