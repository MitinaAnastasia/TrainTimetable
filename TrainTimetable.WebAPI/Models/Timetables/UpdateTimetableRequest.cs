using FluentValidation;
using FluentValidation.Results;

namespace TrainTimetable.WebAPI.Models;

public class UpdateTimetableRequest
{
    #region Model

    public DateTime ArrivalTime { get; set; }
    public DateTime DepartureTime { get; set; }
    public string Station { get; set; }
    public string TrainNumber { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateTimetableRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Station)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.TrainNumber)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.ArrivalTime).
            InclusiveBetween(DateTime.MinValue,DateTime.MaxValue).WithMessage("DateTime must be between DateTime.MinValue and DateTime.MaxValue");
            RuleFor(x => x.DepartureTime).
            InclusiveBetween(DateTime.MinValue,DateTime.MaxValue).WithMessage("DateTime must be between DateTime.MinValue and DateTime.MaxValue");
        }
    }

    #endregion
}

public static class UpdateTimetableRequestExtension
{
    public static ValidationResult Validate(this UpdateTimetableRequest model)
    {
        return new UpdateTimetableRequest.Validator().Validate(model);
    }
}