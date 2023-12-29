using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace Gestion_Bibliotheque.API.Services.Health;

public class ApiHealthCheck : IHealthCheck
{
	public async Task<HealthCheckResult> CheckHealthAsync(
		HealthCheckContext context,
		CancellationToken cancellationToken = default)
	{
		var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";
		var client = new RestClient(url);
		var request = new RestRequest(url, Method.Get);
		request.AddHeader("accept", "application/json");
		request.AddHeader("X-RapidAPI-Key", "c8db2584camsh50f8971d0892e4bp14b19ajsn3058a64bf896");
		request.AddHeader("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
		var response = await client.ExecuteAsync(request);

		if (response.IsSuccessful)
		{
			return await Task.FromResult(HealthCheckResult.Healthy());
		}
		else
		{
			return await Task.FromResult(HealthCheckResult.Unhealthy());
		}
	}
}
