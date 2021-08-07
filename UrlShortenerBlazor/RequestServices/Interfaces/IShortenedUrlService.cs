using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrlShortenerBlazor.Shared.Models;

namespace UrlShortenerBlazor.RequestServices.Interfaces
{
    public interface IShortenedUrlService
    {
        Task<ShortenUrlResponseModel> GetShortenedUrl(string address, ShortenUrlRequestModel model);
    }
}
