using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data;

var builder = WebApplication.CreateBuilder(args);

// Ovde gi spremame site servisi i configuracii
// koi sto sakame da gi koristime vo nasata app

ConfigurationManager configuration = builder.Configuration; // access and setup the config
IWebHostEnvironment environment = builder.Environment; // access and setup the environment

// Add services to the container.

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

app.UseCors("OnlineBookstoreCorsPolicy");

app.Run();
