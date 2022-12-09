using Microsoft.AspNetCore.Identity;
namespace TrainTimetable.Entities.Models;

public class Role : BaseEntity
{   
    public string RoleName { get; set; }
    public virtual ICollection<User> Users { get; set; }

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
}