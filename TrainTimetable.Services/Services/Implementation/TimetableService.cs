using AutoMapper;
using TrainTimetable.Entities.Models;
using TrainTimetable.Repository;
using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Implementation;

public class TimetableService : ITimetableService
{
    private readonly IRepository<Timetable> timetablesRepository;
    private readonly IMapper mapper;
    public TimetableService(IRepository<Timetable> timetablesRepository, IMapper mapper)
    {
        this.timetablesRepository = timetablesRepository;
        this.mapper = mapper;
    }

    public void DeleteTimetable(Guid id)
    {
        var timetableToDelete = timetablesRepository.GetById(id);
        if (timetableToDelete == null)
        {
            throw new Exception("Timetable not found"); 
        }

        timetablesRepository.Delete(timetableToDelete);
    }

    public TimetableModel GetTimetable(Guid id)
    {
        var timetable = timetablesRepository.GetById(id);
         if (timetable == null)
        {
            throw new Exception("Timetable not found"); 
        }
        return mapper.Map<TimetableModel>(timetable);
    }

    public PageModel<TimetablePreviewModel> GetTimetables(int limit = 20, int offset = 0)
    {
        var timetables = timetablesRepository.GetAll();
        int totalCount = timetables.Count();
        var chunk = timetables.OrderBy(x => x.TrainNumber).Skip(offset).Take(limit);

        return new PageModel<TimetablePreviewModel>()
        { 
            Items = mapper.Map<IEnumerable<TimetablePreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    TimetableModel ITimetableService.AddTimetable(TimetableModel timetableModel)
    {
        timetablesRepository.Save(mapper.Map<Entities.Models.Timetable>(timetableModel));
        return timetableModel;
    }

    public TimetableModel UpdateTimetable(Guid id, UpdateTimetableModel timetable)
    {
        var existingTimetable = timetablesRepository.GetById(id);
        if (existingTimetable == null)
        {
            throw new Exception("Timetable not found");
        }

        existingTimetable.ArrivalTime= timetable.ArrivalTime;
        existingTimetable.DepartureTime= timetable.DepartureTime;
        existingTimetable.Station= timetable.Station;
        existingTimetable.TrainNumber= timetable.TrainNumber;

        existingTimetable = timetablesRepository.Save(existingTimetable);
        return mapper.Map<TimetableModel>(existingTimetable);
    }
}