using IMDB_api.Models;
using IMDB_api.Models.DB;
using IMDB_api.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_api.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionString> options) : base(options.Value)
        {

        }
        public int Add(Producer producer)
        {
            const string sql = @" INSERT INTO Producers(Name,DOB,Bio,Sex) VALUES(@Name,@DOB,@Bio,@Sex); SELECT CAST(SCOPE_IDENTITY() as int)";
            return Add(sql, producer);
        }

        public void Delete(int id)
        {
            const string sql = @"DELETE FROM Producers WHERE Id = @Id";
            Delete(sql, id);
        }

        public Producer Get(int id)
        {
            const string sql = @"SELECT * FROM Producers WHERE Id = @Id";
            return Get(sql, id);
        }

        public IEnumerable<Producer> GetAll()
        {
            const string sql = @"SELECT * FROM Producers";
            return GetAll(sql);
        }

        public void Update(Producer producer)
        {
            const string sql = @"UPDATE Producers SET Name=@Name, DOB=@DOB, Bio=@Bio, Sex=@Sex WHERE Id = @Id";
            Update(sql, producer);
        }
    } 
}
