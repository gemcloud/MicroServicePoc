using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Infrastructure
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth POC API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    // input Bearer tokenstring : e.g. 
                    // Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsInVuaXF1ZV9uYW1lIjoiYWRtaW4iLCJyb2xlIjpbIlNBTEVTTUFOIiwiVVNFUiJdLCJhdmF0YXIiOiJzdGF0aWMvYXZhdGFycy9hZG1pbi5wbmciLCJ1c2VyVHlwZSI6IlNBTEVTTUFOIiwibmJmIjoxNjExNzI2NTU0LCJleHAiOjE2MTIzMzEzNTQsImlhdCI6MTYxMTcyNjU1NH0.V8ftBmLkMPvRtq4XzEf5PDfxfQRJjNIWr_piIvTM-4Y
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GemCloud POC API V1.0 ");
            });

            return app;
        }
    }
}
