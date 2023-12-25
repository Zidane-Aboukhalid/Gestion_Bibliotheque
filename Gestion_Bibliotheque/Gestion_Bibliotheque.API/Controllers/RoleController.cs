using Gestion_Bibliotheque.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Bibliotheque.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly IUnitOfwork unitOfwork;

		public RoleController(IUnitOfwork unitOfwork)
        {
			this.unitOfwork = unitOfwork;
		}


        [HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await unitOfwork.Roles.GetAllAsyn());
		}
	}
}
