using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Domain.Entity;

public class Utilisateur_Role
{
	public Guid Utilisateur_RoleId { get; set; }
	[ForeignKey("RoleId")]
	public Guid RoleId { get; set; }
	[ForeignKey("UtilisateurId")]
	public Guid UtilisateurId { get; set; }


	public virtual Utilisateur Utilisateur { get; set; }
	public virtual Role Role { get; set; }	

}
