using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Utils;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Utils
{
    public class StructureMapCommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>().ToList();

            var cmdHandler = handlers.Select(handler =>

#pragma warning disable CS0618 // Type or member is obsolete
                (ICommandHandler<T>)ObjectFactory.GetInstance(handler)).FirstOrDefault();
#pragma warning restore CS0618 // Type or member is obsolete

            return cmdHandler;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }

    }
}
