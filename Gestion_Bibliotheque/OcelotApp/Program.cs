using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("OcelotConfig.json",optional:false, reloadOnChange:true);
builder.Services.AddOcelot(builder.Configuration);
var app = builder.Build();

//app.MapGet("/test", () => "Hello World!");
//app.MapControllers();
await app.UseOcelot();
app.Run();
