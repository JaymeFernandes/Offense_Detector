using System;
using Offense_Detector.Data.Models.Entity;

namespace Offense_Detector.Source;

public static class Library
{
    private readonly static Dictionary<char, char> _symbols = new Dictionary<char, char>()
		{
			{ '4', 'a' },
			{ '@', 'a' },
			{ '8', 'b' },
			{ '(', 'c' },
			{ '3', 'e' },
			{ '€', 'e' },
			{ '9', 'g' },
			{ '6', 'g' },
			{ '#', 'h' },
			{ '1', 'i' },
			{ '!', 'i' },
			{ '|', 'l' },
			{ 'Й', 'n' },
			{ '0', 'o' },
			{ '*', 'o' },
			{ '5', 's' },
			{ '$', 's' },
			{ '7', 't' },
			{ '+', 'T' },
			{ '2', 'z' },
			{ '%', 'z' }
		};

    public static string NormalizeText(this string text)
    {
        text = text.ToLower();
		foreach (var dic in _symbols)
		{
			if (text.EndsWith("!")) text = text.Substring(0, text.Length - 1);

			if (!int.TryParse(text, out int number))
			{
				text = text.Replace(dic.Key, dic.Value);
			}
		}

		return text;
    }

    public static string ClearSentence(List<FalsePositive> data, string text)
    {
        string result = text;
        
        foreach(var word in data)
        {
            result = text.Replace(word.Word, "");
        }

        return result;

    }
}
