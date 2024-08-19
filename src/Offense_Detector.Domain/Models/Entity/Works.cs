using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Offense_Detector.Data.Models.Entity;

namespace Offense_Detector.Domain.Models.Entity
{
    public class WordsManeger : EntityOffense
    {
        public DateTime CreateData { get; set; }
    }
}