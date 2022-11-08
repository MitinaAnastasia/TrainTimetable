namespace TrainTimetable.Entities.Models;

public class Role : BaseEntity
{   
    public string RoleName { get; set; }
    public virtual ICollection<User> Users { get; set; }
}