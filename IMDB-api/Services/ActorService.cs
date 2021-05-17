using IMDB_api.Helpers;
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
        public int Add(ActorRequest actorRequest)
        {
           ValidationHelper.ValidateActor(actorRequest);
           return  _actorRepository.Add(new Actor
            {
                Name = actorRequest.Name,
                Bio = actorRequest.Bio,
                DOB = actorRequest.DOB,
                Sex = actorRequest.Sex
            });
            
        }

        public void Delete(int id)
        {
            if (_actorRepository.Get(id) != null)
            {
                _actorRepository.Delete(id);
                return;
            }
            throw new Exception($"Actor with id = {id} doesn't exists");
        }

        public ActorResponse Get(int id)
        {
            var actor =_actorRepository.Get(id);
            if(actor!=null)
            return new ActorResponse
            {
                Id = actor.Id,
                Name = actor.Name,
                DOB = actor.DOB,
                Sex = actor.Sex,
                Bio = actor.Bio
            };
            throw new Exception($"Actor with id = {id} doesn't exists");
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
            if (_actorRepository.Get(id) != null)
            {
                ValidationHelper.ValidateActor(actorRequest);
                _actorRepository.Update(new Actor
                {
                    Id = id,
                    Name = actorRequest.Name,
                    Bio = actorRequest.Bio,
                    Sex = actorRequest.Sex,
                    DOB = actorRequest.DOB
                });
                return;
            }
            throw new KeyNotFoundException($"Actor with id = {id} doesn't exists");
        }
    }
}
