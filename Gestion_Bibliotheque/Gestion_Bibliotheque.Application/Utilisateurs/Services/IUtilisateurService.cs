using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Services
{
	public interface IUtilisateurService
	{
		Task<int> AddRoles(Guid IdUtilisateur , Guid IdRoles);

		Task<int> DeleteRoles(Guid IdUtilisateur, Guid IdRoles);

		Task<int> UpdatePassWord(Guid IdUtilisateur);

	}
}
