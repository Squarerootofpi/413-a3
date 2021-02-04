using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _413assignment3.Models
{
    public class Movie
    {
        [Required(AllowEmptyStrings = false)]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        //[Compare("Independence Day", ErrorMessage = "The movie Independence Day is not allowed.")]
        [RegularExpression("^(!Independence Day).*")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int Year { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Director { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        public string Notes { get; set; }

    }
}
