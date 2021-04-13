# jose-jwt `JWT.Decode<T>` Exception

> UPDATE: issue fixed in release [3.1.1](https://github.com/dvsekhvalnov/jose-jwt/releases/tag/v3.1.1). Thank you, @dvsekhvalnov!

---
When referencing the 3.1.0 version of [jose-jwt](https://github.com/dvsekhvalnov/jose-jwt/), calls to `JWT.Decode<T>` started throwing exceptions.

To reproduce the exception:

1. Check out the `main` branch of this repository
2. Open the solution in VS2019
3. Run the console app

You should see an exception like the following:

```
System.InvalidCastException: Unable to cast object of type 'System.Collections.Generic.Dictionary`2[System.String,System.Object]' to type 'JoseJwtDecodeException.SamplePayloadModel'.
   at Newtonsoft.Json.JsonConvert.DeserializeObject[T](String value, JsonConverter[] converters)
   at Jose.NewtonsoftMapper.Parse[T](String json)
   at Jose.JWT.Decode[T](String token, Object key, JwsAlgorithm alg, JwtSettings settings)
   at JoseJwtDecodeException.Program.Main(String[] args) in C:\Dev\SANDBOX\JoseJwtDecodeException\src\JoseJwtDecodeException\Program.cs:line 30
```

To reproduce the prior behavior using jose-jwt 3.0.0:

1. Check out the `v3.0.0` branch of this repository
2. Open the solution in VS2019
3. Run the console app

You should see output like the following:

```
jwt: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI3ZWI4ZjBlMy0xMTQ0LTRlZDItYjRkOS1iZTI2NmY2OGYyMTIiLCJpc3MiOiJNeSBBcHBsaWNhdGlvbiIsImlhdCI6MTYxNzc0OTk2NCwiYXVkIjoiaHR0cHM6Ly9leGFtcGxlLmNvbSIsInN1YiI6InRlc3RwZXJzb25AZXhhbXBsZS5jb20ifQ.VzCcSkcWL5TVbH5QQ1N9kXlClssCNHYed3_5oMTKeUk
decoded jwt payload:
{
  "jti": "7eb8f0e3-1144-4ed2-b4d9-be266f68f212",
  "iss": "My Application",
  "iat": 1617749964,
  "aud": "https://example.com",
  "sub": "testperson@example.com"
}
```