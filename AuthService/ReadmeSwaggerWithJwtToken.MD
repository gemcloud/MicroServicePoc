## Add JWT Bearer Authorization to Swagger and ASP.NET Core

### install Nuget libraries

#### Setup Swagger UI in ASP.NET Core:
    Swashbuckle.AspNetCore" Version="5.6.3"
    Swashbuckle.AspNetCore.SwaggerGen" Version="5.6.3"
    Swashbuckle.AspNetCore.SwaggerUI" Version="5.6.3"
#### Setup JWT token.
    Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.1.11"
    System.IdentityModel.Tokens.Jwt" Version="5.5.0"
    Microsoft.AspNetCore.Authentication.JwtBearer" Version="3.1.11"


### Config Swagger on startup.cs. add Extension files "SwaggerServiceExtensions"

### Config "Secret" on appsettings.json

### Change "launchSettings.json" file to launch Swagger.
    "launchUrl": "swagger",
### Add logic

### Run project to put "Bearer + {Token}" on authorizations Value.
Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsInVuaXF1ZV9uYW1lIjoiYWRtaW4iLCJyb2xlIjpbIlNBTEVTTUFOIiwiVVNFUiJdLCJhdmF0YXIiOiJzdGF0aWMvYXZhdGFycy9hZG1pbi5wbmciLCJ1c2VyVHlwZSI6IlNBTEVTTUFOIiwibmJmIjoxNjExNzI2NTU0LCJleHAiOjE2MTIzMzEzNTQsImlhdCI6MTYxMTcyNjU1NH0.V8ftBmLkMPvRtq4XzEf5PDfxfQRJjNIWr_piIvTM-4Y

### How to test?
    1. Launch project, Swagger UI show.
    2. Account "Post /api/Account" ==> login == admin , password == admin to Execute;
    3. Get the token string;
    4. To click "Authorize" and add "Bearer " + token string;
    5. To try Authentication to use  "Get /api/Account".
    6. Should work.
