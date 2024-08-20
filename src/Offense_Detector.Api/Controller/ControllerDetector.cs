using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Offense_Detector.Api.Data;
using Offense_Detector.Domain.Models.Entity;
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
            if (string.IsNullOrWhiteSpace(text)) return BadRequest("Text cannot be null or empty.");


            var dataOffense = await context._offenses.AsNoTracking().ToListAsync();
            var falsePositive = await context._falsePositives.AsNoTracking().ToListAsync();
            var wordsIgnore = await context._works.ToListAsync();

            string[] parts = Library.ClearSentence(falsePositive, wordsIgnore, text).ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var detected = new ConcurrentBag<string>();
            
            Parallel.ForEach(parts, part => {
                string word = RespectFilter.DetectWordAsync(part, dataOffense);

                if (!string.IsNullOrEmpty(word))
                {
                    detected.Add(part);
                }
            });

            foreach (string word in parts)
            {
                if (!detected.Contains(word))
                {
                    if ((await context._works.FirstOrDefaultAsync(x => x.Word == word)) == null) 
                    {
                        var wordObj = new WordsManeger() 
                        { 
                            Word = word, 
                            CreateData = DateTime.Now 
                        };
                        await context.AddAsync(wordObj);
                    }
                }
            }


            await context.SaveChangesAsync();

            return Ok( new { Text = text, Detected = detected.ToList() });
        }
    }
}