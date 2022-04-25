using AutoMapper;
using Manager.Core.Token;
using Manager.Domain.Entities;
using Manager.Domain.ViewModels.User;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Manager.Infra.Repositories;
using Manager.Services.DTOs;
using Manager.Services.Interfaces;
using Manager.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Manager.IoC
{
    public static class Injector
    {
        private static bool _injected = false;

        private static void SetInjected()
        {
            if (!_injected)
                _injected = true;
        }

        private static bool IsInjected()
            => _injected;

        public static void Inject(this IServiceCollection services)
        {
            if (IsInjected())
                return;

            InjectServices(services);
            InjectRepositories(services);
            InjectAutoMapper(services);
            InjectGenerics(services);

            SetInjected();
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void InjectGenerics(IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
        }

        private static void InjectAutoMapper(IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
                cfg.CreateMap<UpdateUserViewModel, UserDto>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
        }

        public static void InjectEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ManagerContext>(opt => opt.UseSqlServer(connectionString), ServiceLifetime.Transient);
        }
    }
}