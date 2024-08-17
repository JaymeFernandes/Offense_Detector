using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Offense_Detector.Domain.Models.Entity
{
    public class WordsManeger
    {
        public int Id { get; set; }

        public DateTime CreateData { get; set; }
        
        public int DocumentCount { get; set; } = 0;
    }
}