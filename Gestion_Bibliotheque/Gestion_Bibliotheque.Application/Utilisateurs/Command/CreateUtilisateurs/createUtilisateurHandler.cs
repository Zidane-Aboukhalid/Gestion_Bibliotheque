using AutoMapper;
using Gestion_Bibliotheque.Domain.Entity;
using Gestion_Bibliotheque.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application.Utilisateurs.Command.CreateUtilisateurs
{
	public class createUtilisateurHandler : IRequestHandler<createUtilisateur, int>
	{
		private readonly IUnitOfwork unitOfwork;
		private readonly IMapper mapper;

		public createUtilisateurHandler(IUnitOfwork unitOfwork, IMapper mapper)
        {
			this.unitOfwork = unitOfwork;
			this.mapper = mapper;
		}

        public async Task<int> Handle(createUtilisateur request, CancellationToken cancellationToken)
		{
			var Uti= mapper.Map<Utilisateur>(request);
			return await unitOfwork.Utilisateurs.AddAsync(Uti);
		}
	}
}
