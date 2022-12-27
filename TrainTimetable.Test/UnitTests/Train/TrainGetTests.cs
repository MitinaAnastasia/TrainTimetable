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
    public async Task GetTrain_Success()
    {
        var model = new TrainModel(){
            TrainNumber = "8DS",
            FirstStation = "SPB",
            LastStation  = "Kursk"
        };
        
        var newTrain = trainService.AddTrain(model);
        var train = trainService.GetTrain(newTrain.Id);

        Assert.AreEqual(model.TrainNumber, train.TrainNumber);
        Assert.AreEqual(model.FirstStation, train.FirstStation);
        Assert.AreEqual(model.LastStation, train.LastStation);
    }

    [Test]
    public async Task GetTrain_NotExisting()
    {
        var trainId = Guid.NewGuid();

        Assert.Throws<Exception>( ()=>
        {
            trainService.GetTrain(trainId);
        }); 
    }
}