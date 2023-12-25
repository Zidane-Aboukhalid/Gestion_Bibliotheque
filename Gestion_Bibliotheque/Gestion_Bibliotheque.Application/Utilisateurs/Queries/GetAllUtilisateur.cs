using Gestion_Bibliotheque.Application.Utilisateurs.ViewModel;
using MediatR;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Queries;

public record GetAllUtilisateurQueries():IRequest<ICollection<SelectUtilisateursDto>>;	
