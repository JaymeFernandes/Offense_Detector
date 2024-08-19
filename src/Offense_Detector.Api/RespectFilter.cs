using SimMetrics.Net.Metric;
using Offense_Detector.Data.Models.Entity;
using System.Collections.Concurrent;

namespace Offense_Detector.Source;

public static class RespectFilter
{
    public static double Sensitivity { private get; set; } = 0.93;
    private static JaroWinkler _JaroWinkler { get; set; } = new JaroWinkler();
    private static Levenstein _Levenstein { get; set; } = new Levenstein();


    public static string DetectWordAsync(string part, List<Offense> data)
    {
        string temp = part.NormalizeText();
        string result = "";

        var isMatch = data.Any(word => _Levenstein.GetSimilarity(word.Word, part) > 0.7 || 
                            _Levenstein.GetSimilarity(word.Word, temp) > 0.7);

        if (isMatch)
        {
            foreach (var offense in data)
            {
                var similarity1 = _JaroWinkler.GetSimilarity(temp, offense.Word);
                var similarity2 = _JaroWinkler.GetSimilarity(part, offense.Word);


                if (similarity1 > Sensitivity || similarity2 > Sensitivity)
                {
                    result = offense.Word ?? "";
                    break;
                }
            }
        }

        return result;
    }

}
