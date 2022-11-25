namespace TrainTimetable.WebAPI.Models;

public class TimetablePreviewResponse
{
    public Guid Id { get; set; }
    public string Station { get; set; }
    public string TrainNumber { get; set; }
}