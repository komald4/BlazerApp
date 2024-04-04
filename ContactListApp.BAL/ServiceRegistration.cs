using ContactListApp.BAL.Features;
using ContactListApp.BAL.Features.Interfaces;
using ContactListApp.BAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace ContactListApp.BAL;

public static class ServiceRegistration
{
    
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IContactService, ContactService>();
    }
}

