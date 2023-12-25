using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Domain.Entity;

public class Role
{
	public Guid RoleId { get; set; }
	public string Name { get; set; }
	public virtual ICollection<Utilisateur> Utilisateur  { get; set; } = new HashSet<Utilisateur>();
}
