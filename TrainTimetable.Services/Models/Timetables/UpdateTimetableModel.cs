using TrainTimetable.Entities.Models;

namespace TrainTimetable.Services.Models;

public class UpdateTimetableModel
{
    public DateTime ArrivalTime { get; set; }
    public DateTime DepartureTime { get; set; }
    public string Station { get; set; }
    public string TrainNumber { get; set; }
}