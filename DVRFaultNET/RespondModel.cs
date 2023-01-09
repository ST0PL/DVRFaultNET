using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace DVRFault
{
    class RespondModel
    {
        public int result { get; set; }
        public Dictionary<string, string>[] list { get; set; }


        public static RespondModel GetResult(string Json)
        {
            return JsonConvert.DeserializeObject<RespondModel>(Json);
        }

    }
}
