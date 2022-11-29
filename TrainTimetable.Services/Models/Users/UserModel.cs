using TrainTimetable.Entities.Models;

namespace TrainTimetable.Services.Models;

public class UserModel : BaseModel
{
    public Guid RoleId { get; set; }
    public string Login { get; set; }
}