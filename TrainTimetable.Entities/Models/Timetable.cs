namespace TrainTimetable.Entities.Models;

public class Timetable : BaseEntity
{
    public DateTime ArrivalTime { get; set; }
    public DateTime DepartureTime { get; set; }
    public string Station { get; set; }
    public string TrainNumber { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
}