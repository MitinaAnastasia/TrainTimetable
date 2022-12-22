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
        var model = new RegisterUserModel(){
            Login = "test@test",
            Password = "Test",
            RoleId = new Guid("B7FCBD5B-BD20-4F15-B9E8-7F7DFA3D7259")           
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