using BibliotecasBase.Utils.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Domain.Entities.Responses
{
    public class EmailResponse : UtilityBaseResponse
    {
        [JsonProperty("Host")]
        public string Host { get; set; } = string.Empty;

        [JsonProperty("User")]
        public string User { get; set; }= string.Empty;
        [JsonProperty("Body")]
        public string Body { get; set; } = string.Empty;

        [JsonProperty("Password")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty("Port")]
        public int Port {  get; set; } = 0;


        public EmailResponse(string code, string message)
            : base(false, code, message) { }
    }
}
