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
    public class DeleteUseCasesValidator : AbstractValidator<RoleUseCaseCommandsDto>
    {
        private readonly BookStoreContext _context;
        public DeleteUseCasesValidator(BookStoreContext context)
        {
            _context = context;
            var admin = context.Roles.FirstOrDefault(x => x.Name == "Administrator");
            RuleFor(x => x.RoleId)
                                 .NotEmpty()
                                 .WithMessage("Role id is required")
                                 .Must(id => id != admin.Id)
                                 .WithMessage("You can't remove admins use cases")
                                 .Must(id => _context.RoleUseCases.Any(x => x.RoleId == id))
                                 .WithMessage("Role with this id doesn't have any Use Cases");
            RuleFor(x => x.UseCasesIds)
                                    .NotEmpty()
                                    .WithMessage("Use cases are required");
            RuleFor(dto => dto)
                        .Must((dto) => ValidUseCases(dto.UseCasesIds, dto.RoleId))
                        .WithMessage("These combination of ids and roles doesn't exist")
                        .OverridePropertyName("RoleId and UseCasesIds");
        }
        private bool ValidUseCases(IEnumerable<int> ids, int roleId)
        {
            return ids.All(id => _context.RoleUseCases.Any(rc => rc.UseCaseId == id && rc.RoleId == roleId));
        }
    }
}
