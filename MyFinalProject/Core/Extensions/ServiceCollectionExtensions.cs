using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {                                               //IServiceCollection bizim apimizin(asp.net) servis bağımlılıklarını eklediğimiz ya da araya girmesini istediğimiz servisleri eklediğimiz koleksiyonların kendisidir.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,ICoreModule[] modules)     //neyi genişletmek istiyosak thisle veririz
        {
            foreach (var module in modules)     //bizim core katmanı dahil ekleyeceğimiz bütün injectionları bir aarada toplayabileceğimiz bir yapıya dönüştü
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}