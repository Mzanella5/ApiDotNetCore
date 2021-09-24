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
    public class StoreController : ControllerBase
    {
        private readonly StoreRepository _repo;

        public StoreController(StoreRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Store store)
        {
            try
            {
                _repo.Add(store);
                if (await _repo.SaveChangesAsync())
                    return Ok(store);
                else
                    return BadRequest("API: unknown error");
            }
            catch(Exception ex)
            {
                return BadRequest("API: " + ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Update(Store store){
            try
            {
                _repo.Update(store);
                if (await _repo.SaveChangesAsync())
                    return Ok(store);
                else
                    return BadRequest("API: unknown error");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Store store){
            try
            {
                _repo.Delete(store);
                if (await _repo.SaveChangesAsync())
                    return Ok(store);
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
                Store result = await _repo.GetStoreByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListStores(){

            try
            {
                List<Store> list = await _repo.GetStoresAsync();
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("find/{searchString?}")]
        public async Task<IActionResult> SearchStores(string searchString){

            try
            {
                List<Store> list = await _repo.GetStoresBySearchStringAsync(searchString);
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
