namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SharedTrip.Data;
    using SharedTrip.Services;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        => await HttpServer
            .WithRoutes(routes => routes
                .MapStaticFiles()
                .MapControllers())
            .WithServices(services => services
                .Add<SharedTripDbContext>()
                .Add<IValidator, Validator>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IViewEngine, CompilationViewEngine>())
            .WithConfiguration<SharedTripDbContext>(context => context
                .Database.Migrate())
            .Start();
    }
}
