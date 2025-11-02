

using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

// add services to the container build edilmeden calisacak kýsým
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>)); 
}
);

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
    options.Schema.For<ShoppingCart>().Identity(z=>z.UserName); 
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();


var app = builder.Build();  // ----------------------------------------------

// configure the HTTP request pipeline. build edildikten sonra calisacak kýsým



app.MapCarter();

app.UseExceptionHandler(opt => { });
app.Run();
