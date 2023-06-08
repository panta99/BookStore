using AutoMapper;
using BookStore.Application.UseCases.Commands;
using BookStore.Application.UseCases.DTO;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.Author1
{
    public class EfAddAuthorCommand : EfUseCase, IAddAuthorCommand
    {
        protected readonly IMapper _mapper;
        private AddAuthorValidator _validator;
        public EfAddAuthorCommand(BookStoreContext context,AddAuthorValidator validator, IMapper mapper) 
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Add author";

        public string Description => "";

        public void Execute(AddAuthorDto request)
        {
            _validator.ValidateAndThrow(request);
            var author = _mapper.Map<Author>(request);
            Context.Add(author);
            Context.SaveChanges();
        }
    }
}
