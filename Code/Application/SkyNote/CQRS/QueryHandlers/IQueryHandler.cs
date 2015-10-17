using CQRS.Queries;

namespace CQRS.QueryHandlers
{
    public interface IQueryHandler<in TParameter, out TResult> where TResult : IQueryResult where TParameter : IQuery
    {
        TResult Handle(TParameter handle);
    }
}
