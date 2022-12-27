using TrainTimetable.Entities.Models;
using TrainTimetable.Services.Models;
using TrainTimetable.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TrainTimetable.Test;

[TestFixture]
public partial class UserTests
{
    [Test]
    public async Task UpdateUser_Success()
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

        var newModel = new UpdateUserModel(){
            Login = "new@test"
        };

        var resultModel2 = userService.UpdateUser(resultModel.Id, newModel);

        Assert.AreEqual(resultModel.Login, resultModel2.Login);
    }

    [Test]
    public async Task UpdateUser_NotExisting()
    {
        var newModel = new UpdateUserModel(){
            Login = "new@test"
        };
        var randonGuid = Guid.NewGuid();

        Assert.Throws<LogicException>( ()=>
        {
            var result = userService.UpdateUser(randonGuid, newModel); 
        });   
    }
}