using CQRS.Queries;
using CQRS.Utils;

namespace CQRS.Messaging
{
    public class QueryBus : IQueryBus
    {
        private IQueryHandlerFactory queryHandlerFactory;

        public QueryBus(IQueryHandlerFactory queryHandlerFactory)
        {
            this.queryHandlerFactory = queryHandlerFactory;
        }

        public TResult Retrieve<TParameter, TResult>(TParameter query) where TParameter : IQuery where TResult : IQueryResult
        {
            var handler = queryHandlerFactory.GetHandler<TParameter, TResult>();
            
            return handler.Handle(query);
            
        }
    }
}
