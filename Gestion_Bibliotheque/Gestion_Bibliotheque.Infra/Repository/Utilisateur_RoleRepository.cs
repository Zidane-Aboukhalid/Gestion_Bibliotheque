﻿using Gestion_Bibliotheque.Domain.Entity;
using Gestion_Bibliotheque.Domain.Repository;
using Gestion_Bibliotheque.Infra.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Infra.Repository
{
	public class Utilisateur_RoleRepository : BaseRepository<Utilisateur_Role>, IUtilisateur_RoleRepository
	{
		public Utilisateur_RoleRepository(applicationDbContext context) : base(context)
		{
		}
	}
}
