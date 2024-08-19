using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Offense_Detector.Api.Data;

namespace Offense_Detector.Api.Controller
{
    [ApiController]
    [Tags("Works")]
    [Route("api/works")]
    public class WorksController : ControllerBase
    {
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