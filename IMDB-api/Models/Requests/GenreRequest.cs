using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Models.Requests
{
    public class GenreRequest
    {
       // [Required(ErrorMessage = "{0}  cannot be null")]
        public string Name { get; set; }

    }
}
