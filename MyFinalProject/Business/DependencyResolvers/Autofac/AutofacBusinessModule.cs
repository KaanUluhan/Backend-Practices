using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
  public class AutofacBusinessModule: Module   //sen bir autofac module sün dedik
        //AUTOOFAC ARKA PLANDA NEWLERİNİ OLUŞTURUYOR BELLKETE REFERANSLARINI OLUŞTURUYOR
    {
        protected override void Load(ContainerBuilder builder)    //override yazdık space basıp loada basstık aşağısı oluştu
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();                   //eğer birisi bizden ıProductservice isterse ona product manageri ver bi kere ınstance üretiyo onu herkese verebiliyor
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();                   //eğer birisi bizden ıCategoryservice isterse ona category manageri ver bi kere ınstance üretiyo onu herkese verebiliyor
            builder.RegisterType<EfProductDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();              //en son github ile eklediğimiz muhabbetler için
            builder.RegisterType<EfUserDal>().As<IUserDal>();                   //en son github ile eklediğimiz muhabbetler için

            builder.RegisterType<AuthManager>().As<IAuthService>();             //en son github ile eklediğimiz muhabbetler için
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();               //en son github ile eklediğimiz muhabbetler için

         


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

//autofac den vazgeçmek istersek dependeneyresolvera yeni yapıyı kurmak ve program cs ye gelip autofacli 2 yeri değiştirmek 