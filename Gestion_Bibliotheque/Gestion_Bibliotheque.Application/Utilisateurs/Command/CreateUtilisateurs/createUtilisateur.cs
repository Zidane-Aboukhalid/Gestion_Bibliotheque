using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Command.CreateUtilisateurs
{
	public record createUtilisateur(Guid Id ,string Nom , string Prenom ,
		string Email, string PasswordHash , string Ecol, string Adresse , bool JobInTech) :IRequest<int>;
	
}
