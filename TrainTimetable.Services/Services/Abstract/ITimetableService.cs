using TrainTimetable.Services.Models;

namespace TrainTimetable.Services.Abstract;

public interface ITimetableService
{
    TimetableModel GetTimetable(Guid id);

    TimetableModel UpdateTimetable(Guid id, UpdateTimetableModel timetable);

    void DeleteTimetable(Guid id);

    PageModel<TimetablePreviewModel> GetTimetables(int limit = 20, int offset = 0);
}