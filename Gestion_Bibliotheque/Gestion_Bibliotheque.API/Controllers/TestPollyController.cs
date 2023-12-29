using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using RestSharp;

namespace Gestion_Bibliotheque.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestPollyController : ControllerBase
	{

		[HttpGet]
		public async Task<IActionResult> GetJokes()
		{



			// method 1 with Count like 5 range (1,5)
			//var retryPoticy = Policy
			//	.Handle<Exception>()
			//	.RetryAsync(5, onRetry: (Exception, retryCount) => 
			//	{
			//		Console.WriteLine("Error: "+Exception.Message + " .... Retry Count"+ retryCount);
			//	});
			//await retryPoticy.ExecuteAsync(async () =>
			//{
			//	await ConnectApiAsync();
			//});





			// method 2 avery 15 s retry execute code 
			//var RetryPolicyAwait = Policy
			//	.Handle<Exception>()
			//	.WaitAndRetryAsync(5,i=> TimeSpan.FromSeconds(15), onRetry: (Exception, retryCount) =>
			//	{
			//		Console.WriteLine("Error: " + Exception.Message +".. Retry Count : "+  retryCount);
			//	});
			//await RetryPolicyAwait.ExecuteAsync(async () =>
			//{
			//	await ConnectApiAsync();
			//});




			//method 3 
			//var retryPolicy =Policy
			//	.Handle<Exception>()
			//	.WaitAndRetry(5,i=> TimeSpan.FromSeconds(5), (exception, retryCount) =>
			//	{
			//		Console.WriteLine("Error:"+exception.Message+".. Retry Count : " + retryCount);
			//	});
			//var circuitBreakerPolicy = Policy
			//	.Handle<Exception>()
			//	.CircuitBreaker(3, TimeSpan.FromSeconds(5));
			//var finalPolicy = retryPolicy.Wrap(circuitBreakerPolicy);

			//finalPolicy.Execute(() =>
			//{
			//	Console.WriteLine("Executing");
			//	ConnectApi();
			//});

			// method 3 with async 
			var retryPolicy = Policy
				.Handle<Exception>().
				WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(5), (exception, retryCount) =>
				{
					Console.WriteLine("Error:" + exception.Message + ".. Retry Count : " + retryCount);
				});
			var circuitBreakerPolicy = Policy
				.Handle<Exception>()
				.CircuitBreakerAsync(3, TimeSpan.FromSeconds(5));
			var finalPolicy=retryPolicy.WrapAsync(circuitBreakerPolicy);
			_= finalPolicy.ExecuteAsync(async () =>
			{
				Console.WriteLine("Executing");
				await ConnectApiAsync();
			});

			return Ok();
		}

		private async Task ConnectApiAsync()
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
				Console.WriteLine(response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorException.Message);
				throw new Exception("Not able to connect to the service");
			}
		}


		private void ConnectApi()
		{
			var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Get);
			request.AddHeader("accept", "application/json");
			request.AddHeader("X-RapidAPI-Key", "c8db2584camsh50f8971d0892e4bp14b19ajsn3058a64bf896");
			request.AddHeader("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
			var response = client.Execute(request);

			if (response.IsSuccessful)
			{
				Console.WriteLine(response.Content);
			}
			else
			{
				Console.WriteLine(response.ErrorException.Message);
				throw new Exception("Not able to connect to the service");
			}
		}
	}
}
