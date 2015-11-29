using CQRS.Events;
using CQRS.Implementation.Utils;
using CQRS.Messaging;
using CQRS.Utils;
using DataAccess.Repositories;
using DataAccess.Repositories.Implementation;
using DataAccessDenormalized.Repository;
using DataAccessDenormalized.Repository.Implementation;
using StructureMap;

namespace SkyNote
{
    public sealed class ServiceLocator
    {
        private static ICommandBus commandBus;
        private static IQueryBus queryBus;
        private static bool isInitialized;
        private static readonly object _lockThis = new object();

        static ServiceLocator()
        {
            if (!isInitialized)
            {
                lock (_lockThis)
                {
                    ContainerBootstrapper.BootstrapStructureMap();
#pragma warning disable CS0618 // Type or member is obsolete
                    commandBus = ObjectFactory.GetInstance<ICommandBus>();
                    queryBus = ObjectFactory.GetInstance<IQueryBus>();
#pragma warning restore CS0618 // Type or member is obsolete
                    isInitialized = true;
                }
            }
        }
        
        public static ICommandBus CommandBus
        {
            get { return commandBus; }
        }

        public static IQueryBus QueryBus
        {
            get { return queryBus; }
        }
    }


    static class ContainerBootstrapper
    {
        public static void BootstrapStructureMap()
        {

#pragma warning disable CS0618 // Type or member is obsolete
            ObjectFactory.Initialize(x =>
#pragma warning restore CS0618 // Type or member is obsolete
            {
                x.For(typeof(IRepositoryBase<>)).Singleton().Use(typeof(RepositoryBase<,>));
                x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<,>));
                x.For<IEventBus>().Use<EventBus>();
                x.For<ICommandHandlerFactory>().Use<StructureMapCommandHandlerFactory>();
                x.For<IEventHandlerFactory>().Use<StructureMapEventHandlerFactory>();
                x.For<IQueryHandlerFactory>().Use<StructureMapQueryHandlerFactory>();
                x.For<ICommandBus>().Use<CommandBus>();
                x.For<IQueryBus>().Use<QueryBus>();
                x.For<IEventStorage>().Use<EventStorage>();

                x.For<INoteRepository>().Use<NoteRepository>();
                x.For<IUserfriendsRepository>().Use<UserfriendsRepository>();
                x.For<IUsergroupRepository>().Use<UsergroupRepository>();
                x.For<IGroupRepository>().Use<GroupRepository>();
                x.For<IUserRepository>().Use<UserRepository>();
                x.For<INoteDenormalizedRepository>().Use<NoteDenormalizedRepository>();
                x.For<IGroupDenormalizedRepository>().Use<GroupDenormalizedRepository>();
                x.For<ILocationRepository>().Use<LocationRepository>();
                x.For<ICategoryRepository>().Use<CategoryRepository>();
                x.For<ITypeRepository>().Use<TypeRepository>();
                x.For<INotegroupRepository>().Use<NotegroupRepository>();
                x.For<IUserGroupInvitesRepository>().Use<UserGroupInvitesRepository>();
                x.For<IUserFriendInvitesRepository>().Use<UserFriendInvitesRepository>();
                x.For<IInvitesDenormalizedRepository>().Use<InvitesDenormalizedRepository>();
            });
        }
    }
}
