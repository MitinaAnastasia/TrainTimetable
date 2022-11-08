namespace TrainTimetable.Entities.Models;

public class Ticket : BaseEntity
{
    public uint PlaceNumber { get; set; }
    public Guid TrainId { get; set; }
    public Guid TimetableId { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual Train Train { get; set; } 
    public virtual Timetable Timetable { get; set; }
}