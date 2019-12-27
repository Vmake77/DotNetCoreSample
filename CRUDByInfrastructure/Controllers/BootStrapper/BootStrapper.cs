using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDByInfrastructure.Controllers
{
    public static class BootStrapper
    {
        public static IServiceCollection BootStrapperServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployee, EmployeeRepository>();
            services.AddScoped<ISubject, SubjectRepository>();
            return services;
        }
    }
}
