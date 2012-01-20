using System.ComponentModel.DataAnnotations;

namespace MyRadio.Models
{
    public class Media
    {
        [Key]
        public int MediaId { get; set; }

        public string Url { get; set; }

        public string Band { get; set; }

        public string Song { get; set; }
    }
}