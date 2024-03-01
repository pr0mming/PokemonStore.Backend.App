﻿using FluentValidation;
using PokemonStore.Backend.Application.Products.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStore.Backend.Application.Products.Commands.EditProduct
{
    internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("The Product Name is required")
                .MinimumLength(5).WithMessage("The Product Name Minimum Length is 5 characters")
                .MaximumLength(150).WithMessage("The Product Name Maximum Length is 5 characters");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("The Product Description is required")
                .MinimumLength(5).WithMessage("The Product Description Minimum Length is 20 characters")
                .MaximumLength(850).WithMessage("The Product Description Maximum Length is 850 characters");

            RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("The Product Price must have greater than 0")
                .LessThan(9999).WithMessage("The Product Price must have less than 9999");
        }
    }
}
