using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrlShortenerBlazor.DbModels;
using UrlShortenerBlazor.Shared.Models;

namespace UrlShortenerBlazor.ControllerServices.Interfaces
{
    public interface IShortenedUrlRepository
    {
        Task<ShortenedUrl> PutAsync(ShortenedUrl model);

        Task<ShortenedUrl> GetByFullUrlAsync(string fullUrl);

        Task<ShortenedUrl> GetByShortUrlAsync(string shortUrl);

        Task<IEnumerable<ShortenedUrl>> GetAllAsync();
    }
}
