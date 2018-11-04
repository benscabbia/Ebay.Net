using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public static class Serialize
    {
        public static string ToJson(this ItemGroupModel self) => JsonConvert.SerializeObject(self, BrowseAPIs.Models.Converter.Settings);
        public static string ToJson(this ItemModel self) => JsonConvert.SerializeObject(self, BrowseAPIs.Models.Converter.Settings);

    }
}
