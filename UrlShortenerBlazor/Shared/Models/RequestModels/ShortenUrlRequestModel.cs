using System.ComponentModel.DataAnnotations;
using UrlShortenerBlazor.Shared.Models.Validators;

namespace UrlShortenerBlazor.Shared.Models
{
    public class ShortenUrlRequestModel
    {
        [Required]
        [ValidUrl]
        [StringLength(2_083, ErrorMessage = "URL is too long")]
        public string FullUrl { get; set; }
    }
}
