

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
var app = builder.Build();

// configure the HTTP request pipeline. build edildikten sonra calisacak kýsým

app.MapCarter();
app.Run();
