using Newtonsoft.Json;

namespace TB.Common;

public static class JsonConverterHelper
{
    public static string Serialize(this HttpResponseMessage message)
    {
        return JsonConvert.SerializeObject(message, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
    }
}
