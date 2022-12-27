using TrainTimetable.Services.Models;
using TrainTimetable.Shared.Exceptions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TrainTimetable.Test;

[TestFixture]
public partial class UserTests
{
    [Test]
    public async Task DeleteUser_Success()
    {
        var modelRole = new RoleModel(){
            RoleName = "Admin"
        };

        var roleModel = roleService.AddRole(modelRole);

        var model = new RegisterUserModel(){
            Login = "test@test",
            Password = "Test",
            RoleId = roleModel.Id           
        };

        var resultModel = await authService.RegisterUser(model);
        userService.DeleteUser(resultModel.Id);
        
        Assert.Throws<LogicException>(()=>
            {
                var checkUser = userService.GetUser(resultModel.Id);
            }
        );
    }

    [Test]
    public async Task DeleteUser_NotExisting()
    {
        var randomGuid = Guid.NewGuid();
        Assert.Throws<LogicException>(()=>
            userService.DeleteUser(randomGuid)
        );
    }
}