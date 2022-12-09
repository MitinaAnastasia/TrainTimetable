using TrainTimetable.Shared.Exceptions;
using TrainTimetable.WebAPI.Models;

namespace TrainTimetable.WebAPI.Extensions;

public static class ExceptionExtensions
{
    public static ErrorResponse ToErrorResponse(this LogicException exception)
    {
        return new ErrorResponse(exception.Code!);
    }

    public static ErrorResponse ToErrorResponse(this RepositoryException exception)
    {
        return new ErrorResponse(exception.Code!);
    }
}