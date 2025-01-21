using System.Text.Json.Nodes;

namespace Bon.Core.Extensions
{
    public static class JsonNodeExtensions
    {
        public static bool IsNullOrEmpty(this JsonNode jsonNode)
        {
            return jsonNode == null
                || (jsonNode is JsonObject obj && obj.Count == 0)
                || (jsonNode is JsonArray array && array.Count == 0);
        }

        public static bool HasValue(this JsonNode jsonNode)
        {
            return !jsonNode.IsNullOrEmpty();
        }
    }
}
