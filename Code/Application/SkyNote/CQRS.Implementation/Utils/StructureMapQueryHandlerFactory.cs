using CQRS.CommandHandlers;
using CQRS.Queries;
using CQRS.QueryHandlers;
using CQRS.Utils;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CQRS.Implementation.Utils
{
    public class StructureMapQueryHandlerFactory : IQueryHandlerFactory
    {
        public IQueryHandler<TParameter, TResult> GetHandler<TParameter, TResult>() where TParameter : IQuery where TResult : IQueryResult
        {
            var handlers = GetHandlerTypes<TParameter, TResult>().ToList();

            var cmdHandler = handlers.Select(handler =>

#pragma warning disable CS0618 // Type or member is obsolete
                (IQueryHandler<TParameter, TResult>)ObjectFactory.GetInstance(handler)).FirstOrDefault();
#pragma warning restore CS0618 // Type or member is obsolete

            return cmdHandler;
        }

        private IEnumerable<Type> GetHandlerTypes<TParameter, TResult>() where TParameter : IQuery where TResult : IQueryResult
        {
            var handlers = Assembly.Load("CQRS.Implementation").GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(TParameter)))).ToList();


            return handlers;
        }
    }
}
