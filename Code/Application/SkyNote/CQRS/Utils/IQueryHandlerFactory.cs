using CQRS.Queries;
using CQRS.QueryHandlers;

namespace CQRS.Utils
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TParameter, TResult> GetHandler<TParameter, TResult>()
            where TResult : IQueryResult
            where TParameter : IQuery;

    }
}
