using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TestWebApplication.Domain.Book.Models;

namespace TestWebApplication.Domain.Book.Validators
{
    public class BookRequestValidation<T> : AbstractValidator<T> where T : BookFieldsRequest
    {
        public BookRequestValidation()
        {
            ValidateName();
            ValidateAuthor();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .Length(2, 100).WithMessage($"The Name must have between 2 and 50 characters");
        }

        private void ValidateAuthor()
        {
            RuleFor(c => c.Author)
                .Length(2, 100).WithMessage($"The Name must have between 2 and 50 characters")
                .When(x => !string.IsNullOrEmpty(x.Author));
        }
    }
}
