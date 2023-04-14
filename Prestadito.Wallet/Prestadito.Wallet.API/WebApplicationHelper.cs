﻿using Microsoft.OpenApi.Models;
using Prestadito.Wallet.API.Endpoints;
using Prestadito.Wallet.Application.Manager.Extensions;
using Prestadito.Wallet.Infrastructure.Data.Extensions;
using Prestadito.Wallet.Infrastructure.Proxies.Settings.Extensions;

namespace Prestadito.Wallet.API
{
    public static class WebApplicationHelper
    {
        public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();

            var configuration = provider.GetRequiredService<IConfiguration>();

            builder.Services.AddDBServices(configuration);
            builder.Services.AddProxies();
            builder.Services.AddWalletControllers();
            builder.Services.AddValidators();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Test Deploy with main branch",
                    Description = "ASP.NET Core Web API Control Schedule System",
                    TermsOfService = new Uri("https://prestadito.pe/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Prestadito.pe",
                        Email = "contacto@prestadito.pe",
                        Url = new Uri("https://prestadito.pe"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://prestadito.pe"),
                    }
                });
            });

            return builder.Build();
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1/swagger.json", "Prestadito.Micro.Wallet.API");
            });
            //}

            app.UseWalletEndpoints();

            return app;
        }
    }
}
