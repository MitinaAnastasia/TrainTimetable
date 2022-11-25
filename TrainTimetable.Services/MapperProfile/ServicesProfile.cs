using AutoMapper;
using TrainTimetable.Entities.Models;
using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();

        #endregion

        #region Roles

        CreateMap<Role, RoleModel>().ReverseMap();
        CreateMap<Role, UpdateRoleModel>().ReverseMap();

        #endregion

        #region Tickets

        CreateMap<Ticket, TicketModel>().ReverseMap();
        CreateMap<Ticket, UpdateTicketModel>().ReverseMap();

        #endregion

        #region Timetables

        CreateMap<Timetable, TimetableModel>().ReverseMap();
        CreateMap<Timetable, TimetablePreviewModel>().ReverseMap();
        CreateMap<Timetable, UpdateTimetableModel>().ReverseMap();

        #endregion

        #region Trains

        CreateMap<Train, TrainModel>().ReverseMap();
        CreateMap<Train, TrainPreviewModel>().ReverseMap();
        CreateMap<Train, UpdateTrainModel>().ReverseMap();

        #endregion
    }
}
