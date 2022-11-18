using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers                  //benim dependencyresolverımdan genel olanları tüm projelerde kullanabilceğim injectionları buraya koyacağız 
{
    public class CoreModule : ICoreModule  
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();                 //memorycachemanagerin karşılığı oldu
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();    //ampulle instal paket yükledik 2.2.2
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();     //birisi senden ıcachemanager isterse ona micrsoftun memeorycachemanagerini ver
        }
    }
}
