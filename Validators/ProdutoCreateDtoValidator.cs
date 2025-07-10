using PedidosApi.Models.DTOs;

namespace PedidosApi.Validators;

using FluentValidation;
using PedidosApi.Models.DTOs;

public class ProdutoCreateDtoValidator : AbstractValidator<ProdutoCreateDto>
{
    public ProdutoCreateDtoValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres");

        RuleFor(p => p.Preco)
            .GreaterThan(0).WithMessage("O preço deve ser maior que 0.");

        RuleFor(p => p.Quantidade)
            .GreaterThanOrEqualTo(0).WithMessage("O estoque não pode ser negativo.");
    }
        
}