using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO
{
    public class SearchLogDto
    {
        public int? ActorId { get; set; }
        public string ActorUserName { get; set; }
        public string UseCaseKeyword { get; set; }
    }
}
