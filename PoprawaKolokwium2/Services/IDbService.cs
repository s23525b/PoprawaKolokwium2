using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoprawaKolokwium2
{
    public interface IDbService
    {
        Task<IEnumerable<object>> GetTeam(int teamID);
        Task<bool> AddMember(int memberID);
    }
}