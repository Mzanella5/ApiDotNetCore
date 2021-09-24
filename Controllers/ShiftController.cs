using ApiTest.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftRepository _repo;

        public ShiftController(ShiftRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Shift shift)
        {
            try
            {
                _repo.Add(shift);
                if (await _repo.SaveChangesAsync())
                    return Ok(shift);
                else
                    return BadRequest("API: unknown error");
            }
            catch(Exception ex)
            {
                return BadRequest("API: " + ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Update(Shift shift){
            try
            {
                _repo.Update(shift);
                if (await _repo.SaveChangesAsync())
                    return Ok(shift);
                else
                    return BadRequest("API: unknown error");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Shift shift){
            try
            {
                _repo.Delete(shift);
                if (await _repo.SaveChangesAsync())
                    return Ok(shift);
                else
                    return BadRequest("API: unknown error");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                Shift result = await _repo.GetShiftByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListShifts(){

            try
            {
                List<Shift> list = await _repo.GetShiftsAsync();
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("find/{searchString?}")]
        public async Task<IActionResult> ListShifts(string searchString){

            try
            {
                List<Shift> list = await _repo.GetShiftsBySearchStringAsync(searchString);
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
