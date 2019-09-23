using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Models
{
    public class Page
    {
        [Key]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
