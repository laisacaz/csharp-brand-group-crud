using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Resource;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Validator
{
    public class BrandInsertPayloadValidator : AbstractValidator<BrandInsertPayload>
    {
        public BrandInsertPayloadValidator()
        {


            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ErrorCodes.ME0401)
                .WithErrorCode(nameof(ErrorCodes.ME0401))
                .MaximumLength(30)
                .WithMessage(ErrorCodes.ME0402)
                 .WithErrorCode(nameof(ErrorCodes.ME0402))
            .WithName(PropertyName.Description);

            RuleFor(x => x.MainSupplier)
                .NotEmpty()
                .WithMessage(ErrorCodes.ME0401)
                 .WithErrorCode(nameof(ErrorCodes.ME0401))
                .MaximumLength(150)
                .WithMessage(ErrorCodes.ME0404)
                 .WithErrorCode(nameof(ErrorCodes.ME0404))
            .WithName(PropertyName.MainSupplier);

            RuleFor(x => x.Since)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage(ErrorCodes.ME0403)
                 .WithErrorCode(nameof(ErrorCodes.ME0403))
            .WithName(PropertyName.Since);



        }

    }
}
