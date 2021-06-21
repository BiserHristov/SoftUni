using CarShop.Data;
using CarShop.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System;
using System.Threading.Tasks;

namespace CarShop.App
{
    public static class Program
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    //.Add<IValidator, Validator>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    //.Add<IUserService, UserService>()
                    .Add<CarShopDbContext>())
                .WithConfiguration<CarShopDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
