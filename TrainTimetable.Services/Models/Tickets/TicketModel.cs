using TrainTimetable.Entities.Models;

namespace TrainTimetable.Services.Models;

public class TicketModel : BaseModel
{
   public Guid UserId { get; set; }
   public Guid TrainId { get; set; }
   public Guid TimetableId { get; set; }
   public uint PlaceNumber { get; set; }
   
}