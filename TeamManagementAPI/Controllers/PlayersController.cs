using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeamManagementAPI.GenericRepository;
using TeamManagementAPI.Models;

namespace TeamManagementAPI.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        public PlayersController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        // GET: api/teams
        [HttpGet]
        public IActionResult GetPlyaers()
        {
            try
            {
                return Ok(UnitOfWork.PlayerRepo.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpGet("GetShort")]
        //public IActionResult GetteamsShort()
        //{
        //    try
        //    {
        //        return Ok(teams.GetAllShort());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
        // GET: api/teams/5
        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            try
            {
                return Ok(UnitOfWork.PlayerRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutTeam(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            try
            {
                if (UnitOfWork.PlayerRepo.Update(player))
                {
                    UnitOfWork.Save();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // POST: api/teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTeam(Player player)
        {
            try
            {
                if (UnitOfWork.PlayerRepo.Add(player))
                {
                    UnitOfWork.Save();
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/teams/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            try
            {
                if (UnitOfWork.PlayerRepo.Delete(id))
                {
                    UnitOfWork.Save();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //private bool TeamExists(int id)
        //{
        //    return (_context.teams?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
