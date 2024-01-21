﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        /// <summary>
        /// Adds the application services.
        /// </summary>
        /// <param name = "services" > The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            

            return services;
        }
    }
}
