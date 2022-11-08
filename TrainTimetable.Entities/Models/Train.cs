namespace TrainTimetable.Entities.Models;

public class Train : BaseEntity
{
    public string TrainNumber { get; set; }
    public string FirstStation { get; set; }
    public string LastStation { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
}