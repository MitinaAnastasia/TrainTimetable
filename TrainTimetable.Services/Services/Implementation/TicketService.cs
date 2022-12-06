using AutoMapper;
using TrainTimetable.Entities.Models;
using TrainTimetable.Repository;
using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Implementation;

public class TicketService : ITicketService
{
    private readonly IRepository<Ticket> ticketsRepository;
    private readonly IRepository<Train> trainsRepository;
    private readonly IRepository<User> usersRepository;
    private readonly IRepository<Timetable> timetablesRepository;
    private readonly IMapper mapper;

    public TicketService(IRepository<Ticket> ticketsRepository, IRepository<Train> trainsRepository, IRepository<User> usersRepositor,
     IRepository<Timetable> timetablesRepository, IMapper mapper)
    {
        this.ticketsRepository = ticketsRepository;
        this.trainsRepository = trainsRepository;
        this.usersRepository = usersRepositor;
        this.timetablesRepository = timetablesRepository;
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

    TicketModel ITicketService.AddTicket(Guid TimetableId, Guid TrainId, Guid UserId, TicketModel ticketModel)
    {
        if(ticketsRepository.GetAll(x => x.Id == ticketModel.Id).FirstOrDefault()!=null)
        {
            throw new Exception ("Attempt to create a non-unique object!");
        }

        if(trainsRepository.GetAll(x => x.Id == ticketModel.TrainId).FirstOrDefault() == null)
        {
            throw new Exception ("The object does not exist in the database!");
        }

         if(usersRepository.GetAll(x => x.Id == ticketModel.UserId).FirstOrDefault() == null)
        {
            throw new Exception ("The object does not exist in the database!");
        }

         if(timetablesRepository.GetAll(x => x.Id == ticketModel.TimetableId).FirstOrDefault() == null)
        {
            throw new Exception ("The object does not exist in the database!");
        }
        
        TicketModel createTicket = new TicketModel();
        createTicket.TimetableId = ticketModel.TimetableId;
        createTicket.TrainId = ticketModel.TrainId;
        createTicket.UserId = ticketModel.UserId;
        createTicket.PlaceNumber = ticketModel.PlaceNumber;
        ticketsRepository.Save(mapper.Map<Ticket>(createTicket));

        return createTicket;
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