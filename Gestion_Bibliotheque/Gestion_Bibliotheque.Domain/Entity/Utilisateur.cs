namespace Gestion_Bibliotheque.Domain.Entity;

public class Utilisateur
{
    public Guid UtilisateurId { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Ecol { get; set; }
    public string Adresse { get; set; }
    public bool JobInTech { get; set; } 
    public bool Isblock { get; set; }
    public virtual ICollection<Role> Roles { get; set; }= new HashSet<Role>();  
}
