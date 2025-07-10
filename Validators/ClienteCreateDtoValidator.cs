using PedidosApi.Models.DTOs;

namespace PedidosApi.Validators;

using FluentValidation;
using PedidosApi.Models.DTOs;

public class ClienteCreateDtoValidator : AbstractValidator<ClienteCreateDto>
{
    public ClienteCreateDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório.")
            .Length(2, 100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Por favor, informe um email válido.");
    }
    
}