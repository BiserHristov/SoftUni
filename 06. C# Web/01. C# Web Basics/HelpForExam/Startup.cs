using ChangeMe.Data;
using ChangeMe.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System.Threading.Tasks;

namespace ChangeMe
{
    public class Startup
    {

        public static async Task Main()
        => await HttpServer
            .WithRoutes(routes => routes
                .MapStaticFiles()
                .MapControllers())
            .WithServices(services => services
                .Add<ChangeMeDbContext>()
                .Add<IValidator, Validator>()
                .Add<IPasswordHasher, PasswordHasher>()
                //.Add<IUserService, UserService>()
                .Add<IViewEngine, CompilationViewEngine>())
            .WithConfiguration<ChangeMeDbContext>(context => context
                .Database.Migrate())
            .Start();
    }
}
