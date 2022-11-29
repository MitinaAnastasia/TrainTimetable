namespace TrainTimetable.WebAPI.Models;

public class TicketResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TrainId { get; set; }
    public Guid TimetableId { get; set; }
    public uint PlaceNumber { get; set; }
}