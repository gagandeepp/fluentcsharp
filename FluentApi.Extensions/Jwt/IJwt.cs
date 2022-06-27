using System;
namespace FluentApi.Extensions.Jwt
{
    public interface IJwt
    {
        // Context
        IJwt WithIssuer(string issuer);
        IJwt WithAudience(string audience);
        IJwt WithKey(string key);

        // Exit
        void Apply();
    }
}
