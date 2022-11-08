using Microsoft.EntityFrameworkCore;
using TrainTimetable.Entities.Models;

namespace TrainTimetable.Entities;
public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Timetable> Timetables { get; set; }
    public DbSet<Train> Trains { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);
        builder.Entity<User>().HasOne(x => x.Role)
                                .WithMany(x => x.Users)
                                .HasForeignKey(x => x.RoleId)
                                .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Roles

        builder.Entity<Role>().ToTable("roles");
        builder.Entity<Role>().HasKey(x => x.Id);

        #endregion

        #region Tickets

        builder.Entity<Ticket>().ToTable("tickets");
        builder.Entity<Ticket>().HasKey(x => x.Id);
        builder.Entity<Ticket>().HasOne(x => x.Train)
                                .WithMany(x => x.Tickets)
                                .HasForeignKey(x => x.TrainId)
                                .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Ticket>().HasOne(x => x.Timetable)
                                .WithMany(x => x.Tickets)
                                .HasForeignKey(x => x.TimetableId)
                                .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Ticket>().HasOne(x => x.User)
                                .WithMany(x => x.Tickets)
                                .HasForeignKey(x => x.UserId)
                                .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Timetables

        builder.Entity<Timetable>().ToTable("timetables");
        builder.Entity<Timetable>().HasKey(x => x.Id);

        #endregion

        #region Trains

        builder.Entity<Train>().ToTable("trains");
        builder.Entity<Train>().HasKey(x => x.Id);

        #endregion
    }
}
