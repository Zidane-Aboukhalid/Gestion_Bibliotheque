using Gestion_Bibliotheque.Application.Utilisateurs.Command.GestionRolesUtilisateurs.AddRolesIntoUtilisateurs;
using Gestion_Bibliotheque.Application.Utilisateurs.Command.GestionRolesUtilisateurs.RemoveRolesIntoUtilisateurs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Bibliotheque.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UtilisateurRolesController : ControllerBase
	{
		private readonly IMediator mediator;

		public UtilisateurRolesController(IMediator mediator)
        {
			this.mediator = mediator;
		}

		[HttpPost("addRolesIntoUser")]
		public async Task<IActionResult> addRoleIntoUtilisateurs([FromBody] AddRoleIntoUtilisateur addRoleIntoUtilisateur , CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(addRoleIntoUtilisateur, cancellationToken));
		}

		[HttpPost("RemoveRolesIntoUser")]
		public async Task<IActionResult> RemoveRoleIntoUtilisateurs([FromBody] RemoveRoleIntoUtilisateur removeRoleIntoUtilisateur, CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(removeRoleIntoUtilisateur, cancellationToken));
		}
	}
}
