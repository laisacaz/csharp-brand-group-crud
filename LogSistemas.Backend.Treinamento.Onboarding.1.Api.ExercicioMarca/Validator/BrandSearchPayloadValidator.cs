using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;

using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Resource;
namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Validator
{
    public class BrandSearchPayloadValidator : AbstractValidator<BrandPagedSearchPayload>
    {
        public BrandSearchPayloadValidator()
        {

            RuleFor(x => x.Description)
                .MaximumLength(30)
                .WithMessage(ErrorCodes.ME0402)
                 .WithErrorCode(nameof(ErrorCodes.ME0402))
              .WithName(PropertyName.Description);

            RuleFor(x => x.MainSupplier)
                .MaximumLength(150)
                .WithMessage(ErrorCodes.ME0402)
                 .WithErrorCode(nameof(ErrorCodes.ME0402))
              .WithName(PropertyName.MainSupplier);

        }
    }
}
