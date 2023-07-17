using BookStore.Application.UseCases.DTO.YearPublishedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.YearPublishedQ
{
    public interface IGetYearPublishedQuery : IQuery<int?,IEnumerable<GetYearPublishedDto>>
    {
    }
}
