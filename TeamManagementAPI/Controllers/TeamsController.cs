using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamManagementAPI.GenericRepository;
using TeamManagementAPI.Models;
using TeamManagementAPI.Repositories;
using TeamManagementAPI.Helper;
using AutoMapper;
using TeamManagementAPI.ViewModels;

namespace TeamManagementAPI.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper mapper;
        //private readonly ITeamRepository teams;
        public JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        public TeamsController(IUnitOfWork UnitOfWork,IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }
        // GET: api/teams
        [HttpGet]
        public IActionResult GetTeams()
        {
            try
            {
                var temp = UnitOfWork.TeamRepo.GetWithReference()
                    .Include(team => team.League).Include(team => team.Stadium).ToList();
                //return Ok(UnitOfWork.TeamRepo.GetWithReference()
                //    .Include(team => team.League).Include(team=>team.Stadium).Select(l => mapper.Map<TeamVM>(l)).ToList());
                return Ok(mapper.Map<List<TeamVM>>(temp));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("TeamsAndPlayer")]
        public IActionResult GetTeamsAndPlayer()
        {
            try
            {
                return Ok(JsonSerializer.Serialize(UnitOfWork.TeamRepo.GetWithReference().Include(t => t.Players).ToList(), new JsonOptionsCustom().options));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("Test")]
        public IActionResult GetteamsShort()
        {
            try
            {
                var temp = UnitOfWork.TeamRepo.GetWithReference().Include(t => t.Stadium).ToList();
                return Ok(temp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        // GET: api/teams/5
        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            try
            {
                return Ok(mapper.Map<TeamVM>(UnitOfWork.TeamRepo.GetWithReference().Include(t => t.League).Include(t => t.Stadium).FirstOrDefault(t => t.Id == id)));
            }
            catch (Exception ex)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutTeam(int id, TeamVM team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }
            var ExistingTeam = UnitOfWork.TeamRepo.GetById(team.Id);
            if (ExistingTeam == null) return BadRequest("Không tồn tại trong Team trong DB");
            mapper.Map(team, ExistingTeam);
            ExistingTeam.UpdateOn = DateTime.Now;
            try
            {
                if (UnitOfWork.TeamRepo.Update(ExistingTeam))
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
        public IActionResult PostTeam(TeamVM team)
        {
            Team le = mapper.Map<Team>(team);
            le.CreateOn = DateTime.Now;
            try
            {
                if (UnitOfWork.TeamRepo.Add(le))
                {
                    UnitOfWork.Save();
                    return Ok();
                }
                else return BadRequest();
            }
            catch(Exception ex) 
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
                if (UnitOfWork.TeamRepo.Delete(id))
                {
                    UnitOfWork.Save();
                    return Ok();
                }
                return NotFound();
            }
            catch(Exception ex)
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
