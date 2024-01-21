using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        /// <summary>
        /// Adds the infrastructure services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration"></param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
