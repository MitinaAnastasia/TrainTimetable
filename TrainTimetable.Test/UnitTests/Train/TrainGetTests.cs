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

        var trainId = new Guid("E40B66BC-84CE-407D-A3B4-033A340D1E68");
        var train = trainService.GetTrain(trainId);

        Assert.AreEqual(model.TrainNumber, train.TrainNumber);
        Assert.AreEqual(model.FirstStation, train.FirstStation);
        Assert.AreEqual(model.LastStation, train.LastStation);
    }

    [Test]
    public async Task GetTrain_NotExisting()
    {
        var trainId = new Guid("E40B66BC-84CE-407D-A3B4-033A340D1E68");

        Assert.Throws<Exception>( ()=>
        {
            trainService.GetTrain(trainId);
        });   
    }
}