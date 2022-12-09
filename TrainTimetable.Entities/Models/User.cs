using Microsoft.AspNetCore.Identity;
namespace TrainTimetable.Entities.Models;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public string PasswordHash { get; set; }
    public string Login { get; set; }
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }

     #region BaseEntity

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }

    #endregion    
}

public class UserRole : IdentityRole<Guid>
{
}