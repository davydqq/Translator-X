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

    public TextRequestTypeENUM TextRequestType { set; get; }

    [Column(TypeName = "jsonb")]
    public string Response { set; get; }

    public TextRequest(ApiTypeENUM apiType, string[] texts, double cost) : base(DateTimeOffset.UtcNow, apiType)
    {
        Texts = texts;
        TotalChars = texts.Sum(x => x.Length);
        RequestCost = TotalChars * cost;
    }

    public TextRequest InitTranslateTexts(string[] languageCodes)
    {
        LanguageCodes = languageCodes;
        TextRequestType = TextRequestTypeENUM.Translate;

        return this;
    }

    public TextRequest InitDetectLanguages()
    {
        TextRequestType = TextRequestTypeENUM.DetectLanguage;
        return this;
    }

    public TextRequest InitResponse(string response)
    {
        Response = response;

        return this;
    }
}
