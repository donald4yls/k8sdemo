using Furion;
using Furion_IdentityServer.Web.Core.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furion_IdentityServer.Web.Core
{
    [AppStartup(2)]
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                        .AddInjectWithUnifyResult(
                            swaggerGenConfigure: options =>
                            {
                                // 移除Furion中自带的认证方式
                                options.SwaggerGeneratorOptions.SecuritySchemes.Clear();

                                // 配置 Swagger Gen
                                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                                {
                                    Type = SecuritySchemeType.OAuth2,
                                    Flows = new OpenApiOAuthFlows
                                    {
                                        AuthorizationCode = new OpenApiOAuthFlow
                                        {
                                            AuthorizationUrl = new Uri($"{App.Configuration["SwaggerConfiguration:IdentityServerBaseUrl"]}/connect/authorize"),
                                            TokenUrl = new Uri($"{App.Configuration["SwaggerConfiguration:IdentityServerBaseUrl"]}/connect/token"),
                                            Scopes = new Dictionary<string, string> {
                                                { App.Configuration["SwaggerConfiguration:OidcApiName"], App.Configuration["SwaggerConfiguration:ApiName"] }
                                            }
                                        }
                                    }
                                });
                                options.OperationFilter<AuthorizeCheckOperationFilter>();
                            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // 必须在 UseStaticFiles 和 UseRouting 之间
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseInject(
                swaggerUIConfigure: c =>
                {
                    // 配置 Swagger UI
                    c.OAuthClientId(App.Configuration["SwaggerConfiguration:OidcSwaggerUIClientId"]);
                    c.OAuthClientSecret(App.Configuration["SwaggerConfiguration:OidcSwaggerUIClientSecret"]);
                    c.OAuthAppName(App.Configuration["SwaggerConfiguration:ApiName"]);
                    c.OAuthUsePkce();
                });

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}