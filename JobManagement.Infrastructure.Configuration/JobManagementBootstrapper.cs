using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using JobManagement.Application;
using JobManagement.Application.Contracts.Person;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using JobManagement.Application.Contracts.QorbMoasPorKar;
using JobManagement.Domain.PersonAgg;
using JobManagement.Domain.PersonEshtegVazAgg;
using JobManagement.Domain.PersonOzvNoaAgg;
using JobManagement.Domain.QorbAgg;
using JobManagement.Domain.QorbMoasAgg;
using JobManagement.Domain.QorbMoasPorAgg;
using JobManagement.Domain.QorbMoasPorKarAgg;
using JobManagement.Infrastructure.EFCore;
using JobManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobManagement.Infrastructure.Configuration
{
    public class JobManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<IPersonApplication,PersonApplication>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddTransient<IPersonEshtegVazApplication, PersonEshtegVazApplication>();
            services.AddTransient<IPersonEshtegVazRepository, PersonEshtegVazRepository>();

            services.AddTransient<IPersonOzvNoaApplication, PersonOzvNoaApplication>();
            services.AddTransient<IPersonOzvNoaRepository, PersonOzvNoaRepository>();

            services.AddTransient<IQorbApplication, QorbApplication>();
            services.AddTransient<IQorbRepository, QorbRepository>();

            services.AddTransient<IQorbMoasApplication, QorbMoasApplication>();
            services.AddTransient<IQorbMoasRepository, QorbMoasRepository>();

            services.AddTransient<IQorbMoasPorApplication, QorbMoasPorApplication>();
            services.AddTransient<IQorbMoasPorRepository, QorbMoasPorRepository>();

            services.AddTransient<IQorbMoasPorKarApplication, QorbMoasPorKarApplication>();
            services.AddTransient<IQorbMoasPorKarRepository, QorbMoasPorKarRepository>();



            //services.AddDbContext<JobContext>(x => x.UseSqlServer(connectionstring, b => b.MigrationsAssembly("JobManagement.Infrastructure.EfCore")));
            services.AddDbContext<JobContext>(x => x.UseSqlServer(connectionstring, b => b.MigrationsAssembly("JobManagement.Infrastructure.EFCore")));

        }
    }
}
