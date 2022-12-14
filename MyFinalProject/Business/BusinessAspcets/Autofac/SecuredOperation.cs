using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspcets.Autofac
{
    //JWT için 
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;     //JWT her istek için bir http contexti oluşur herkese 1 tane tret 

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');                       //roles split metni bizim belirlediğim karaktere göre ayırıp arraye atıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))              //bu adamın bi claimi varsa onbefore u bitir hata verme
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);    //yetkin yok hatası ver
        }
    }
}
