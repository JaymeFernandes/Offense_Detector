using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Offense_Detector.Api.Data;
using Offense_Detector.Data.Models.Entity;

namespace Offense_Detector.Api.Controller
{
    /// <summary>
    /// API Controller for managing offenses.
    /// </summary>
    [Tags(tags:"Offense manager")]
    [ApiController]
    [Route("api/offense")]
    public class ControllerOffense : ControllerBase
    {
        /// <summary>
        /// Retrieves all offenses.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <returns>A list of all offenses, or a bad request if none are found.</returns>
        [HttpGet]
        [Route(template:"all")]
        public IActionResult GetAllOffense([FromServices] AppDbContext context)
        {
            var offenses = context._offenses.AsNoTracking().ToList();

            if(offenses.Count > 0) 
                return Ok(offenses);
            else 
                return NotFound();
        }

        /// <summary>
        /// Retrieves a specific offense by its ID.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="id">The ID of the offense to retrieve.</param>
        /// <returns>The offense if found, or a bad request if not found or invalid.</returns>
        [HttpGet]
        [Route(template:"{id}")]
        public async Task<IActionResult> GetOffense([FromServices]AppDbContext context, [FromRoute]int id)
        {
            var offense = await context._offenses.FirstOrDefaultAsync(x => x.Id == id);

            if(!ModelState.IsValid) 
                return BadRequest();

            if(offense == null) 
                return BadRequest($"{id} not exist");

            else 
                return Ok(offense);
        }

        /// <summary>
        /// Adds a new offense to the database.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="offense">The offense entity to add.</param>
        /// <returns>The created offense, or a bad request if an error occurs.</returns>
        [HttpPost]
        [Route(template:"add")]
        public async Task<IActionResult> AddOffense([FromServices] AppDbContext context, [FromBody] Offense offense)
        {
            try
            {
                if(!string.IsNullOrEmpty(offense.Word))
                    offense.Word = offense.Word.ToLower();
                else 
                    throw new ArgumentNullException(nameof(offense.Word));

                var work = await context._works.FirstOrDefaultAsync(x => x.Word == offense.Word);

                if(work != null) context._works.Remove(work);

                offense.Word = offense.Word?.ToLower() ?? throw new ArgumentException("OffenseValues is not defined");

                await context._offenses.AddAsync(offense);

                await context.SaveChangesAsync();

                return Created($"Get/{offense.Id}", offense);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing offense.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="id">The ID of the offense to update.</param>
        /// <param name="offense">The updated offense data.</param>
        /// <returns>A success response if updated, or a bad request if an error occurs.</returns>
        [HttpPut]
        [Route(template:"{id}")]
        public async Task<IActionResult> UpdateOffense([FromServices] AppDbContext context, [FromRoute] int id, [FromBody] Offense offense)
        {
            if(!ModelState.IsValid) 
                return BadRequest();

            var valueOffense = await context._offenses.FirstOrDefaultAsync(x => x.Id == id);

            if(valueOffense == null) 
                return NotFound(id);

            try
            {
                if(string.IsNullOrEmpty(offense.Word)) 
                    throw new ArgumentNullException(nameof(offense.Word));

                valueOffense.Word = offense.Word.ToLower();

                var work = await context._works.FirstOrDefaultAsync(x => x.Word == offense.Word);
                if(work != null) context._works.Remove(work);

                context._offenses.Update(valueOffense);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an offense by its ID.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="id">The ID of the offense to delete.</param>
        /// <returns>A success response if deleted, or a bad request if an error occurs.</returns>
        [HttpDelete]
        [Route(template:"{id}")]
        public async Task<IActionResult> DeleteOffense([FromServices] AppDbContext context, [FromRoute] int id)
        {
            try
            {
                var offense = await context._offenses.FirstOrDefaultAsync(x => id == x.Id);

                if(offense == null) 
                    return NotFound();

                context._offenses.Remove(offense);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
