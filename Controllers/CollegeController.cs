using Microsoft.AspNetCore.Mvc;
using TryWebAPI.Models;
using TryWebAPI.Repository;

namespace TryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        ICollegeRepo _colzRepo;
        public CollegeController(ICollegeRepo colzRepo)
        {
            _colzRepo = colzRepo;
        }
        [HttpPost]
        [Route("add-college")]
        public IActionResult AddCollege(College colz)
        {
            if (colz == null)
            {
                return BadRequest("Invalid data"); ;
            }
            try
            {
                var clz = _colzRepo.AddCollegeData(colz);
                if(clz! == null)
                {
                    return Ok($"{clz.Id}");
                }
                else
                {
                    return Content(clz.Name);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-colleges")]
        public IActionResult GetAllColleges()
        {
            try
            {
                var colzList=_colzRepo.GetAllCollegeData(); 
                if(colzList != null)
                {
                    return Ok(colzList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-college/{id}")]
        public IActionResult GetCollege(int id)
        {
            try
            {
                var colz = _colzRepo.GetCollegeData(id);
                if (colz != null)
                {
                    return Ok(colz);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("edit-college/{id}")]
        public IActionResult EditCollege(int id, College c)
        {
            if (id != c.Id)
            {
                return BadRequest();
            }
            try
            {
                var colz = _colzRepo.UpdateCollegeData(id, c);
                if (colz != null)
                {
                    return Ok(colz);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteCollege/{id}")]
        public IActionResult DeleteCollege(int id)
        {
            try
            {
                var colz = _colzRepo.DeleteCollegeData(id);
                if (colz != null)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
