using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Models.Requests
{
    public class MovieRequest
    {
       // [Required(ErrorMessage = "{0} cannot be null")]
        public string Name { get; set; }

   //     [Range(1910,2040)]
        public int YearOfRelease { get; set; }

     //   [Required(ErrorMessage = "{0}  cannot be null")]
        public string Plot { get; set; }

       // [Url(ErrorMessage = "Enter a valid {0} ")]
        public string Poster { get; set; }
        //[Range(0, Int32.MaxValue)]
        public int ProducerId { get; set; }
        //[MinLength(1,ErrorMessage ="There should be atleast one {0}")]
        public List<int> ActorIds { get; set; }
        //[MinLength(1,ErrorMessage ="There should be atleat one {0}")]
        public List<int> GenreIds { get; set; }
    }
}
