using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dotnet6WebAPICrud.Data;
using Dotnet6WebAPICrud.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet6WebAPICrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CakeController : ControllerBase
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public CakeController(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var cakes = await _myWorldDbContext.Cake.ToListAsync();
            return Ok(cakes);
        }

        [HttpGet]
        [Route("get-cake-by-id")]
        public async Task<IActionResult> GetCakeByIdAsync(int id)
        {
            var cake = await _myWorldDbContext.Cake.FindAsync(id);
            return Ok(cake);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Cake cake)
        {
            _myWorldDbContext.Cake.Add(cake);
            await _myWorldDbContext.SaveChangesAsync();
            return Created($"/get-cake-by-id?id={cake.Id}", cake);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Cake cakeToUpdate)
        {
            _myWorldDbContext.Cake.Update(cakeToUpdate);
            await _myWorldDbContext.SaveChangesAsync();
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var cakeToDelete = await _myWorldDbContext.Cake.FindAsync(id);
            if(cakeToDelete == null)
            {
                return NotFound();
            }

            _myWorldDbContext.Cake.Remove(cakeToDelete);
            await _myWorldDbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}