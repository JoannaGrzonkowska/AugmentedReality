using Autofac;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Repository;
using DataAccess.RepositoryCommands;

namespace DependencyResolver
{
    public class BusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new kasiaskynoteEntities();

            var unitOfWork = new UnitOfWork(context);
            var examinationsRepository = new NoteRepository(context, unitOfWork);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);
            builder.RegisterInstance<INoteRepository>(examinationsRepository);

            builder.RegisterInstance<INoteService>(new NoteService(examinationsRepository));

            base.Load(builder);
        }
    }
}
