using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Implementation;
using TrainTimetable.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace TrainTimetable.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITrainService, TrainService>();
        services.AddScoped<ITimetableService, TimetableService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<IRoleService, RoleService>();
    }
}