using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Utils;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CQRS.Implementation.Utils
{
    public class StructureMapCommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandler<T>() where T : ICommand
        {
            var handlers = GetHandlerTypes<T>().ToList();

            var cmdHandler = handlers.Select(handler =>
#pragma warning disable CS0618 // Type or member is obsolete
            //HERE IT FAILS!
                (ICommandHandler<T>)ObjectFactory.GetInstance(handler)).FirstOrDefault();
#pragma warning restore CS0618 // Type or member is obsolete

            return cmdHandler;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : ICommand
        {
            var handlers = Assembly.Load("CQRS.Implementation").GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }

    }
}
