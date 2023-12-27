using Gestion_Bibliotheque.Application;
using Gestion_Bibliotheque.Infra;
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

app.Run();
