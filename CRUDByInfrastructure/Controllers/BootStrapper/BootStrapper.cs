using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDByInfrastructure.Controllers
{
    public static class BootStrapper
    {
        public static IServiceCollection RegisterBootStrapper(this IServiceCollection services)
        {
            services.AddScoped<IEmployee, EmployeeRepository>();
            services.AddScoped<ISubject, SubjectRepository>();
            return services;
        }
    }
}
