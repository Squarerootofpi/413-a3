using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _413assignment3.Models
{
    /// <summary>
    /// This model represents a movie, and what makes a valid movie
    /// </summary>
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        //[Compare("Independence Day", ErrorMessage = "The movie Independence Day is not allowed.")]
        //[RegularExpression("^(!Independence Day).*")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int Year { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Director { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25,ErrorMessage = "The max length is 25 here bozo")]
        public string Notes { get; set; }

    }
}
