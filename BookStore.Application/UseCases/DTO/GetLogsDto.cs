using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO
{
    public class GetLogsDto
    {
        public int IdLog { get; set; }
        public string Actor { get; set; }
        public int ActorId { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
