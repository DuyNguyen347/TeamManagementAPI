using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamManagementAPI.GenericRepository;
using TeamManagementAPI.Models;
using TeamManagementAPI.Repositories;
using TeamManagementAPI.ViewModels;

namespace TeamManagementAPI.Controllers
{
    [Route("api/stadium")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper mapper;
        public StadiumController(IUnitOfWork UnitOfWork,IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }
        // GET: api/stadium
        [HttpGet]
        public IActionResult GetStadiums()
        {
            try
            {
                return Ok(mapper.Map<List<StadiumVM>>(UnitOfWork.StadiumRepo.GetAll().ToList()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/stadium/5
        [HttpGet("{id}")]
        public IActionResult GetStadium(int id)
        {
            try
            {
                return Ok(mapper.Map<StadiumVM>(UnitOfWork.StadiumRepo.GetById(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/stadium/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutStadium(int id, StadiumVM s)
        {

            if (id != s.Id)
            {
                return BadRequest();
            }
            var ExistingStadium = UnitOfWork.StadiumRepo.GetById(s.Id);
            if (ExistingStadium == null) return BadRequest("Không tồn tại trong League trong DB");
            mapper.Map(s, ExistingStadium);
            ExistingStadium.UpdateOn = DateTime.Now;
            try
            {
                UnitOfWork.StadiumRepo.Update(ExistingStadium);
                UnitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // POST: api/stadium
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostStadium(StadiumVM s)
        {
            Stadium le = mapper.Map<Stadium>(s);
            le.CreateOn = DateTime.Now;
            try
            {
                UnitOfWork.StadiumRepo.Add(le);
                UnitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/stadium/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStadium(int id)
        {
            try
            {
                if (UnitOfWork.StadiumRepo.Delete(id))
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
