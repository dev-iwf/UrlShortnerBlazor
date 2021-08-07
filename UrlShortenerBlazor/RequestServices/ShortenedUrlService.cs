using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UrlShortenerBlazor.RequestServices.Interfaces;
using UrlShortenerBlazor.Shared.Models;

namespace UrlShortenerBlazor.RequestServices
{
    public class ShortenedUrlService : IShortenedUrlService
    {
        private readonly HttpClient httpClient;

        public ShortenedUrlService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ShortenUrlResponseModel> GetShortenedUrl(string address, ShortenUrlRequestModel model)
        {
            var response = await httpClient.PostAsJsonAsync<ShortenUrlRequestModel>(address, model);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ShortenUrlResponseModel>();
            }
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}
