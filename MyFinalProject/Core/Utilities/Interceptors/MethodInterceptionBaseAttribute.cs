using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors             //hazır kodları aldık githubdan burası o kısım    buralar tüm metodlarımız çatısı çok önemli bu konu yani !!!!!!!!!1
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }     //priority öncelik

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
