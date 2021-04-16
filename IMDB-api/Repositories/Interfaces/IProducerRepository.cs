using IMDB_api.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        public Producer Get(int id);
        public IEnumerable<Producer> GetAll();
        public int Add(Producer producer);
        public void Update(Producer producer);
        public void Delete(int id);
    }
}
