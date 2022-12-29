using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB.Database.Entities;

namespace TB.Database.Initing;

public class KeyTranslationsInitEntity
{
    public string Key { set; get; }

	public List<TranslateInitEntity> Translates { set; get; }

	public KeyTranslationsInitEntity(string key)
	{
		Key = key;
		Translates = new List<TranslateInitEntity>();
	}

	public KeyTranslationsInitEntity AddTranslate(LanguageENUM languageENUM, string translate)
	{
		var ent = new TranslateInitEntity(languageENUM, translate);
		Translates.Add(ent);
		return this;
    }
}

public class TranslateInitEntity
{
	public LanguageENUM LanguageENUM { set; get; }

	public string Translate { set; get; }

	public TranslateInitEntity(LanguageENUM languageENUM, string translate)
	{
		LanguageENUM = languageENUM;
		Translate = translate;
	}
}
