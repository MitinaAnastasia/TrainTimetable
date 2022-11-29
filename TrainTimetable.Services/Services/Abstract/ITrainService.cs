using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Abstract;

public interface ITrainService
{
    TrainModel GetTrain(Guid id);

    TrainModel UpdateTrain(Guid id, UpdateTrainModel train);
    TrainModel AddTrain (TrainModel trainModel);

    void DeleteTrain(Guid id);

    PageModel<TrainPreviewModel> GetTrains(int limit = 20, int offset = 0);
}