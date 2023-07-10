using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NLog;
using NLog.Extensions.Logging;
using OnlineBookstore.Data;
using OnlineBookstore.Repositories;
using OnlineBookstore.Repository.Interfaces;
using OnlineBookstore.Service.Interfaces;
using OnlineBookstore.Services;
using System;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();

// Early init of NLog to allow startup and exception logging, before host is built
LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
var logger = LogManager.GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Ovde gi spremame site servisi i configuracii
    // koi sto sakame da gi koristime vo nasata app

    ConfigurationManager configuration = builder.Configuration; // access and setup the config
    IWebHostEnvironment environment = builder.Environment; // access and setup the environment

    // Add/register services to the container.
    builder.Services.AddScoped<IAuthorService, AuthorService>();
    builder.Services.AddScoped<IBookService, BookService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<IPhotoService, PhotoService>();
    builder.Services.AddScoped<IPublisherService, PublisherService>();
    builder.Services.AddScoped<IShopCartService, ShopCartService>();
    builder.Services.AddScoped<IUserService, UserService>();

    // Add/register repositories to the container
    builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
    builder.Services.AddScoped<IBookRepository, BookRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
    builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
    builder.Services.AddScoped<IShopCartRepository, ShopCartRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();


    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(c => c.AddPolicy("OnlineBookstoreCorsPolicy", builder =>
    {
        builder
        //.WithOrigins()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    }));

    builder.Services.AddDbContext<OnlineBookstoreDbContext>(options =>
    {
        if (environment.EnvironmentName.Equals("Production"))
        {
            options.UseSqlServer(configuration.GetValue<string>("Configuration:ConnectionStringProd"),
                   sqlServerOptionsAction: sqlOptions =>
                   {
                       sqlOptions.EnableRetryOnFailure();
                   });
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // TODO:
        }
        else
        {
            options.UseSqlServer(configuration.GetValue<string>("Configuration:ConnectionString"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    });
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // TODO:
        }
    });


    // -----------------------------------------------------------------------------------------

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources/Images")),
        RequestPath = new PathString("/Resources/Images")
    });

    app.UseCors("OnlineBookstoreCorsPolicy");

    app.Run();
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}
