using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Bibliotheque.Application
{
	public static class ApplicationServices
	{

		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(ctg =>
			ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			return services;
		}
	}
}
