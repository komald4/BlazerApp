using System;
using ContactListApp.BAL.Interfaces;
using ContactListApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContactListApp.DAL
{
	public static class ServiceRegistration
	{
		public static void RegisterDatabaseService(this IServiceCollection services)
		{

		}

        public static void RegisterRepository(this IServiceCollection services)
        {
			services.AddScoped<IContactRepository, ContactRepository>();
        }
    }
}

