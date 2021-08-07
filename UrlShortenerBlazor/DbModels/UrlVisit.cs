using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UrlShortenerBlazor.DbModels
{
    public class UrlVisit
    {
        public int Id { get; set; }

        [ForeignKey("ShortenedUrl")]
        public int ShortenedUrlId { get; set; }
        
        public string VisitedBy { get; set; }
        
        public DateTime VisitedOn { get; set; }

        public ShortenedUrl ShortenedUrl { get; set; }
    }
}
