using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using TeamManagementAPI.GenericRepository;
using TeamManagementAPI.Models;
using TeamManagementAPI.Repositories;
using TeamManagementAPI.ViewModels;

namespace TeamManagementAPI.Controllers
{
    [Route("api/league")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper mapper;
        
        public LeagueController(IUnitOfWork UnitOfWork,IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }
        // GET: api/UnitOfWork
        [HttpGet]
        public IActionResult GetLeagues()
        {
            try
            {
                var json = UnitOfWork.LeagueRepo.GetAll().ToList();
                return Ok(mapper.Map<List<LeagueVM>>(UnitOfWork.LeagueRepo.GetAll().ToList()));
                //return Ok(json);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/UnitOfWork/5
        [HttpGet("{id}")]
        public IActionResult GetLeague(int id)
        {
            try
            {
                return Ok(mapper.Map<LeagueVM>(UnitOfWork.LeagueRepo.GetById(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/UnitOfWork/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutLeague(int id, LeagueVM l)
        {
            if (id != l.Id)
            {
                return BadRequest();
            }
            var existingLeague = UnitOfWork.LeagueRepo.GetById(l.Id);
            if(existingLeague == null) return BadRequest("Không tồn tại trong League trong DB");
            mapper.Map(l, existingLeague);
            existingLeague.UpdateOn = DateTime.Now;
            try
            {
                UnitOfWork.LeagueRepo.Update(existingLeague);
                UnitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // POST: api/UnitOfWork
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostLeague(LeagueVM l)
        {
            League le = mapper.Map<League>(l);
            le.CreateOn = DateTime.Now;
            try
            {
                UnitOfWork.LeagueRepo.Add(le);
                UnitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/UnitOfWork/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLeague(int id)
        {
            try
            {
                if (UnitOfWork.LeagueRepo.Delete(id))
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
    }
}
