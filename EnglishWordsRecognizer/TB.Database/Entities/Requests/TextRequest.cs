using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table("TextRequests", Schema = "payable_requests")]
public class TextRequest : BasePayableRequest
{
    [Column(TypeName = "jsonb")]
    public string[] Texts { set; get; }

    public int TotalChars { set; get; }

    [Column(TypeName = "jsonb")]
    public string[]? LanguageCodes { set; get; }

    public ApiTypeENUM ApiType { set; get; }

    public TextRequestTypeENUM TextRequestType { set; get; }

    [Column(TypeName = "jsonb")]
    public string Response { set; get; }

    public TextRequest():base(DateTimeOffset.UtcNow)
    {

    }

    public TextRequest InitTranslateTexts(string[] texts, string[] languageCodes, ApiTypeENUM apiType)
    {
        Texts = texts;
        TotalChars = texts.Sum(x => x.Length);
        LanguageCodes = languageCodes;
        ApiType = apiType;
        TextRequestType = TextRequestTypeENUM.Translate;

        return this;
    }

    public TextRequest InitDetectLanguages(string[] texts, ApiTypeENUM apiType)
    {
        Texts = texts;
        TotalChars = texts.Sum(x => x.Length);
        ApiType = apiType;
        TextRequestType = TextRequestTypeENUM.DetectLanguge;

        return this;
    }

    public TextRequest InitResponse(string response)
    {
        Response = response;

        return this;
    }
}
