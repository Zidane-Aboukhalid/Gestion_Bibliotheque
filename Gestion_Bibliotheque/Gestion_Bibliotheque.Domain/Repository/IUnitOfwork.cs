using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Domain.Repository;

public  interface IUnitOfwork : IDisposable
{
	IRoleRepository Roles { get; }
	IUtilisateurRepository Utilisateurs { get; }
	IUtilisateur_RoleRepository Utilisateurs_Roles { get; }
}
