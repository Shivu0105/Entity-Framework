using EF_1.Models;
using EF_1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalDB _animal;
        public AnimalController(AnimalDB animal)
        {
            _animal = animal;
        }

        [HttpGet]
        public async Task<IActionResult> getAnimal()
        {
            try
            {
                // gettting data from DB using EF Core

                var animalsData = await _animal.AnimalsTable.ToListAsync();

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

                _animal.AnimalsTable.Add(entity);
                await _animal.SaveChangesAsync();

                return Ok("Data Saved Successfully");

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
                var entity = await _animal.AnimalsTable.FindAsync(id);
                if (entity == null)
                {
                    return NotFound("Animal not found");
                }

                _animal.AnimalsTable.Remove(entity);
                await _animal.SaveChangesAsync();

                return Ok("Data Deleted Successfully");
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
                var existingEntity = await _animal.AnimalsTable.FindAsync(id);
                if (existingEntity == null)
                {
                    return NotFound("Animal not found");
                }

                

                if (entity!=null)
                {
                    existingEntity.Name = entity.Name;
                    existingEntity.Color = entity.Color;
                }

                _animal.AnimalsTable.Update(existingEntity);
                await _animal.SaveChangesAsync();

                return Ok("Data Updated Successfully");
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
