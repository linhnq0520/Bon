using System.Text.Json;

namespace Bon.Core.Json
{
    public partial class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            var snakeCase = MyRegex().Replace(name, "$1_$2").ToLower();

            return snakeCase;
        }

        [System.Text.RegularExpressions.GeneratedRegex(@"([a-z])([A-Z])")]
        private static partial System.Text.RegularExpressions.Regex MyRegex();
    }
}
