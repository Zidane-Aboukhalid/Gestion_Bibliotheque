using Gestion_Bibliotheque.Domain.Repository;
using Gestion_Bibliotheque.Infra.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Infra.Repository
{
	public class UnitOfwork : IUnitOfwork
	{
		private readonly applicationDbContext context;

		public UnitOfwork(applicationDbContext _context)
        {
			this.context = _context;
			Roles = new  RoleRepository(context);
			Utilisateurs = new UtilisateurRepository(context);	
			Utilisateurs_Roles = new Utilisateur_RoleRepository(context);

		}

		public IRoleRepository Roles { get;protected set ; }
		public IUtilisateurRepository Utilisateurs { get; protected set; }
		public IUtilisateur_RoleRepository Utilisateurs_Roles { get; protected set; }
		public void Dispose()
		{
			context.Dispose();
		}
	}
}
