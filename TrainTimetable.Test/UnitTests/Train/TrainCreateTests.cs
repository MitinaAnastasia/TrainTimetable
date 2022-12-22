using TrainTimetable.Entities.Models;
using TrainTimetable.Services.Models;
using TrainTimetable.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TrainTimetable.Test;

[TestFixture]
public partial class TrainTests
{
    [Test]
    public async Task CreateTrain_Success()
    {
        var model = new TrainModel(){
            TrainNumber = "number",
            FirstStation = "first",
            LastStation  =  "last"
        };

        var addTrain = trainService.AddTrain(model);

        var train = trainService.GetTrain(addTrain.Id);

        Assert.AreEqual(model.TrainNumber, train.TrainNumber);
        Assert.AreEqual(model.FirstStation, train.FirstStation);
        Assert.AreEqual(model.LastStation, train.LastStation);
    }

    [Test]
    public async Task CreateTrain_NotExisting()
    {
        var model = new TrainModel(){
            TrainNumber = "number",
            FirstStation = "first",
            LastStation  =  "last"
        };
        var addTrain = trainService.AddTrain(model);

        Assert.Throws<Exception>( ()=>
        {
            trainService.AddTrain(model);
        });   
    }
}