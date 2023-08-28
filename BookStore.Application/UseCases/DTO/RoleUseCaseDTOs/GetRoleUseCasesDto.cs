using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.RoleUseCaseDTOs
{
    public class GetRoleUseCasesDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int UseCaseId { get; set; }
        public string UseCaseName { get; set; }

    }
}
