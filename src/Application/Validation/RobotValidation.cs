namespace Api.Megaman.Application.Validation
{
    using Api.Megaman.Application.DTO;
    using FluentValidation;
    using System;
    public class RobotValidation : AbstractValidator<RobotCreateDTO>
    {
        public RobotValidation() 
        {
            RuleFor(e => e.Name).NotNull().WithMessage("O campo nome deve ser informado.")
                .MinimumLength(5).WithMessage("O campo name deve ter no mínimo 5 caracteres.")
                .MaximumLength(80).WithMessage("O campo name deve ter no máximo 80 caracteres.");

            RuleFor(e => e.Code).NotNull().WithMessage("O campo código deve ser informado.")
                .MinimumLength(2).WithMessage("O campo descrição deve ter no mínimo 2 caracteres.")
                .MaximumLength(20).WithMessage("O campo descrição deve ter no máximo 20 caracteres.");

            RuleFor(e => e.Picture).MaximumLength(200).WithMessage("O campo longitude deve ter no máximo 200 caracteres.");
        }
    }
}
