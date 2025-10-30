


using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions(); //performans icin hafif surum kullan�yoruz

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
