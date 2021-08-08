using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UrlShortenerBlazor.ControllerServices.Interfaces;
using UrlShortenerBlazor.DbModels;
using UrlShortenerBlazor.Shared.Models;

namespace UrlShortenerBlazor.ControllerServices
{
    public class ShortenedUrlService : IShortenedUrlService
    {
        private readonly IShortenedUrlRepository _repository;

        public ShortenedUrlService(IShortenedUrlRepository repository)
        {
            _repository = repository;
        }
        public async Task<ShortenUrlResponseModel> AddToDatabaseAsync(ShortenUrlRequestModel model)
        {
            var dbEntry = await _repository.GetByFullUrlAsync(model.FullUrl);

            if (dbEntry is null)
            {
                var newShortenedUrl = new ShortenedUrl()
                {
                    FullUrl = model.FullUrl,
                    Created = DateTime.Now,
                    Short = Path.GetRandomFileName().Split(".")[0]
                };

                dbEntry = await _repository.PutAsync(newShortenedUrl);
            }

            return new ShortenUrlResponseModel()
            {
                ShortenedUrl = dbEntry.Short
            };
        }

        public async Task<IEnumerable<ShortenedUrl>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FullUrlResponseModel> GetByShortUrlAsync(FullUrlRequestModel model)
        {
            var dbEntry = await _repository.GetByShortUrlAsync(model.ShortUrl);

            if (dbEntry is null)
                return null;

            return new FullUrlResponseModel()
            {
                FullUrl = dbEntry.FullUrl
            };
        }
    }
}
