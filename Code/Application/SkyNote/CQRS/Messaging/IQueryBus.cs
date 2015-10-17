using CQRS.Queries;

namespace CQRS.Messaging
{
    public interface IQueryBus
    {
        TResult Retrieve<TParameter, TResult>(TParameter query) where TParameter : IQuery where TResult : IQueryResult;
    }
}
