using TrainTimetable.Entities.Models;

namespace TrainTimetable.Services.Models;

public class UpdateTrainModel
{
    public string TrainNumber { get; set; }
    public string FirstStation { get; set; }
    public string LastStation { get; set; }
}