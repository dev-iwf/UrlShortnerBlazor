using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerBlazor.ControllerServices.Interfaces;
using UrlShortenerBlazor.DbModels;

namespace UrlShortenerBlazor.ControllerServices
{
    public class ShortenUrlRepository : IShortenedUrlRepository
    {
        private readonly UrlShortenerBlazorDbContext _context;

        public ShortenUrlRepository(UrlShortenerBlazorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShortenedUrl>> GetAllAsync()
        {
            return await _context.ShortenedUrls.ToListAsync();
        }

        public async Task<ShortenedUrl> PutAsync(ShortenedUrl model)
        {
            var result = await _context.ShortenedUrls.AddAsync(model);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ShortenedUrl> GetByFullUrlAsync(string fullUrl)
        {
            return await _context.ShortenedUrls
                .Where(x => x.FullUrl == fullUrl)
                .FirstOrDefaultAsync();
        }

        public async Task<ShortenedUrl> GetByShortUrlAsync(string shortUrl)
        {
            return await _context.ShortenedUrls
                .Where(x => x.Short == shortUrl)
                .FirstOrDefaultAsync();
        }
    }
}
