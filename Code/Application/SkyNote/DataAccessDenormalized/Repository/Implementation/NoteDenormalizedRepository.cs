using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessDenormalized.Repository
{
    public class NoteDenormalizedRepository : Repository<note, skynotedenormalizeddbEntities>, INoteDenormalizedRepository
    {

        public NoteDenormalizedRepository(skynotedenormalizeddbEntities context)
            : base(context)
        {
        }

        public void InsertNote(int userIdParam, string topicParam, string contentParam, int locationIdParam, decimal? xCordParam, decimal? yCordParam,
            decimal? zCordParam, string nameParam, string loginParam, string mailParam, int groupIdParam, string groupNameParam,
            string identyficationParam, DateTime? dateParam, int noteIdParam, int? categoryIdParam,
            string categoryNameParam, int? typeIdParam, string typeNameParam, string locationAddress)
        {
            base.Context.insert_note(userIdParam, topicParam, contentParam, locationIdParam, xCordParam, yCordParam,
             zCordParam, nameParam, loginParam, mailParam, groupIdParam, groupNameParam,
             identyficationParam, dateParam, noteIdParam, categoryIdParam,
             categoryNameParam, typeIdParam, typeNameParam, locationAddress);
        }

        public IEnumerable<note> NotesInLocationRange(int userId, decimal? xCordParam, decimal? yCordParam, int radiusParam, int? categoryIdParam, int? typeIdParam, string groupIds)
        {
            var notes = base.Context.get_notes_in_location_range(xCordParam, yCordParam, radiusParam, categoryIdParam, typeIdParam, groupIds, userId);      
            return notes;
        }

		public IQueryable<note> GetNoteById(int NoteId)
        {
            return Context.Set<note>()
                .Where(x => x.NoteId == NoteId);
        }
    }
}
