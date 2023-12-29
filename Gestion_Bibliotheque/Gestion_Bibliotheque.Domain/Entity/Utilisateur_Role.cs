namespace Gestion_Bibliotheque.Domain.Entity;

public class Utilisateur_Role
{
	public Guid Utilisateur_RoleId { get; set; }
	public Guid RoleId { get; set; }
	public Guid UtilisateurId { get; set; }
	public virtual Utilisateur Utilisateur { get; set; }
	public virtual Role Role { get; set; }	

}
