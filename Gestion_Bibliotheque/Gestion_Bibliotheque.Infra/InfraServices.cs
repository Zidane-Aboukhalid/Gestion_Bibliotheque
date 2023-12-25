using Gestion_Bibliotheque.Domain.Repository;
using Gestion_Bibliotheque.Infra.data;
using Gestion_Bibliotheque.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Infra
{
	public static class InfraServices
	{

		public static IServiceCollection AddInfraServices(this IServiceCollection service , IConfiguration configuration) 
		{
			service.AddDbContext<applicationDbContext>(op =>
			op.UseSqlite(
				configuration.GetConnectionString("con") 
				?? throw new InvalidOperationException("connection string not found ")
			));

			service.AddScoped<IUnitOfwork, UnitOfwork>();
			return service;
		}
	}
}
