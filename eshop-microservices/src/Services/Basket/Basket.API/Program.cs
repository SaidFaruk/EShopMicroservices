var builder = WebApplication.CreateBuilder(args);

// add services to the container build edilmeden calisacak kýsým

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
