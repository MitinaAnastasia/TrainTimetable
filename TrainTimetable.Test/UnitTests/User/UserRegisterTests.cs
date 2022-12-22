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
    public async Task RegisterUser_Success()
    {
        var model = new RegisterUserModel(){
            Login = "test@test",
            Password = "Test",
            RoleId = new Guid("B7FCBD5B-BD20-4F15-B9E8-7F7DFA3D7259")        
        };

        var resultModel = await authService.RegisterUser(model);
        Assert.AreEqual(model.Login, resultModel.Login);
        Assert.AreEqual(model.RoleId, resultModel.RoleId);

        var user = userRepository.GetById(resultModel.Id);
        
        var signInManager = services.Get<SignInManager<User>>();
        var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        Assert.AreEqual(result.Succeeded, true);
    }

    [Test]
    public async Task RegisterUser_EmailExists()
    {
        var model = new RegisterUserModel(){
            Login = "test@test",
            Password = "Test",
            RoleId = new Guid("B7FCBD5B-BD20-4F15-B9E8-7F7DFA3D7259")            
        };

        var resultModel = await authService.RegisterUser(model);
        Assert.ThrowsAsync<LogicException>(async ()=>
        {
            var result2 = await authService.RegisterUser(model); 
        });   
    }

    [Test]
    [TestCaseSource(typeof(UserCaseSource),nameof(UserCaseSource.InvalidPasswords))]
    public async Task RegisterUser_PasswordIsInvalid(string password)
    {
        var model = new RegisterUserModel(){
            Login = "test@test",
            Password = password,
            RoleId = new Guid("B7FCBD5B-BD20-4F15-B9E8-7F7DFA3D7259")            
        };

        Assert.ThrowsAsync<LogicException>(async ()=>
        {
            var result = await authService.RegisterUser(model); 
        });   
    }
}
