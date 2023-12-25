using AutoMapper;
using Gestion_Bibliotheque.Application.Utilisateurs.ViewModel;
using Gestion_Bibliotheque.Domain.Entity;
using Gestion_Bibliotheque.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Queries
{
	public class GetAllUtilisateurHandler : IRequestHandler<GetAllUtilisateurQueries, ICollection<SelectUtilisateursDto>>
	{
		private readonly IUnitOfwork unitOfwork;
		private readonly IMapper mapper;

		public GetAllUtilisateurHandler(IUnitOfwork unitOfwork , IMapper mapper)
        {
			this.unitOfwork = unitOfwork;
			this.mapper = mapper;
		}


        public async Task<ICollection<SelectUtilisateursDto>> Handle(GetAllUtilisateurQueries request, CancellationToken cancellationToken)
		{
			return mapper.Map<ICollection<SelectUtilisateursDto>>(await unitOfwork.Utilisateurs.GetAllAsyn());
		}
	}
}
