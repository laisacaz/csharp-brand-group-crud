using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Resource;
namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Validator
{
    public class GroupUpdatePayloadValidator : AbstractValidator<GroupUpdatePayload>
    {
        public GroupUpdatePayloadValidator(GroupRepository repository)
        {

            RuleFor(x => x.GetId())
                .Must(x => x > 0)
                .WithMessage(ErrorCodes.ME0404)
                 .WithErrorCode(nameof(ErrorCodes.ME0404))
                .MustAsync(async (x, token) =>
                await repository.IdExists(x) == true)
                .WithMessage(ErrorCodes.ME0405)
                 .WithErrorCode(nameof(ErrorCodes.ME0405));

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ErrorCodes.ME0401)
                 .WithErrorCode(nameof(ErrorCodes.ME0401))
                .MaximumLength(30)
                .WithMessage(ErrorCodes.ME0402)
                 .WithErrorCode(nameof(ErrorCodes.ME0402))
              .WithName(PropertyName.Description);

            RuleFor(x => x.Since)
             .LessThanOrEqualTo(DateTime.Now)
             .WithMessage(ErrorCodes.ME0403)
              .WithErrorCode(nameof(ErrorCodes.ME0403))
              .WithName(PropertyName.Since);
        }
    }
}
