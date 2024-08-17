using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Offense_Detector.Api.Data;
using Offense_Detector.Source;

namespace Offense_Detector.Api.Controller
{
    [ApiController]
    [Route(template:"api")]
    [Tags(tags:"Respect Filter")]
    public class ControllerDetector : ControllerBase
    {
        /// <summary>
        /// Checks the provided text for offensive words based on a list of offenses.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="text">The text to be checked for offensive content.</param>
        /// <returns>An IActionResult containing a list of detected offensive words.</returns>
        [HttpGet]
        [Route(template:"check")]
        public async Task<IActionResult> CheckText([FromServices] AppDbContext context, [FromQuery] string text)
        {
            var dataOffense = await context._offenses.ToListAsync();

            string[] parts = text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> detected = new List<string>();

            text = Library.ClearSentence(context._falsePositives.ToList(), text);

            var tasks = parts.Select(async part =>
            {
                string word = await Task.Run(async () => await RespectFilter.DetectWordAsync(part, dataOffense));

                if (!string.IsNullOrEmpty(word))
                {
                    detected.Add(part);
                }
            });

            await Task.WhenAll(tasks);


            return Ok( new { Text = text, Detected = detected });
        }
    }
}