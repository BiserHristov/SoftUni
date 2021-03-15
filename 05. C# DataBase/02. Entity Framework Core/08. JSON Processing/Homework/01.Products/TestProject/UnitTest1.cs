//ReSharper disable InconsistentNaming, CheckNamespace

using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ProductShop;
using ProductShop.Data;

[TestFixture]
public class Test_000_001
{
    private IServiceProvider serviceProvider;

    private static readonly Assembly CurrentAssembly = typeof(StartUp).Assembly;

    [SetUp]
    public void Setup()
    {
        Mapper.Reset();
        Mapper.Initialize(cfg => cfg.AddProfile(GetType("ProductShopProfile")));

        this.serviceProvider = ConfigureServices<ProductShopContext>("ProductShop");
    }

    [Test]
    public void ImportCategoryProductsZeroTests()
    {
        var context = this.serviceProvider.GetService<ProductShopContext>();

        var inputJson =
            @"[{""CategoryId"":4,""ProductId"":1},{""CategoryId"":11,""ProductId"":2},{""CategoryId"":6,""ProductId"":3},{""CategoryId"":5,""ProductId"":4},{""CategoryId"":4,""ProductId"":5},{""CategoryId"":11,""ProductId"":6},{""CategoryId"":5,""ProductId"":7},{""CategoryId"":8,""ProductId"":8},{""CategoryId"":8,""ProductId"":9},{""CategoryId"":5,""ProductId"":10},{""CategoryId"":5,""ProductId"":11},{""CategoryId"":5,""ProductId"":12},{""CategoryId"":5,""ProductId"":13},{""CategoryId"":9,""ProductId"":14},{""CategoryId"":6,""ProductId"":15},{""CategoryId"":4,""ProductId"":16},{""CategoryId"":6,""ProductId"":17},{""CategoryId"":5,""ProductId"":18},{""CategoryId"":7,""ProductId"":19},{""CategoryId"":1,""ProductId"":20},{""CategoryId"":4,""ProductId"":21},{""CategoryId"":2,""ProductId"":22},{""CategoryId"":10,""ProductId"":23},{""CategoryId"":2,""ProductId"":24},{""CategoryId"":10,""ProductId"":25},{""CategoryId"":5,""ProductId"":26},{""CategoryId"":6,""ProductId"":27},{""CategoryId"":2,""ProductId"":28},{""CategoryId"":8,""ProductId"":29},{""CategoryId"":7,""ProductId"":30},{""CategoryId"":2,""ProductId"":31},{""CategoryId"":4,""ProductId"":32},{""CategoryId"":4,""ProductId"":33},{""CategoryId"":1,""ProductId"":34},{""CategoryId"":3,""ProductId"":35},{""CategoryId"":1,""ProductId"":36},{""CategoryId"":2,""ProductId"":37},{""CategoryId"":5,""ProductId"":38},{""CategoryId"":11,""ProductId"":39},{""CategoryId"":7,""ProductId"":40},{""CategoryId"":9,""ProductId"":41},{""CategoryId"":2,""ProductId"":42},{""CategoryId"":7,""ProductId"":43},{""CategoryId"":4,""ProductId"":44},{""CategoryId"":10,""ProductId"":45},{""CategoryId"":7,""ProductId"":46},{""CategoryId"":2,""ProductId"":47},{""CategoryId"":2,""ProductId"":48},{""CategoryId"":3,""ProductId"":49},{""CategoryId"":4,""ProductId"":50},{""CategoryId"":10,""ProductId"":51},{""CategoryId"":9,""ProductId"":52},{""CategoryId"":8,""ProductId"":53},{""CategoryId"":11,""ProductId"":54},{""CategoryId"":11,""ProductId"":55},{""CategoryId"":11,""ProductId"":56},{""CategoryId"":10,""ProductId"":57},{""CategoryId"":2,""ProductId"":58},{""CategoryId"":4,""ProductId"":59},{""CategoryId"":8,""ProductId"":60},{""CategoryId"":2,""ProductId"":61},{""CategoryId"":1,""ProductId"":62},{""CategoryId"":9,""ProductId"":63},{""CategoryId"":10,""ProductId"":64},{""CategoryId"":1,""ProductId"":65},{""CategoryId"":9,""ProductId"":66},{""CategoryId"":10,""ProductId"":67},{""CategoryId"":1,""ProductId"":68},{""CategoryId"":4,""ProductId"":69},{""CategoryId"":3,""ProductId"":70},{""CategoryId"":11,""ProductId"":71},{""CategoryId"":10,""ProductId"":72},{""CategoryId"":3,""ProductId"":73},{""CategoryId"":8,""ProductId"":74},{""CategoryId"":1,""ProductId"":75},{""CategoryId"":10,""ProductId"":76},{""CategoryId"":4,""ProductId"":77},{""CategoryId"":4,""ProductId"":78},{""CategoryId"":11,""ProductId"":79},{""CategoryId"":11,""ProductId"":80},{""CategoryId"":11,""ProductId"":81},{""CategoryId"":2,""ProductId"":82},{""CategoryId"":8,""ProductId"":83},{""CategoryId"":1,""ProductId"":84},{""CategoryId"":5,""ProductId"":85},{""CategoryId"":2,""ProductId"":86},{""CategoryId"":4,""ProductId"":87},{""CategoryId"":1,""ProductId"":88},{""CategoryId"":10,""ProductId"":89},{""CategoryId"":11,""ProductId"":90},{""CategoryId"":10,""ProductId"":91},{""CategoryId"":8,""ProductId"":92},{""CategoryId"":9,""ProductId"":93},{""CategoryId"":1,""ProductId"":94},{""CategoryId"":3,""ProductId"":95},{""CategoryId"":5,""ProductId"":96},{""CategoryId"":2,""ProductId"":97},{""CategoryId"":5,""ProductId"":98},{""CategoryId"":1,""ProductId"":99},{""CategoryId"":9,""ProductId"":100},{""CategoryId"":5,""ProductId"":101},{""CategoryId"":9,""ProductId"":102},{""CategoryId"":7,""ProductId"":103},{""CategoryId"":8,""ProductId"":104},{""CategoryId"":1,""ProductId"":105},{""CategoryId"":8,""ProductId"":106},{""CategoryId"":4,""ProductId"":107},{""CategoryId"":8,""ProductId"":108},{""CategoryId"":8,""ProductId"":109},{""CategoryId"":9,""ProductId"":110},{""CategoryId"":5,""ProductId"":111},{""CategoryId"":4,""ProductId"":112},{""CategoryId"":10,""ProductId"":113},{""CategoryId"":1,""ProductId"":114},{""CategoryId"":5,""ProductId"":115},{""CategoryId"":9,""ProductId"":116},{""CategoryId"":2,""ProductId"":117},{""CategoryId"":5,""ProductId"":118},{""CategoryId"":2,""ProductId"":119},{""CategoryId"":7,""ProductId"":120},{""CategoryId"":3,""ProductId"":121},{""CategoryId"":7,""ProductId"":122},{""CategoryId"":11,""ProductId"":123},{""CategoryId"":1,""ProductId"":124},{""CategoryId"":1,""ProductId"":125},{""CategoryId"":11,""ProductId"":126},{""CategoryId"":9,""ProductId"":127},{""CategoryId"":10,""ProductId"":128},{""CategoryId"":3,""ProductId"":129},{""CategoryId"":4,""ProductId"":130},{""CategoryId"":6,""ProductId"":131},{""CategoryId"":7,""ProductId"":132},{""CategoryId"":11,""ProductId"":133},{""CategoryId"":10,""ProductId"":134},{""CategoryId"":4,""ProductId"":135},{""CategoryId"":11,""ProductId"":136},{""CategoryId"":3,""ProductId"":137},{""CategoryId"":8,""ProductId"":138},{""CategoryId"":9,""ProductId"":139},{""CategoryId"":6,""ProductId"":140},{""CategoryId"":7,""ProductId"":141},{""CategoryId"":4,""ProductId"":142},{""CategoryId"":1,""ProductId"":143},{""CategoryId"":9,""ProductId"":144},{""CategoryId"":4,""ProductId"":145},{""CategoryId"":4,""ProductId"":146},{""CategoryId"":6,""ProductId"":147},{""CategoryId"":6,""ProductId"":148},{""CategoryId"":4,""ProductId"":149},{""CategoryId"":2,""ProductId"":150},{""CategoryId"":1,""ProductId"":151},{""CategoryId"":5,""ProductId"":152},{""CategoryId"":1,""ProductId"":153},{""CategoryId"":2,""ProductId"":154},{""CategoryId"":4,""ProductId"":155},{""CategoryId"":7,""ProductId"":156},{""CategoryId"":7,""ProductId"":157},{""CategoryId"":3,""ProductId"":158},{""CategoryId"":5,""ProductId"":159},{""CategoryId"":9,""ProductId"":160},{""CategoryId"":8,""ProductId"":161},{""CategoryId"":2,""ProductId"":162},{""CategoryId"":2,""ProductId"":163},{""CategoryId"":1,""ProductId"":164},{""CategoryId"":1,""ProductId"":165},{""CategoryId"":6,""ProductId"":166},{""CategoryId"":1,""ProductId"":167},{""CategoryId"":9,""ProductId"":168},{""CategoryId"":6,""ProductId"":169},{""CategoryId"":3,""ProductId"":170},{""CategoryId"":3,""ProductId"":171},{""CategoryId"":2,""ProductId"":172},{""CategoryId"":5,""ProductId"":173},{""CategoryId"":5,""ProductId"":174},{""CategoryId"":9,""ProductId"":175},{""CategoryId"":7,""ProductId"":176},{""CategoryId"":3,""ProductId"":177},{""CategoryId"":10,""ProductId"":178},{""CategoryId"":6,""ProductId"":179},{""CategoryId"":5,""ProductId"":180},{""CategoryId"":2,""ProductId"":181},{""CategoryId"":11,""ProductId"":182},{""CategoryId"":3,""ProductId"":183},{""CategoryId"":10,""ProductId"":184},{""CategoryId"":11,""ProductId"":185},{""CategoryId"":10,""ProductId"":186},{""CategoryId"":3,""ProductId"":187},{""CategoryId"":7,""ProductId"":188},{""CategoryId"":4,""ProductId"":189},{""CategoryId"":5,""ProductId"":190},{""CategoryId"":1,""ProductId"":191},{""CategoryId"":9,""ProductId"":192},{""CategoryId"":11,""ProductId"":193},{""CategoryId"":8,""ProductId"":194},{""CategoryId"":6,""ProductId"":195},{""CategoryId"":2,""ProductId"":196},{""CategoryId"":11,""ProductId"":197},{""CategoryId"":8,""ProductId"":198},{""CategoryId"":6,""ProductId"":199},{""CategoryId"":6,""ProductId"":200}]";


        var actualOutput =
            StartUp.ImportCategoryProducts(context, inputJson);

        var expectedOutput = $"Successfully imported 200";

        var assertContext = this.serviceProvider.GetService<ProductShopContext>();

        const int expectedCategoryProductsCount = 200;
        var actualGameCount = assertContext.CategoryProducts.Count();

        Assert.That(actualGameCount, Is.EqualTo(expectedCategoryProductsCount),
            $"Inserted {nameof(context.CategoryProducts)} count is incorrect!");

        Assert.That(actualOutput, Is.EqualTo(expectedOutput).NoClip,
            $"{nameof(StartUp.ImportCategoryProducts)} output is incorrect!");
    }

    private static Type GetType(string modelName)
    {
        var modelType = CurrentAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == modelName);

        Assert.IsNotNull(modelType, $"{modelName} model not found!");

        return modelType;
    }

    private static IServiceProvider ConfigureServices<TContext>(string databaseName)
        where TContext : DbContext
    {
        var services = ConfigureDbContext<TContext>(databaseName);

        var context = services.GetService<TContext>();

        try
        {
            context.Model.GetEntityTypes();
        }
        catch (InvalidOperationException ex) when (ex.Source == "Microsoft.EntityFrameworkCore.Proxies")
        {
            services = ConfigureDbContext<TContext>(databaseName, useLazyLoading: true);
        }

        return services;
    }

    private static IServiceProvider ConfigureDbContext<TContext>(string databaseName, bool useLazyLoading = false)
        where TContext : DbContext
    {
        var services = new ServiceCollection()
          .AddDbContext<TContext>(t => t
          .UseInMemoryDatabase(Guid.NewGuid().ToString())
          );

        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}