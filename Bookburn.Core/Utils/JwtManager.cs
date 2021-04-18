using System.Collections.Generic;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;

namespace Bookburn.Core.Utils
{
    public class JwtManager
    {
        private readonly JwtBuilder _builder;
        private const string Secret = "07a4a7d0b3fe1ed1106854f4f7a70bcc";

        public JwtManager(IJwtAlgorithm algorithm = null, IJsonSerializer serializer = null,
            IBase64UrlEncoder urlEncoder = null, string secret = null)
        {
            _builder = new JwtBuilder().WithAlgorithm(algorithm ?? new HMACSHA256Algorithm())
                .WithSerializer(serializer ?? new JsonNetSerializer())
                .WithUrlEncoder(urlEncoder ?? new JwtBase64UrlEncoder())
                .WithSecret(secret ?? Secret);
        }

        public string Encode(object payload)
        {
            return _builder.AddClaim("payload", payload).Encode();
        }
        
        public IDictionary<string, string> Decode(string token)
        {
            IDictionary<string, string> payload;
            _builder.MustVerifySignature().Decode<IDictionary<string, IDictionary<string, string>>>(token)
                .TryGetValue("payload", out payload);

            return payload;
        }
    }
}