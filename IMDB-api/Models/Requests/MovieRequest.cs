using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Models.Requests
{
    public class MovieRequest
    {
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public int ProducerId { get; set; }
        public List<int> ActorIds { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
