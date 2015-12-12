using Autofac;
using BusinessLogic.Services;
using DataAccessTest;
using DataAccessTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public class BusinessLogicModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var context = new skynote2Entities();

            var unitOfWork = new UnitOfWork(context);
            var examinationsRepository = new NotesRepository(context, unitOfWork);

            builder.RegisterInstance<IUnitOfWork>(unitOfWork);
            builder.RegisterInstance<INotesRepository>(examinationsRepository);

            builder.RegisterInstance<INotesService>(new NotesService(examinationsRepository));

            base.Load(builder);
        }
    }
}
