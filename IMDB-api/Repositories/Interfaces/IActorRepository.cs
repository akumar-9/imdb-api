
using IMDB_api.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Repositories.Interfaces
{
    public interface IActorRepository
    {
        public Actor Get(int id);
        public IEnumerable<Actor> GetAll();
        public void Add(Actor actor);
        public void Delete(int id);
        public void Update(Actor actor);
        public IEnumerable<Actor> GetByMovie(int movieId);

    }
}   
