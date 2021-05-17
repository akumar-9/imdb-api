using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Models.Requests
{
    public class ProducerRequest
    {
       // [Required(ErrorMessage = "{0}  cannot be null")]
        public string Name { get; set; }

       // [Required(ErrorMessage = "{0}  cannot be null")]
        public string Bio { get; set; }

        //[Range(typeof(DateTime), "1950-01-01", "2010-01-01")]
        public DateTime DOB { get; set; }

        //[Required(ErrorMessage = "{0}  cannot be null")]
        public string Sex { get; set; }
    }
}
