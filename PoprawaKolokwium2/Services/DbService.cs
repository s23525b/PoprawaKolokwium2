using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoprawaKolokwium2.DTO;

namespace PoprawaKolokwium2
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<object>> GetTeam(int teamID)
        {
            return await _dbContext.Teams
                .Where(e => e.TeamID == teamID)
                .Select(e => new SomeTeam()
                {
                    TeamName = e.TeamName,
                    TeamDescription = e.TeamDescription,
                    OrganizationName = e.Organization.OrganizationName,
                    Memberships = e.Memberships,

                })
                .ToListAsync();
        }

       

        public async Task<bool> AddMember(int memberID)
        {
            if (_dbContext.Members.Any(e => e.MemberID != memberID))
            {
                var member = new Member() { MemberID = memberID };
                _dbContext.Attach(member);
                _dbContext.Add(member);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

    }
}
