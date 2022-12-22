using TrainTimetable.Entities.Models;
using TrainTimetable.Repository;
using TrainTimetable.Services.Abstract;
using NUnit.Framework;

namespace TrainTimetable.Test;

[TestFixture]
public partial class TrainTests : UnitTest
{
    private  ITrainService trainService;
    private  IRepository<Entities.Models.Train> trainRepository;
    
    public async override Task OneTimeSetUp()
    {
        await base.OneTimeSetUp();
        trainService = services.Get<ITrainService>();
        trainRepository = services.Get<IRepository<Entities.Models.Train>>();
    }

    protected async override Task ClearDb()
    {
        var trainRepository = services.Get<IRepository<Entities.Models.Train>>();
        var trains = trainRepository.GetAll().ToList();
        foreach(var train in trains)
        {
            trainRepository.Delete(train);
        }
    }

}
