using BookStore.Application.UseCases.Commands.CoverC;
using BookStore.Application.UseCases.DTO.CoverDTOs;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.CoverValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.CoverC
{
    public class EfAddCoverCommand : EfUseCase, IAddCoverCommand
    {
        private AddCoverValidator _validator;
        public EfAddCoverCommand(BookStoreContext context, AddCoverValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Add cover";

        public string Description => "Adding cover command";

        public void Execute(AddCoverDto request)
        {
            _validator.ValidateAndThrow(request);
            var cover = new Cover
            {
                CoverType = request.Name,
                CreatedAt = DateTime.UtcNow
            };
            Context.Covers.Add(cover);
            Context.SaveChanges();
        }
    }
}
