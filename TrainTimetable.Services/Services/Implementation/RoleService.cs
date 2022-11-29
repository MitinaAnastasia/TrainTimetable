using AutoMapper;
using TrainTimetable.Entities.Models;
using TrainTimetable.Repository;
using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Implementation;

public class RoleService : IRoleService
{
    private readonly IRepository<Role> rolesRepository;
    private readonly IMapper mapper;
    public RoleService(IRepository<Role> rolesRepository, IMapper mapper)
    {
        this.rolesRepository = rolesRepository;
        this.mapper = mapper;
    }

    RoleModel IRoleService.AddRole(RoleModel roleModel)
    {
        rolesRepository.Save(mapper.Map<Entities.Models.Role>(roleModel));
        return roleModel;
    }

    public void DeleteRole(Guid id)
    {
        var roleToDelete = rolesRepository.GetById(id);
        if (roleToDelete == null)
        {
            throw new Exception("Role not found"); 
        }

        rolesRepository.Delete(roleToDelete);
    }

    public RoleModel GetRole(Guid id)
    {
        var role = rolesRepository.GetById(id);
         if (role == null)
        {
            throw new Exception("Role not found"); 
        }
        return mapper.Map<RoleModel>(role);
    }

    public PageModel<RoleModel> GetRoles(int limit = 20, int offset = 0)
    {
        var roles = rolesRepository.GetAll();
        int totalCount = roles.Count();
        var chunk = roles.OrderBy(x => x.RoleName).Skip(offset).Take(limit);

        return new PageModel<RoleModel>()
        {
           
            Items = mapper.Map<IEnumerable<RoleModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public RoleModel UpdateRole(Guid id, UpdateRoleModel role)
    {
        var existingRole = rolesRepository.GetById(id);
        if (existingRole == null)
        {
            throw new Exception("Role not found");
        }

        existingRole.RoleName= role.RoleName;

        existingRole = rolesRepository.Save(existingRole);
        return mapper.Map<RoleModel>(existingRole);
    }
}