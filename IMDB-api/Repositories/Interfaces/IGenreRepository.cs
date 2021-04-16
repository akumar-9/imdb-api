using IMDB_api.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public Genre Get(int id);
        public IEnumerable<Genre> GetAll();
        public int Add(Genre genre);
        public void Delete(int id);
        public void Update(Genre genre);
        public IEnumerable<Genre> GetByMovie(int movieId);

    }
}
