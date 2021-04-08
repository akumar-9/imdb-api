using IMDB_api.Models.Requests;
using IMDB_api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Services.Interfaces
{
    public interface IProducerService
    {
        public ProducerResponse Get(int id);
        public IEnumerable<ProducerResponse> GetAll();
        public void Add(ProducerRequest producerRequest);
        public void Update(ProducerRequest producerRequest, int id);
        public void Delete(int id);
    }
}
