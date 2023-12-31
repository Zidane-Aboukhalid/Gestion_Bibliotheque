﻿using FluentValidation;
using Gestion_Bibliotheque.Application.Behaviours;
using Gestion_Bibliotheque.Application.Utilisateurs.Services;
using MediatR;
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
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(ctg =>
			{
				ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
				ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
			}
			) ;
			services.AddTransient<IUtilisateurService, UtilisateurService>();
			return services;
		}
	}
}
