using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.RoleUseCaseDTOs
{
    public class RoleUseCaseCommandsDto
    {
        public int RoleId { get; set; }
        public IEnumerable<int> UseCasesIds { get; set; }
    }
}
