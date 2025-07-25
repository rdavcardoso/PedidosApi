﻿using PedidosApi.Models.DTOs;

namespace PedidosApi.Validators;

using FluentValidation;
using PedidosApi.Models.DTOs;

public class PedidoCreateDtoValidator : AbstractValidator<PedidoCreateDto>
{
    public PedidoCreateDtoValidator()
    {
        RuleFor(p => p.Data)
            .NotEmpty().WithMessage("A data do pedido é obrigatória.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("A data não pode estar no futuro.");

        RuleFor(p => p.ClienteId)
            .GreaterThan(0).WithMessage("O Id do cliente deve ser maior que zero.");

        RuleFor(p => p.ProdutosIds)
            .NotNull().WithMessage("A lista de produtos não pode ser nula.")
            .Must(p => p.Count > 0).WithMessage("É necessário ao menos um produto.");

        RuleForEach<int>(p => p.ProdutosIds)
            .GreaterThan(0).WithMessage("Cada ID de produto deve ser maior que zero.");

        RuleFor(p => p.ProdutosIds)
            .Must(produtos => produtos.Distinct().Count() == produtos.Count)
            .WithMessage("A lista de produtos não pode conter duplicatas.");
    }
    
}