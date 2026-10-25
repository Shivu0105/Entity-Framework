using EF_1.Models;
using EF_1.Repository;
using EF_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;
        public AnimalController(AnimalService animal)
        {
            _animalService = animal;
        }

        [HttpGet]
        public async Task<IActionResult> getAnimal()
        {
            try
            {
                // gettting data from DB using EF Core

                var animalsData = await _animalService.GetAnimalsAsync();
                return Ok(animalsData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                       
        }

        [HttpPost]
        public async Task<IActionResult> createAnimal([FromBody] Animals entity)
        {
            try
            {
                // Adding data to the DB using EF Core

               var result = await _animalService.AddAnimal(entity);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            try
            {
                var result = await _animalService.DeleteAnimal(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] Animals entity)
        {
            try
            {
                var result = await _animalService.UpdateAnimal(id, entity);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #region Day 1 Controller Code

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("Learning Controller 1..!");
        //}

        //[HttpGet("GetTest")]
        //public IActionResult GetTest()
        //{
        //    return Ok("Learning Controller 2..!");
        //}

        //[HttpGet("GetTry")]
        //public IActionResult GetTry()
        //{
        //    return Ok("Learning Controller 3..!");
        //}

        //[HttpGet("GetTemp")]
        //public IActionResult GetTemp()
        //{
        //    return BadRequest("Learning 4");
        //}

        //[HttpGet("GetTroll")]
        //public IActionResult GetTroll()
        //{
        //    return NotFound("Learning 5");
        //}

        #endregion
    }
}
