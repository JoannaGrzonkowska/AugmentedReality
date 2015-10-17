namespace DataAccess.Repositories.Implementation
{

    public class NoteRepository : RepositoryBase<note, skynotedbEntities1>, INoteRepository
    {

        public NoteRepository(skynotedbEntities1 context)
            :base(context)
        {

        }
    }
}
