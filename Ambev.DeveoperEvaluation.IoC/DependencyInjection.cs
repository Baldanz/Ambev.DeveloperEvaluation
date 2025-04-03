using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Security.Interface;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.UoW;
using Ambev.DeveloperEvaluation.UoW.Interface;
using Ambev.DeveoperEvaluation.IoC.ModuleResolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveoperEvaluation.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterDI(this WebApplicationBuilder builder)
        {
            new RepositoryModule().Initialize(builder);


            builder.Services.AddTransient<SalesValidator>();
            builder.Services.AddTransient<IUoW, UoW>();
            builder.Services.AddSingleton<IPasswordEncryption, PasswordEncryption>();

            builder.Services.AddControllers();
            builder.Services.AddHealthChecks();
        }
    }
}
