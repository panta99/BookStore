using BookStore.Application.UseCases.DTO.RoleUseCaseDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.UseCaseValidators
{
    public class AddUseCasesValidator : AbstractValidator<RoleUseCaseCommandsDto>
    {
        private readonly BookStoreContext _context;
        public AddUseCasesValidator(BookStoreContext context)
        {
            _context = context;

            RuleFor(x => x.RoleId)
                                 .NotEmpty()
                                 .WithMessage("Role id is required")
                                 .Must(x => context.Roles.Any(y => y.Id == x))
                                 .WithMessage("Invalid role id");
            RuleFor(x => x.UseCasesIds)
                                    .NotEmpty()
                                    .WithMessage("Use cases are required");
            RuleFor(dto => dto)
                             .Must((dto) => UniqueRoleUseCase(dto.RoleId, dto.UseCasesIds))
                             .OverridePropertyName("Rule id and Use Cases ids")
                             .WithMessage("Role and Use Cases combination already exsits");
        }
        private bool UniqueRoleUseCase(int roleId, IEnumerable<int> useCasesIds)
        {
            foreach(var useCaseId in useCasesIds)
            {
                if(_context.RoleUseCases.Any(rc=> rc.RoleId == roleId && rc.UseCaseId == useCaseId))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
