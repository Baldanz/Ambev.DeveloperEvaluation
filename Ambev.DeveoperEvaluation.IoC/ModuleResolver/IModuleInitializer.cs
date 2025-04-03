using Microsoft.AspNetCore.Builder;

namespace Ambev.DeveoperEvaluation.IoC.ModuleResolver;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
