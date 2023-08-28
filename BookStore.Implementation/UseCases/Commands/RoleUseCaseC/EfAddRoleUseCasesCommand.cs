using BookStore.Application.UseCases.Commands.RoleUseCaseC;
using BookStore.Application.UseCases.DTO.RoleUseCaseDTOs;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.UseCaseValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.RoleUseCaseC
{
    public class EfAddRoleUseCasesCommand : EfUseCase, IAddRoleUseCasesCommand
    {
        private readonly AddUseCasesValidator _validator;
        public EfAddRoleUseCasesCommand(BookStoreContext context,AddUseCasesValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "Add role use case";

        public string Description => "Add role use cases";

        public void Execute(RoleUseCaseCommandsDto dto)
        {
            _validator.ValidateAndThrow(dto);
            var useCases = dto.UseCasesIds.Select(ucId => new RoleUseCase
            {
                RoleId = dto.RoleId,
                UseCaseId = ucId
            }).ToList();
            Context.RoleUseCases.AddRange(useCases);
            Context.SaveChanges();
        }
    }
}
