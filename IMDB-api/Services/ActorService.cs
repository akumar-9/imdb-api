using IMDB_api.Models.DB;
using IMDB_api.Models.Requests;
using IMDB_api.Models.Responses;
using IMDB_api.Repositories.Interfaces;
using IMDB_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public void Add(ActorRequest actorRequest)
        {
            _actorRepository.Add(new Actor
            {
                Name = actorRequest.Name,
                Bio = actorRequest.Bio,
                DOB = actorRequest.DOB,
                Sex = actorRequest.Sex
            });
        }

        public void Delete(int id)
        {
            _actorRepository.Delete(id);
        }

        public ActorResponse Get(int id)
        {
            var actor =_actorRepository.Get(id);
            return new ActorResponse
            {
                Id = actor.Id,
                Name = actor.Name,
                DOB = actor.DOB,
                Sex = actor.Sex,
                Bio = actor.Bio
            };
        }

        public IEnumerable<ActorResponse> GetAll()
        {
            var actor = _actorRepository.GetAll();
            return actor.Select(a => new ActorResponse
            {
                Id = a.Id,
                Name = a.Name,
                DOB = a.DOB,
                Sex = a.Sex,
                Bio = a.Bio
            });
        }

        public void Update(ActorRequest actorRequest, int id)
        {
            _actorRepository.Update(new Actor
            {   Id = id,
                Name = actorRequest.Name,
                Bio = actorRequest.Bio,
                Sex = actorRequest.Sex,
                DOB = actorRequest.DOB
            });
        }
    }
}
