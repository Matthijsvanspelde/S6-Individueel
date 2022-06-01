using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetStore.Http.Utilities
{
    internal class Extensions
    {
        public static T ContentAsType<T>(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ?
                            default(T) :
                            JsonConvert.DeserializeObject<T>(data);
        }

        public static dynamic ContentAsDynamic(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return JObject.Parse(data);
        }

        public static string ContentAsString(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
