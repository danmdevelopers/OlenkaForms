namespace Domain.Utils
{
    public struct MessageError
    {
        // Code Error
        public const string CodeMsg100 = "ERROR-MSG-100";

        // Messague Error
        public const string MSG_100 = "The ID must not be empty and must be 13 characters long";
    }


    public struct HttpConsult
    {
        public const string Post = "post";
        public const string Get = "get";
        public const string Method = "Method";
        public const string Auth = "Authorization";
        public const string Resource = "ResourceUri";
    }

    public struct RequestTransacction
    {
        public const string AnAuthorization = "401";
    }

    public struct Code
    {
        public const string HttpOk = "200";
        public const string httpFail = "401";
        public const string httpMessage = "Usuario no autorizado";
    }

}
