var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);  
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions(); //performans icin hafif surum kullanıyoruz
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapCarter();
app.Run();
