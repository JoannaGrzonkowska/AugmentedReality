using System;
using System.Collections.Generic;
namespace DataAccessDenormalized.Repository
{
    public interface INoteDenormalizedRepository : IRepository<note>
    {
       void  InsertNote(int userIdParam, string topicParam, string contentParam, int locationIdParam, decimal? xCordParam, decimal? yCordParam,
            decimal? zCordParam, string nameParam, string loginParam, string mailParam, int groupIdParam, string groupNameParam,
            string identyficationParam, DateTime? dateParam, int noteIdParam, int? categoryIdParam,
            string categoryNameParam, int? typeIdParam, string typeNameParam, string locationAddress);

        IEnumerable<note> NotesInLocationRange(decimal? xCordParam, decimal? yCordParam, int radiusParam, int? categoryIdParam, int? typeIdParam);
    }
}
