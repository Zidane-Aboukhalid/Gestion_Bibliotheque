using Gestion_Bibliotheque.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Bibliotheque.Infra.data;

public class applicationDbContext : DbContext
{
    public applicationDbContext(DbContextOptions<applicationDbContext> dbContextOptions):base(dbContextOptions) { }

	public DbSet<Utilisateur> Utilisateurs { get; set; }
	public DbSet<Role> Roles { get; set; }
	public DbSet<Utilisateur_Role> Utilisateur_Roles { get; set;}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		var ListRoles = new List<Role> {

		new Role{
			RoleId=Guid.NewGuid(),
			Name="Administrateur"
		},
		new Role{
			RoleId=Guid.NewGuid(),
			Name="Etudiant"
		},
		new Role{
			RoleId=Guid.NewGuid(),
			Name="Etudiant_VIP"
		},
		new Role{
			RoleId=Guid.NewGuid(),
			Name="Etudiant_Bronze"
		}
		};
		modelBuilder.Entity<Role>().HasData(ListRoles);

	}
}
