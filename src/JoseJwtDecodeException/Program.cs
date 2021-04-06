using System;
using Jose;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace JoseJwtDecodeException
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = "xB7EFoU1ExrPRkurvoVNN1L1MXI1nwtvtP54p1pNLdI=";
            var secretBytes = WebEncoders.Base64UrlDecode(secret);
            var payload = new SamplePayloadModel
            {
                jti = Guid.Parse("7eb8f0e3-1144-4ed2-b4d9-be266f68f212").ToString(),
                iss = "My Application",
                iat = 1617749964L, // Approximately 2021-04-06 15:59 Pacific Daylight Time
                aud = "https://example.com",
                sub = "testperson@example.com",
            };

            // Encode the payload.
            var jwt = JWT.Encode(payload, secretBytes, JwsAlgorithm.HS256);
            Console.WriteLine($"jwt: {jwt}");

            // Decode the payload, and serialize it as JSON for display.
            try
            {
                var decodedPayload = JWT.Decode<SamplePayloadModel>(jwt, secretBytes, JwsAlgorithm.HS256);
                var decodedPayloadJson = JsonConvert.SerializeObject(decodedPayload, Formatting.Indented);
                Console.WriteLine("decoded jwt payload:");
                Console.WriteLine(decodedPayloadJson);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("*** Failed to decode JWT ***");
                Console.Error.WriteLine(ex);
            }
        }
    }

    public class SamplePayloadModel
    {
        /// <summary>
        /// JWT ID
        /// </summary>
        public string jti { get; set; }

        /// <summary>
        /// Issuer.
        /// </summary>
        public string iss { get; set; }

        /// <summary>
        /// Issued At. When the JWT was issued.
        /// </summary>
        public long iat { get; set; }

        /// <summary>
        /// Audience. Must match the request authority (e.g., https://example.com).
        /// </summary>
        public string aud { get; set; }

        /// <summary>
        /// Subject.
        /// </summary>
        public string sub { get; set; }
    }
}
