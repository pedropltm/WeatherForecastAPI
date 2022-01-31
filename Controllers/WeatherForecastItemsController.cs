#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastItemsController : ControllerBase
    {
        private readonly WeatherForecastContext _context;

        public WeatherForecastItemsController(WeatherForecastContext context)
        {
            _context = context;
        }

        // GET: api/WeatherForecastItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecastItemDTO>>> GetWeatherForecastItems()
        {
            return await _context.WeatherForecastItems.Select(x => ItemToDTO(x)).ToListAsync();
        }

        // GET: api/WeatherForecastItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecastItemDTO>> GetWeatherForecastItem(long id)
        {
            var weatherForecastItem = await _context.WeatherForecastItems.FindAsync(id);

            if (weatherForecastItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(weatherForecastItem);
        }

        // PUT: api/WeatherForecastItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecastItem(long id, WeatherForecastItemDTO weatherForecastItemDTO)
        {
            if (id != weatherForecastItemDTO.Id)
            {
                return BadRequest();
            }

            var weatherForecastItem = await _context.WeatherForecastItems.FindAsync(id);
            if (weatherForecastItem == null)
            {
                return NotFound();
            }

            weatherForecastItem.Name = weatherForecastItemDTO.Name;
            weatherForecastItem.IsComplete = weatherForecastItemDTO.IsComplete;

            _context.Entry(weatherForecastItemDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherForecastItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherForecastItemDTO>> PostWeatherForecastItem(WeatherForecastItemDTO weatherForecastItemDTO)
        {
            var weatherForecastItem = new WeatherForecastItem
            {
                IsComplete = weatherForecastItemDTO.IsComplete,
                Name = weatherForecastItemDTO.Name
            };

            _context.WeatherForecastItems.Add(weatherForecastItem);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetWeatherForecastItem), new { id = weatherForecastItem.Id }, ItemToDTO(weatherForecastItem));

        }

        // DELETE: api/WeatherForecastItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecastItem(long id)
        {
            var weatherForecastItem = await _context.WeatherForecastItems.FindAsync(id);
            if (weatherForecastItem == null)
            {
                return NotFound();
            }

            _context.WeatherForecastItems.Remove(weatherForecastItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherForecastItemExists(long id)
        {
            return _context.WeatherForecastItems.Any(e => e.Id == id);
        }

        private static WeatherForecastItemDTO ItemToDTO(WeatherForecastItem weatherForecastItem) => new WeatherForecastItemDTO
        {
            Id = weatherForecastItem.Id,
            Name = weatherForecastItem.Name,
            IsComplete = weatherForecastItem.IsComplete
        };
    }
}
