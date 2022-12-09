using TrainTimetable.Services.Models;
using IdentityModel.Client;

namespace TrainTimetable.Services.Abstract;

public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}


