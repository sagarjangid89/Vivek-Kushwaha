using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiko_DataAccess.Abstract.EntityFramework;
using Tiko_Entities.Concrete;
using Tiko_Entities.DTOs;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class EfAgentDal : EfGenericRepository<Agent, TikoDbContext>, IEfAgentDal
    {
        public async Task<List<AgentDetail>> GetAgentDetails()
        {
            await using TikoDbContext context = new();
            var result = from agent in context.Agents
                         
                         select new AgentDetail()
                         {
                             Id = agent.Id,
                             Name = agent.Name,
                            

                         };
            return result.ToList();
        }
    }
}