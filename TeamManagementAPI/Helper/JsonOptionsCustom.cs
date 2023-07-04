using System.Text.Json.Serialization;
using System.Text.Json;

namespace TeamManagementAPI.Helper
{
    public class JsonOptionsCustom
    {

        public JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
    }
}
