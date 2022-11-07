using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Resource;
namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Validator
{
    public class GroupSearchPayloadValidator : AbstractValidator<GroupPagedSearchPayload>
    {
        public GroupSearchPayloadValidator()
        {
            RuleFor(x => x.Description)
                    .MaximumLength(30)
                    .WithMessage(ErrorCodes.ME0402)
                     .WithErrorCode(nameof(ErrorCodes.ME0402))
              .WithName(PropertyName.Description);
        }
    }
}
