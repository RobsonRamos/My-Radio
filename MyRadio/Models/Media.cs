using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyRadio.Models
{
    public class Media
    {
        [Key]
        public int MediaId { get; set; }

        [Required(ErrorMessage = "The URL is required.")]
        public string Url { get; set; }     
    }
}