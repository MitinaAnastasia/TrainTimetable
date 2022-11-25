using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Abstract;

public interface IRoleService
{
    RoleModel GetRole(Guid id);

    RoleModel UpdateRole(Guid id, UpdateRoleModel role);

    void DeleteRole(Guid id);

    PageModel<RoleModel> GetRoles(int limit = 20, int offset = 0);
}