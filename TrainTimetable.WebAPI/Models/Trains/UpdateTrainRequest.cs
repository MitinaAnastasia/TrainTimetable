using FluentValidation;
using FluentValidation.Results;

namespace TrainTimetable.WebAPI.Models;

public class UpdateTrainRequest
{
    #region Model

    public string TrainNumber { get; set; }
    public string FirstStation { get; set; }
    public string LastStation { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateTrainRequest>
    {
        public Validator()
        {
            RuleFor(x => x.TrainNumber)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.FirstStation)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.LastStation)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateTrainRequestExtension
{
    public static ValidationResult Validate(this UpdateTrainRequest model)
    {
        return new UpdateTrainRequest.Validator().Validate(model);
    }
}