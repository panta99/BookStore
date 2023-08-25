using BookStore.Application.UseCases.DTO.PublisherDTOs;
using BookStore.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.PublisherQ
{
    public interface IGetPublishersQuery : IQuery<PublisherSearch, IEnumerable<GetPublisherDto>>
    {
    }
}
