using Business.Abstract;
using Business.Concrete;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //AOP --- B�R METODUN �N�NDE, SONUNDA HATA VERD���NDE �ALI�AN KOD PAR�ACIKLARI AOP �LE YAZILIR
        public void ConfigureServices(IServiceCollection services)
        {
            //Autofac ,  Ninject , CastleWindsor , DryInject  ---- IoC Container kullan�r  
            services.AddControllers();
            // services.AddSingleton<IProductService,ProductManager>();     //bana arka planda bir referans olu�tur birisi senden �productservice isterse ona bi tane productmanager ou�tur onu ona ver i�inde data tutmuyosak kullan�yoruz kar���kl�k olur yoksa
            // services.AddSingleton<IProductDal, EfProductDal>();         //bu iki sat�r� bekletip autofac muhabbetini yapt�m
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();  // farkl� projelerde de kullanabilece�im bir injection  
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();    //githubla geldi bunlar

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            services.AddDependencyResolvers(new ICoreModule[]{
                new CoreModule() 
            });                 //coremodule gibi farkl� moduller olu�turursak onlar�da virg�l diyip buraya ekleyebiliriz
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
