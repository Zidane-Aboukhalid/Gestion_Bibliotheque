using MediatR;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Command.GestionRolesUtilisateurs.RemoveRolesIntoUtilisateurs
{
	public record RemoveRoleIntoUtilisateur(Guid IdUtilisateur,
		Guid IdRole
	) : IRequest<int>;
}
