using Gestion_Bibliotheque.Application.Utilisateurs.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Command.GestionRolesUtilisateurs.AddRolesIntoUtilisateurs
{
	public class AddRoleIntoUtilisateurHandler : IRequestHandler<AddRoleIntoUtilisateur, int>
	{
		private readonly IUtilisateurService services;

		public AddRoleIntoUtilisateurHandler(IUtilisateurService Services)
		{
			services = Services;
		}
        async Task<int> IRequestHandler<AddRoleIntoUtilisateur, int>.Handle(AddRoleIntoUtilisateur request, CancellationToken cancellationToken)
		{
			return await services.AddRoles(request.IdUtilisateur,request.IdRole);
		}
	}
}
