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
    public class EfDeleteRoleUseCasesCommand : EfUseCase,IDeleteRoleUseCasesCommand
    {
        private readonly DeleteUseCasesValidator _validator;

        public EfDeleteRoleUseCasesCommand(BookStoreContext context, DeleteUseCasesValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 33;

        public string Name => "Delete role use cases";

        public string Description => "Delete role use cases";

        public void Execute(RoleUseCaseCommandsDto dto)
        {
            _validator.ValidateAndThrow(dto);
            var forRemove = dto.UseCasesIds.Select(x => new RoleUseCase
            {
                RoleId = dto.RoleId,
                UseCaseId = x
            });
            Context.RemoveRange(forRemove);
            Context.SaveChanges();
        }
    }
}
