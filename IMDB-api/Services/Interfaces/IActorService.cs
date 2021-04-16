using IMDB_api.Models.Requests;
using IMDB_api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Services.Interfaces
{
    public interface IActorService
    {
        public ActorResponse Get(int id);
        public IEnumerable<ActorResponse> GetAll();
        public int Add(ActorRequest actorRequest);
        public void Delete(int id);
        public void Update(ActorRequest actorRequest, int id);

    }
}
