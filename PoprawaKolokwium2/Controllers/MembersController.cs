using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PoprawaKolokwium2.Controllers
{
    
        [Route("api/members")]
        [ApiController]
        public class MembersController : Controller
        {
            private readonly IDbService _dbService;
            public MembersController(IDbService dbService)
            {
                _dbService = dbService;
            }

            [HttpPost("{idMember}")]
            public async Task<IActionResult> AddMember(int idMember)
            {
                if(await _dbService.AddMember(idMember)) return Ok("Member Added");
                else return NotFound("Member not added");
            }
        }
}