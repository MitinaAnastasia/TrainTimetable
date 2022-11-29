using AutoMapper;
using TrainTimetable.Entities.Models;
using TrainTimetable.Repository;
using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Implementation;

public class TicketService : ITicketService
{
    private readonly IRepository<Ticket> ticketsRepository;
    private readonly IMapper mapper;

    public TicketService(IRepository<Ticket> ticketsRepository, IMapper mapper)
    {
        this.ticketsRepository = ticketsRepository;
        this.mapper = mapper;
    }

    public void DeleteTicket(Guid id)
    {
        var ticketToDelete = ticketsRepository.GetById(id);
        if (ticketToDelete == null)
        {
            throw new Exception("Ticket not found"); 
        }

        ticketsRepository.Delete(ticketToDelete);
    }

    public TicketModel GetTicket(Guid id)
    {
        var ticket = ticketsRepository.GetById(id);
         if (ticket == null)
        {
            throw new Exception("Ticket not found"); 
        }
        return mapper.Map<TicketModel>(ticket);
    }

    public PageModel<TicketModel> GetTickets(int limit = 20, int offset = 0)
    {
        var tickets = ticketsRepository.GetAll();
        int totalCount = tickets.Count();
        var chunk = tickets.OrderBy(x => x.PlaceNumber).Skip(offset).Take(limit);

        return new PageModel<TicketModel>()
        {
           
            Items = mapper.Map<IEnumerable<TicketModel>>(chunk),
            TotalCount = totalCount
        };
    }

    TicketModel ITicketService.AddTicket(TicketModel ticketModel)
    {
        var ticket = mapper.Map<Entities.Models.Ticket>(ticketModel);
        return mapper.Map<TicketModel>(ticketsRepository.Save(ticket));
    }

    public TicketModel UpdateTicket(Guid id, UpdateTicketModel ticket)
    {
        var existingTicket = ticketsRepository.GetById(id);
        if (existingTicket == null)
        {
            throw new Exception("Ticket not found");
        }

        existingTicket.PlaceNumber= ticket.PlaceNumber;

        existingTicket = ticketsRepository.Save(existingTicket);
        return mapper.Map<TicketModel>(existingTicket);
    }
}