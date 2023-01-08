using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table("TextRequests", Schema = "requests")]
public class TextRequest : BaseRequest
{
    [Column(TypeName = "jsonb")]
    public string[] Texts { set; get; }

    public int TotalChars { set; get; }

    [Column(TypeName = "jsonb")]
    public string[]? LanguageCodes { set; get; }


    public TextRequestTypeENUM TextRequestTypeId { set; get; }
    public TextRequestType TextRequestType { set; get; }

    public TextRequest(): base(DateTimeOffset.UtcNow, null, 0)
    {

    }

    public TextRequest(ApiTypeENUM apiType, string[] texts, double cost, long userId) 
        : base(DateTimeOffset.UtcNow, apiType, userId)
    {
        Texts = texts;
        TotalChars = texts.Sum(x => x.Length);
        InitCost(TotalChars * cost);
    }

    public TextRequest InitTranslateTexts(string[] languageCodes)
    {
        LanguageCodes = languageCodes;
        TextRequestTypeId = TextRequestTypeENUM.Translate;

        return this;
    }

    public TextRequest InitDetectLanguages()
    {
        TextRequestTypeId = TextRequestTypeENUM.DetectLanguage;
        return this;
    }

    public TextRequest InitSynonyms()
    {
        TextRequestTypeId = TextRequestTypeENUM.Synonyms;
        return this;
    }

    public TextRequest InitMeaning()
    {
        TextRequestTypeId = TextRequestTypeENUM.Meaning;
        return this;
    }
}
