using System.Text.Json;
using System.Text.Json.Nodes;
using Bon.Core.Json;

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

        public static string ToSerialize(this object obj)
        {
            if (obj == null)
                return null;

            return JsonSerializer.Serialize(obj);
        }

        public static T ToObject<T>(this object obj)
            where T : class
        {
            if (obj == null)
                return null;

            if (obj is string jsonString)
            {
                return JsonSerializer.Deserialize<T>(jsonString);
            }

            string json = obj.ToSerialize();
            return JsonSerializer.Deserialize<T>(json);
        }

        public static bool TryParse<T>(this object obj, out T result)
            where T : class
        {
            result = null;

            if (obj == null)
                return false;

            try
            {
                if (obj is string jsonString)
                {
                    result = JsonSerializer.Deserialize<T>(jsonString);
                }
                else
                {
                    string json = obj.ToSerialize();
                    result = JsonSerializer.Deserialize<T>(json);
                }

                return result != null;
            }
            catch
            {
                return false;
            }
        }

        public static string ToSerializeSnakeCase(this object obj)
        {
            if (obj == null)
                return string.Empty;

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
            };

            return JsonSerializer.Serialize(obj, options);
        }
    }
}
