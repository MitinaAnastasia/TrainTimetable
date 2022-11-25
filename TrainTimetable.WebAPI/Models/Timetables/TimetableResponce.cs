namespace TrainTimetable.WebAPI.Models;

public class TimetableResponse
{
    public Guid Id { get; set; }
    public DateTime ArrivalTime { get; set; }
    public DateTime DepartureTime { get; set; }
    public string Station { get; set; }
    public string TrainNumber { get; set; }
}