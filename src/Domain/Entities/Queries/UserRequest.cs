using BibliotecasBase.Utils.Common;
using BibliotecasBase.Utils.Commun.Exceptions;
using Domain.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Domain.Entities.Queries
{
    public class UserRequest : UtilityBaseRequest
    {

        [JsonProperty("DNI")]
        public string DNI { get; set; } = string.Empty;

        [JsonProperty("FirstName")]
        public string FirstName {  get; set; }= string.Empty;

        [JsonProperty("LastName")]
        public string LastName { get; set; }=string.Empty;

        [JsonProperty("Country")]
        public string Country { get; set; } = string.Empty;

        [JsonProperty("Phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonProperty("Email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("Password")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty("CodeValidation")]
        public string CodeValidation { get; set; } = string.Empty;



        public override void IsValid()
        {
            if (string.IsNullOrEmpty(DNI) && DNI.Length<=13)
            {
                throw new RequestException(MessageError.CodeMsg100, MessageError.MSG_100);
            }

            if (string.IsNullOrEmpty(FirstName) && FirstName.Length <= 64)
            {
                throw new RequestException(MessageError.CodeMsg100, MessageError.MSG_100);
            }

            if (string.IsNullOrEmpty(LastName) && LastName.Length <= 64)
            {
                throw new RequestException(MessageError.CodeMsg100, MessageError.MSG_100);
            }

            if (string.IsNullOrEmpty(Country) && Country.Length <= 32)
            {
                throw new RequestException(MessageError.CodeMsg100, MessageError.MSG_100);
            }

            if (string.IsNullOrEmpty(Phone) && Phone.Length <= 16)
            {
                throw new RequestException(MessageError.CodeMsg100, MessageError.MSG_100);
            }

            if (string.IsNullOrEmpty(Email) && Email.Length <= 64)
            {
                throw new RequestException(MessageError.CodeMsg100, MessageError.MSG_100);
            }

            if (string.IsNullOrEmpty(Password) && Password.Length <= 16)
            {
                throw new RequestException(MessageError.CodeMsg100, MessageError.MSG_100);
            }

            if (string.IsNullOrEmpty(CodeValidation) && CodeValidation.Length <= 8)
            {
                throw new RequestException(MessageError.CodeMsg100, MessageError.MSG_100);
            }

            base.IsValid();
        }
    }
}
