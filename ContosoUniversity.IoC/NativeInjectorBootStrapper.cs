using System;
using System.Reflection;
using AutoMapper;
using ContosoUniversity.Application.Commands.Student;
using ContosoUniversity.Application.Infrastructure;
using ContosoUniversity.Application.Interfaces;
using ContosoUniversity.Application.Mappers;
using ContosoUniversity.Application.Services;
using ContosoUniversity.Data.Context;
using ContosoUniversity.Data.Extensions;
using ContosoUniversity.Data.Settings;
using ContosoUniversity.Domain.Enums;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoUniversity.IoC
{
    public sealed class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterApplication(services);
            RegisterMediatr(services);
        }

        public static void RegisterApplication(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(IDesignTimeDbContextFactory<DataContext>), typeof(ContextFactory));

            services.AddTransient(typeof(IStudentService), typeof(StudentService));

            AutoMapperInitializer.Initialize();
            services.AddSingleton(typeof(IMapper), provider => Mapper.Instance);
        }

        public static void RegisterMediatr(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));

            services.AddMediatR(typeof(StudentCommandHandlersAsync).GetTypeInfo().Assembly);
        }

        public static void RegisterEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionProvider>(c =>
            {
                c.Provider = (DataProvider) Enum.Parse(
                    typeof(DataProvider),
                    configuration.GetSection("Data")["Provider"]);
            });

            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

            services.AddEntityFramework(configuration);
        }
    }
}