using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Abstract;

public interface ITicketService
{
    TicketModel GetTicket(Guid id);

    TicketModel UpdateTicket(Guid id, UpdateTicketModel ticket);
    TicketModel AddTicket(Guid TimetableId, Guid TrainId, Guid UserId, TicketModel ticketModel);

    void DeleteTicket(Guid id);

    PageModel<TicketModel> GetTickets(int limit = 20, int offset = 0);
}