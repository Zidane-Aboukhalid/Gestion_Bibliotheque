using Gestion_Bibliotheque.Domain.Entity;
using Gestion_Bibliotheque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Services
{
	public class UtilisateurService : IUtilisateurService
	{
		private readonly IUnitOfwork unitOfwork;

		public UtilisateurService(IUnitOfwork unitOfwork)
        {
			this.unitOfwork = unitOfwork;
		}
        public async Task<int> AddRoles(Guid IdUtilisateur, Guid IdRoles)
		{
			var uti = await unitOfwork.Utilisateurs.FindAsync(x=> x.UtilisateurId == IdUtilisateur);
			var role = await unitOfwork.Roles.FindAsync(x => x.RoleId == IdRoles);
			if (uti == null)
				throw new NotSupportedException("Utilisateur is not exist .");
			if (role == null)
				throw new NotSupportedException("Role is not exist .");
			var Utilisateurs_Roles = new Utilisateur_Role
			{
				Utilisateur_RoleId = Guid.NewGuid(),
				RoleId = role.RoleId,
				UtilisateurId = uti.UtilisateurId,
			};

			return await unitOfwork.Utilisateurs_Roles.AddAsync(Utilisateurs_Roles);
		}

		public async Task<int> DeleteRoles(Guid IdUtilisateur, Guid IdRoles)
		{
			var uti = await unitOfwork.Utilisateurs.FindAsync(x => x.UtilisateurId == IdUtilisateur);
			var role = await unitOfwork.Roles.FindAsync(x => x.RoleId == IdRoles);
			if (uti == null)
				throw new NotSupportedException("Utilisateur is not exist .");
			if (role == null)
				throw new NotSupportedException("Role is not exist .");
			var Utilisateurs_Roles = await unitOfwork.Utilisateurs_Roles.FindAsync(x=> x.UtilisateurId==IdUtilisateur && x.RoleId==IdRoles);
			if (Utilisateurs_Roles == null) throw new NotSupportedException("this role is not exist in this user");

			return await unitOfwork.Utilisateurs_Roles.DeleteAsync(Utilisateurs_Roles.Utilisateur_RoleId, Utilisateurs_Roles);
		}

		public Task<int> UpdatePassWord(Guid IdUtilisateur)
		{
			throw new NotImplementedException();
		}
	}
}
