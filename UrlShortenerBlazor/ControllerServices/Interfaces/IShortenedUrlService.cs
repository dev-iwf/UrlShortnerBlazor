using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrlShortenerBlazor.DbModels;
using UrlShortenerBlazor.Shared.Models;

namespace UrlShortenerBlazor.ControllerServices.Interfaces
{
    public interface IShortenedUrlService
    {
        Task<ShortenUrlResponseModel> AddToDatabaseAsync(ShortenUrlRequestModel model);

        Task<FullUrlResponseModel> GetByShortUrlAsync(FullUrlRequestModel model);

        Task<IEnumerable<ShortenedUrl>> GetAllAsync();


    }
}
