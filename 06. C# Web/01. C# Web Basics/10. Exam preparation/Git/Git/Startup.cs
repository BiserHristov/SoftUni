using Git.Data.Models;
using Git.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System;
using System.Threading.Tasks;

namespace Git
{
    public class Startup
    {
        public static async Task Main()
       => await HttpServer
            .WithRoutes(routes => routes
                .MapStaticFiles()
                .MapControllers())
            .WithServices(services => services
                .Add<IViewEngine, CompilationViewEngine>() 
               // .Add<IViewEngine, ParserViewEngine>() //if its ParserViewEngine it prints if-else statement
                .Add<GitDbContext>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IValidator, Validator>())
            .WithConfiguration<GitDbContext>(context => context
                .Database.Migrate())
            .Start();
    }
}
