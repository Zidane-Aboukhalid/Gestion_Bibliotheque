using Gestion_Bibliotheque.Domain.Entity;
using Gestion_Bibliotheque.Domain.Repository;
using Gestion_Bibliotheque.Infra.data;

namespace Gestion_Bibliotheque.Infra.Repository
{
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository(applicationDbContext context) : base(context)
		{
		}
	}
}
