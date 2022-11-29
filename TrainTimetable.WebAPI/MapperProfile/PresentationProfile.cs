using AutoMapper;
using TrainTimetable.WebAPI.Models;
using TrainTimetable.Services.Models;

namespace TrainTimetable.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region  Pages

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();;
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();;
        CreateMap<UserModel, UserPreviewResponse>().ReverseMap();;

        #endregion

        
        #region Trains

        CreateMap<TrainModel, TrainResponse>().ReverseMap();;
        CreateMap<UpdateTrainRequest, UpdateTrainModel>().ReverseMap();;
        CreateMap<TrainPreviewModel, TrainPreviewResponse>().ReverseMap();;

        #endregion

        
        #region Timetables

        CreateMap<TimetableModel, TimetableResponse>().ReverseMap();;
        CreateMap<UpdateTimetableRequest, UpdateTimetableModel>().ReverseMap();;
        CreateMap<TimetablePreviewModel, TimetablePreviewResponse>().ReverseMap();;

        #endregion

        
        #region Tickets

        CreateMap<TicketModel, TicketResponse>().ReverseMap();;
        CreateMap<UpdateTicketRequest, UpdateTicketModel>().ReverseMap();;
        CreateMap<TicketModel, TicketPreviewResponse>().ReverseMap();;

        #endregion

        
        #region Roles

        CreateMap<RoleModel, RoleResponse>().ReverseMap();;
        CreateMap<UpdateRoleRequest, UpdateRoleModel>().ReverseMap();;
        CreateMap<RoleModel, RolePreviewResponse>().ReverseMap();;

        #endregion
    }
}