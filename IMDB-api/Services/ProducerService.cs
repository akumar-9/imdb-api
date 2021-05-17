using IMDB_api.Helpers;
using IMDB_api.Models.DB;
using IMDB_api.Models.Requests;
using IMDB_api.Models.Responses;
using IMDB_api.Repositories.Interfaces;
using IMDB_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public int Add(ProducerRequest producerRequest)
        {
            ValidationHelper.ValidateProducer(producerRequest);
            return _producerRepository.Add(new Producer
            {
                Name = producerRequest.Name,
                DOB = producerRequest.DOB,
                Sex = producerRequest.Sex,
                Bio = producerRequest.Bio,
            });
        }

        public void Delete(int id)
        {
            if (_producerRepository.Get(id) != null)
            {
                _producerRepository.Delete(id);
                return;
            }
            throw new Exception($"Producer with id = {id} doesn't exists");
        }

        public ProducerResponse Get(int id)
        {
            var producer = _producerRepository.Get(id);
            if(producer!= null)
                return new ProducerResponse
                {
                    Id = producer.Id,
                    Name = producer.Name,
                    DOB = producer.DOB,
                    Bio = producer.Bio,
                    Sex = producer.Sex
                };
            throw new Exception($"Producer with id = {id} doesn't exists");
        }

        public IEnumerable<ProducerResponse> GetAll()
        {
            return _producerRepository.GetAll().Select(p => new ProducerResponse
            {
                Id = p.Id,
                Name = p.Name,
                Bio = p.Bio,
                DOB = p.DOB,
                Sex = p.Sex
            });
        }

        public void Update(ProducerRequest producerRequest,int id)
        {
            if (_producerRepository.Get(id) != null)
            {
                ValidationHelper.ValidateProducer(producerRequest);
                _producerRepository.Update(new Producer
                {
                    Id = id,
                    Name = producerRequest.Name,
                    DOB = producerRequest.DOB,
                    Sex = producerRequest.Sex,
                    Bio = producerRequest.Bio,
                });
                return;
            }
            throw new Exception($"Producer with id = {id} doesn't exists");
        }
    }
}
