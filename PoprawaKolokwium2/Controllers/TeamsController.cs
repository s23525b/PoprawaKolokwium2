using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PoprawaKolokwium2.Controllers
{
    [Route("api/teams")]
    public class TeamsController : Controller
    {
        private readonly IDbService _dbService;
        public TeamsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idTeam}")]
        public async Task<IActionResult> GetTeam(int idTeam)
        {
            return Ok(await _dbService.GetTeam(idTeam));
        }
    }
}