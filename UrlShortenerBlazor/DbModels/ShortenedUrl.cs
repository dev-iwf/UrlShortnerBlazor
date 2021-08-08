using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UrlShortenerBlazor.DbModels
{
    public class ShortenedUrl
    {
        public int Id { get; set; }

        [Required]
        public string FullUrl { get; set; }
        
        [Required]
        public string Short { get; set; }

        public DateTime Created { get; set; }

        public List<UrlVisit> UrlVisits { get; set; }
    }
}