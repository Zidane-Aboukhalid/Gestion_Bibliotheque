using AutoMapper;
using Gestion_Bibliotheque.Application.Utilisateurs.Command.CreateUtilisateurs;
using Gestion_Bibliotheque.Application.Utilisateurs.ViewModel;
using Gestion_Bibliotheque.Domain.Entity;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Mapping
{
	public class UtilisateursMapping :Profile
	{
        public UtilisateursMapping()
        {
			CreateMap<createUtilisateur, Utilisateur>()
			.ForMember(dest => dest.UtilisateurId, opt => opt.MapFrom(src => src.Id))
			.ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.Nom))
			.ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src.Prenom))
			.ForMember(dest => dest.Adresse, opt => opt.MapFrom(src => src.Adresse))
			.ForMember(dest => dest.Ecol, opt => opt.MapFrom(src => src.Ecol))
			.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
			.ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash)).ReverseMap();

			//CreateMap<Utilisateur,SelectUtilisateursDto>()
			//.ForMember(dest=>dest.Id,opt=> opt.MapFrom(src=> src.UtilisateurId))
			//.ForMember(dest=> dest.Nom , opt=> opt.MapFrom(src=> src.Nom))
			//.ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src.Prenom))
			//.ForMember(dest => dest.Adresse, opt => opt.MapFrom(src => src.Adresse))
			//.ForMember(dest => dest.Ecol, opt => opt.MapFrom(src => src.Ecol))
			//.ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
			//.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash)).ReverseMap();


			CreateMap<Utilisateur, SelectUtilisateursDto>().ReverseMap();


		}
	}
}
