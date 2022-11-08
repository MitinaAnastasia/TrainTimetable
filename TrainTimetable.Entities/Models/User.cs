namespace TrainTimetable.Entities.Models;

public class User : BaseEntity
{
    public string PasswordHash { get; set; }
    public string Login { get; set; }
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
}