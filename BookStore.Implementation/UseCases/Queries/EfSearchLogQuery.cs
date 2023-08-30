using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.Queries;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries
{
    public class EfSearchLogQuery : EfUseCase, ISearchLogQuery
    {
        public EfSearchLogQuery(BookStoreContext context) 
            : base(context)
        {
        }

        public int Id => 42;

        public string Name => "Search log";

        public string Description => "Search log by keyword";

        public IEnumerable<GetLogsDto> Execute(SearchLogDto search)
        {
            if (search == null)
            {
                return new List<GetLogsDto>();
            }
            var logs = Context.LogEntries.AsQueryable();
            if (search.ActorId.HasValue)
            {
                logs = logs.Where(x => x.ActorId == search.ActorId);
            }
            if(search.UseCaseKeyword != null)
            {
                logs = logs.Where(x => x.UseCaseName.Contains(search.UseCaseKeyword));
            }
            if(search.ActorUserName != null)
            {
                logs = logs.Where(x => x.Actor.Contains(search.ActorUserName));
            }
            return logs.Select(x => new GetLogsDto
            {
                IdLog = x.Id,
                ActorId = x.ActorId,
                Actor = x.Actor,
                UseCaseName = x.UseCaseName,
                UseCaseData = x.UseCaseData,
                CreatedAt = (DateTime)x.CreatedAt
            }).OrderByDescending(x=> x.IdLog);
        }
    }
}
