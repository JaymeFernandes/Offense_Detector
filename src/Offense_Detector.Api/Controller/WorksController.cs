using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Offense_Detector.Api.Data;

namespace Offense_Detector.Api.Controller
{
    /// <summary>
    /// API Controller for managing works.
    /// Provides endpoints to retrieve, delete, and manage works in the database.
    /// </summary>
    [ApiController]
    [Tags("Works")]
    [Route("api/works")]
    public class WorksController : ControllerBase
    {
        /// <summary>
        /// Retrieves a list of all works from the database.
        /// </summary>
        /// <param name="context">Database context to access works.</param>
        /// <returns>A list of works if any exist, otherwise a 404 Not Found status.</returns>
        [HttpGet]
        [Route(template:"all")]
        public async Task<IActionResult> GetAllWorks([FromServices] AppDbContext context)
        {
            var works = await context._works.AsNoTracking().ToListAsync();

            if(works.Count() > 0){
                return Ok(works);
            }
            else{
                return NotFound();
            }
        }

        /// <summary>
        /// Retrieves a specific work by its ID.
        /// </summary>
        /// <param name="context">Database context to access works.</param>
        /// <param name="id">The ID of the work to retrieve.</param>
        /// <returns>The requested work if found, otherwise a 404 Not Found status.</returns>
        [HttpGet]
        [Route(template:"{id}")]
        public async Task<IActionResult> GetWorks([FromServices] AppDbContext context, [FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var work = await context._works.FirstOrDefaultAsync(x => x.Id == id);

            if(work == null) 
                return NotFound();
            else
                return Ok(work);
        }

        /// <summary>
        /// Clears all works from the database.
        /// </summary>
        /// <param name="context">Database context to access works.</param>
        /// <returns>A status indicating the operation was successful.</returns>
        [HttpDelete]
        [Route(template:"clear")]
        public async Task<IActionResult> ClearWorks([FromServices] AppDbContext context)
        {
            var works = context._works.ToArray();

            context._works.RemoveRange(works);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
