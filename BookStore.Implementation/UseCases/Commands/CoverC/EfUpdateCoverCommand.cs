using BookStore.Application.UseCases.Commands.CoverC;
using BookStore.Application.UseCases.DTO.CoverDTOs;
using BookStore.Application.UseCases.Exceptions;
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
    public class EfUpdateCoverCommand : EfUseCase, IUpdateCoverCommand
    {
        public UpdateCoverValidator _validator;
        public EfUpdateCoverCommand(BookStoreContext context, UpdateCoverValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Update cover";

        public string Description => "Update cover name";

        public void Execute(UpdateCoverDto request)
        {
            var cover = Context.Covers.Find(request.Id);
            if(cover == null)
            {
                throw new EntityNotFoundException(request.Id, nameof(Cover));
            }
            _validator.ValidateAndThrow(request);
            cover.CoverType = request.Name;
            cover.ModifiedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
