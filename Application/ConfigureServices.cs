using Application.Interface.Person;
using Application.Profiles;
using Application.Service;
using AutoMapper;
using Domain.Repository.UserRepository;
using Infrastructure.AppDbContext;
using Infrastructure.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
  public static class ConfigureServices
    {
        public static void AddApplicationServices(this IServiceCollection services , IConfiguration configuration)
        {
        
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<MyAppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUserRepository, UserRepository>();
   
            //  return services;
        }
    }
}
