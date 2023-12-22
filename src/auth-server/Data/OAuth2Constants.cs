namespace SimpleAuthServer.Data
{
    public static class OAuth2ResponseType
    {
        public const string Code = "code";
    }

    public static class OAuth2GrantType 
    {
        public const string AuthorizationGrantType = "authorization_code";
    }

    public static class ClientAuthenticationType
    {
        public const string ClientSecretBasic = "client_secret_basic";  
        public const string ClientSecretPost = "client_secret_post";
    }
}