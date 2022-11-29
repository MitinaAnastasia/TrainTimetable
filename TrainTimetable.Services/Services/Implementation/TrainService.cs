using AutoMapper;
using TrainTimetable.Entities.Models;
using TrainTimetable.Repository;
using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Implementation;

public class TrainService : ITrainService
{
    private readonly IRepository<Train> trainsRepository;
    private readonly IMapper mapper;
    public TrainService(IRepository<Train> trainsRepository, IMapper mapper)
    {
        this.trainsRepository = trainsRepository;
        this.mapper = mapper;
    }

    public void DeleteTrain(Guid id)
    {
        var trainToDelete = trainsRepository.GetById(id);
        if (trainToDelete == null)
        {
            throw new Exception("Train not found"); 
        }

        trainsRepository.Delete(trainToDelete);
    }

    public TrainModel GetTrain(Guid id)
    {
        var train = trainsRepository.GetById(id);
         if (train == null)
        {
            throw new Exception("Train not found"); 
        }
        return mapper.Map<TrainModel>(train);
    }

    public PageModel<TrainPreviewModel> GetTrains(int limit = 20, int offset = 0)
    {
        var trains = trainsRepository.GetAll();
        int totalCount = trains.Count();
        var chunk = trains.OrderBy(x => x.TrainNumber).Skip(offset).Take(limit);

        return new PageModel<TrainPreviewModel>()
        {
           
            Items = mapper.Map<IEnumerable<TrainPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    TrainModel ITrainService.AddTrain(TrainModel trainModel)
    {
        trainsRepository.Save(mapper.Map<Entities.Models.Train>(trainModel));
        return trainModel;
    }


    public TrainModel UpdateTrain(Guid id, UpdateTrainModel train)
    {
        var existingTrain = trainsRepository.GetById(id);
        if (existingTrain == null)
        {
            throw new Exception("Train not found");
        }

        existingTrain.TrainNumber= train.TrainNumber;

        existingTrain = trainsRepository.Save(existingTrain);
        return mapper.Map<TrainModel>(existingTrain);
    }
}