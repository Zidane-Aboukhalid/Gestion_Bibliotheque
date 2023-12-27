using Gestion_Bibliotheque.Application.Utilisateurs.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Command.GestionRolesUtilisateurs.RemoveRolesIntoUtilisateurs
{
	public class RemoveRoleIntoUtilisateurHandler : IRequestHandler<RemoveRoleIntoUtilisateur, int>
	{
		private readonly IUtilisateurService services;

		public RemoveRoleIntoUtilisateurHandler(IUtilisateurService Services)
        {
			services = Services;
		}
        public async Task<int> Handle(RemoveRoleIntoUtilisateur request, CancellationToken cancellationToken)
		{
			return await services.DeleteRoles(request.IdUtilisateur, request.IdRole);
		}
	}
}
