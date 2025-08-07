using Newtonsoft.Json;
using System.Collections.Generic;

namespace DVRFault
{
    class RespondModel
    {
        public int result { get; set; }
        public Dictionary<string, string>[] list { get; set; }


        public static RespondModel GetResult(string Json)
            => JsonConvert.DeserializeObject<RespondModel>(Json);

    }
}
