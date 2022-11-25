using FluentValidation;
using FluentValidation.Results;

namespace TrainTimetable.WebAPI.Models;

public class UpdateTicketRequest
{
    #region Model

    public uint PlaceNumber { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateTicketRequest>
    {
        public Validator()
        {
            RuleFor(x => x.PlaceNumber)
                .LessThan(uint.MaxValue).WithMessage("Length must be less than uint.MaxValue");
        }
    }

    #endregion
}

public static class UpdateTicketRequestExtension
{
    public static ValidationResult Validate(this UpdateTicketRequest model)
    {
        return new UpdateTicketRequest.Validator().Validate(model);
    }
}