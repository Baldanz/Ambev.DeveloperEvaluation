using Ambev.DeveloperEvaluation.ORM.Cart;
using Ambev.DeveloperEvaluation.ORM.Cart;
using Ambev.DeveloperEvaluation.ORM.CartRating;
using Ambev.DeveloperEvaluation.ORM.Product;
using Ambev.DeveloperEvaluation.ORM.Repository;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Ambev.DeveloperEvaluation.ORM.Repository.User;
using Ambev.DeveloperEvaluation.ORM.Sale;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveoperEvaluation.IoC.ModuleResolver
{
    public class RepositoryModule : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IRatingRepository, RatingRepository>();
            builder.Services.AddTransient<ICartRepository, CartRepository>();
            builder.Services.AddTransient<IProductsInCartRepository, ProductsInCartRepository>();
            builder.Services.AddTransient<ISalesRepository, SalesRepository>();
            builder.Services.AddTransient<IProductsInSalesRepository, ProductsInSalesRepository>();
        }
    }
}
