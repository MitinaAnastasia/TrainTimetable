namespace TrainTimetable.WebAPI.Models;

public class TrainResponse
{
    public Guid Id { get; set; }
    public string TrainNumber { get; set; }
    public string FirstStation { get; set; }
    public string LastStation { get; set; }
}