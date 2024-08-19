using System;
using Offense_Detector.Data.Models.Entity;
using Offense_Detector.Domain.Models.Entity;

namespace Offense_Detector.Source;

public static class Library
{
	private static string[] Portuguese = new string[]
	{
		"a", "o", "e", "é", "de", "do", "da", "dos", "das", "em", "na", "no", "nos", "nas", "um",
		"uma", "uns", "umas", "por", "para", "com", "como", "se", "mas", "mais", "menos", "ou", "ao",
		"aos", "à", "às", "onde", "quando", "porque", "que", "qual", "cujos", "cuja", "isto", "isso",
		"aquilo", "mesmo", "mesma", "mesmos", "mesmas", "também", "ainda", "muito", "muita", "muitos",
		"muitas", "ele", "ela", "eles", "elas", "você", "nós", "vossos", "vosso", "vos", "teu", "tua",
		"teus", "tuas", "meu", "minha", "meus", "minhas", "seu", "sua", "suas", "nem", "seja", "sendo",
		"outra", "outro", "dentre", "porém", "porque", "se", "senão", "entre", "sobre", "desde", "antes",
		"?", ".", ","
	};


	private static string[] English = new string[]
	{
		"and", "but", "or", "so", "yet", "for", "nor", "although", "however", "nevertheless",
		"therefore", "meanwhile", "consequently", "moreover", "furthermore", "likewise", "thus",
		"in", "otherwise", "as", "the", "for", "to", "a", "an", "of", "at", "by", "with", "from",
		"on", "upon", "between", "among", "under", "over", "above", "below", "into", "through",
		"during", "after", "before", "without", "since", "until", "along", "around", "about"
	};


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
			{ '%', 'z' },
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

    public static string ClearSentence(List<FalsePositive> data, List<WordsManeger> words, string text)
    {
		var parts = text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        

		foreach(var word in words)
		{
			if(parts.Contains(word.Word ?? ""))
				parts.Remove(word.Word ?? "");
				
		}
        
        foreach(var word in data)
        {
			if(parts.Contains(word.Word ?? ""))
            	parts.Remove(word.Word ?? "");
        }

		string result = text;

		foreach(var word in Portuguese){
			if(parts.Contains(word))
				parts.Remove(word);
		}

		foreach(var word in English){
			if(parts.Contains(word))
				parts.Remove(word);
		}

        return string.Join(" ", parts);

    }
}
