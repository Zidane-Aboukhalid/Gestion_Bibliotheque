using Gestion_Bibliotheque.Application.Utilisateurs.Command.CreateUtilisateurs;
using Gestion_Bibliotheque.Application.Utilisateurs.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Bibliotheque.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UtilisateurController : ControllerBase
	{
		private readonly IMediator mediator;

		public UtilisateurController(IMediator mediator)
        {
			this.mediator = mediator;
		}
		[HttpGet] 
		public async Task<IActionResult> GetAllUtilisateurs()
		{
			var AllUtilisateurs = await mediator.Send(new GetAllUtilisateurQueries());
			return Ok(AllUtilisateurs);
		}

		[HttpPost]
		public async Task<IActionResult> CreateUti(createUtilisateur createUtilisateur , CancellationToken cancellationToken)
		{
			var res= await mediator.Send(createUtilisateur, cancellationToken);

			return res switch
			{
				1 => Ok(),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			}; ;
		}


	}
}
