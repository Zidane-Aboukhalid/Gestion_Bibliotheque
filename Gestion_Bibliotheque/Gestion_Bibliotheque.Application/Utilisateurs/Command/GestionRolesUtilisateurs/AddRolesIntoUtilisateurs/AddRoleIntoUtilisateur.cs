using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Command.GestionRolesUtilisateurs.AddRolesIntoUtilisateurs
{
	public record class AddRoleIntoUtilisateur(
		Guid IdUtilisateur,
		Guid IdRole
	) : IRequest<int>;
}
