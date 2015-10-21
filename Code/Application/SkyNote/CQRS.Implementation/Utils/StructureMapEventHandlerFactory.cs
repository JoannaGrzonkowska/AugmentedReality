using CQRS.EventHandlers;
using CQRS.Events;
using CQRS.Utils;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CQRS.Implementation.Utils
{
    public class StructureMapEventHandlerFactory : IEventHandlerFactory
    {
        public IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event
        {
            var handlers = GetHandlerType<T>();

#pragma warning disable CS0618 // Type or member is obsolete
            var lstHandlers = handlers.Select(handler => (IEventHandler<T>)ObjectFactory.GetInstance(handler)).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            return lstHandlers;
        }

        private static IEnumerable<Type> GetHandlerType<T>() where T : Event
        {

            var handlers = Assembly.Load("CQRS.Implementation").GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>))).Where(h => h.GetInterfaces().Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }
}
