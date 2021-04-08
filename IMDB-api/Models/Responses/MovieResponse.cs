using IMDB_api.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Models.Responses
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public Producer Producer { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
