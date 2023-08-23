using BookStore.Application.UseCases.DTO.CoverDTOs;
using BookStore.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.CoverQ
{
    public interface IGetCoverQuery : IQuery<CoverSearch, IEnumerable<GetCoverDto>>
    {
    }
}
