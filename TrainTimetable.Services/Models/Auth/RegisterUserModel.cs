using TrainTimetable.Entities.Models;

namespace TrainTimetable.Services.Models;

public class RegisterUserModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
}