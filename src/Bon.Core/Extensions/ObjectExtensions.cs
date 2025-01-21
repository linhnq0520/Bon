using System.Text.Json;
using System.Text.Json.Nodes;

namespace Bon.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static JsonObject ToJsonObject(this object obj)
        {
            if (obj == null)
                return null;

            try
            {
                if (obj is string jsonString)
                {
                    return JsonNode.Parse(jsonString)?.AsObject();
                }

                var serializedJson = JsonSerializer.Serialize(obj);

                return JsonNode.Parse(serializedJson)?.AsObject();
            }
            catch
            {
                return null;
            }
        }

        public static JsonArray ToJsonArray(this object obj)
        {
            if (obj == null)
                return null;

            try
            {
                if (obj is string jsonString)
                {
                    return JsonNode.Parse(jsonString)?.AsArray();
                }

                var serializedJson = JsonSerializer.Serialize(obj);

                return JsonNode.Parse(serializedJson)?.AsArray();
            }
            catch
            {
                return null;
            }
        }
    }
}
