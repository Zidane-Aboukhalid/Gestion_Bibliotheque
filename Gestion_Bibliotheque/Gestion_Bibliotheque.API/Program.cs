using Gestion_Bibliotheque.API.Services.Health;
using Gestion_Bibliotheque.Application;
using Gestion_Bibliotheque.Infra;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddRateLimiter(op =>
{
	op.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(content =>
		RateLimitPartition.GetFixedWindowLimiter(
			partitionKey: content.Request.Headers.Host.ToString(),
			factory: partition => new FixedWindowRateLimiterOptions
			{
				AutoReplenishment = true,
				PermitLimit = 5,
				QueueLimit = 0,
				Window = TimeSpan.FromSeconds(10)
			}
		)
	);
	op.RejectionStatusCode = StatusCodes.Status429TooManyRequests; 
}
);

// add config in HeatthChecks

builder.Services.AddHealthChecks()
	.AddCheck<ApiHealthCheck>("jokesApichecks",tags: new string[] { "jokesApi"}); 


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
app.UseRateLimiter();


// check Heatth Checks 

app.MapHealthChecks("/HealthChecks" ,new HealthCheckOptions()
{
	Predicate =_=>true,
	ResponseWriter=UIResponseWriter.WriteHealthCheckUIResponse

});

app.Run();
