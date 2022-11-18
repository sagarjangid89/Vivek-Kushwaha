using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tiko_DataAccess.Abstract.Dapper;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_DataAccess.Concrete.Dapper
{
    public class DpAgentDal : DpGenericRepository<Agent>, IDpAgentDal
    {
        private readonly IDbConnection _db;

        public DpAgentDal(IConfiguration config) : base(config)
        {
            _db = new SqliteConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<List<AgentDetail>> GetAgentDetails()
        {
            const string sql =
                "SELECT * FROM Agents";

            return await Task.Run(() => _db.Query<AgentDetail>(sql).ToList());
        }
    }
}