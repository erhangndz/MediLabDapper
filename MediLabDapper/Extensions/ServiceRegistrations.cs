﻿using MediLabDapper.Context;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MediLabDapper.Extensions
{
    public static class ServiceRegistrations
    {



        public static IServiceCollection AddRepositoriesExt(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<DapperContext>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            return services;
        }


    }
}
