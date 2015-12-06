using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveNotesAvaliableForUserQueryHandler : IQueryHandler<RetrieveNotesAvaliableForUserQuery, RetrieveNotesAvaliableForUserQueryResult>
    {
        private readonly INoteDenormalizedRepository noteRepository;
        private readonly IGroupDenormalizedRepository groupRepository;

        public RetrieveNotesAvaliableForUserQueryHandler(INoteDenormalizedRepository noteRepository, 
                                                        IGroupDenormalizedRepository groupRepository)
        {
            this.noteRepository = noteRepository;
            this.groupRepository = groupRepository;
        }

        public RetrieveNotesAvaliableForUserQueryResult Handle(RetrieveNotesAvaliableForUserQuery handle)
        {
            var result = new RetrieveNotesAvaliableForUserQueryResult();
            var groups = groupRepository.GetAllQueryable().Where(x => x.UserId == handle.UserId
                                                                 && (x.Role == "Member" || x.Role == "Creator")
                                                                 ).ToList();
            var friends = groupRepository.GetAllQueryable().Where(x => x.UserId == handle.UserId 
                                                                    && x.FriendId != null).ToList();

            List<int> GroupsIds = new List<int>();
            if (groups != null)
                foreach (var group in groups)
                    if (group.GroupId != null)
                        GroupsIds.Add((int)group.GroupId);

            List<int> FriendsIds = new List<int>();
            if(friends!=null)
                foreach (var friend in friends)
                    if (friend.FriendId != null)
                        FriendsIds.Add((int)friend.FriendId);

            /*var notes_ofUserAndFriends = noteRepository.GetAllQueryable().Where(
                    (x =>
                        (
                            x.Identyfication == "NOTE"
                            &&
                            (
                                x.UserId == handle.UserId
                                || 
                                FriendsIds.Contains((int)x.UserId)
                            )
                        )
                        ||
                        (
                            x.Identyfication == "NOTE_SHARED_IN_GROUP"
                            &&
                            (GroupsIds.Contains((int)x.GroupId))
                        )
                    )
                ).ToList();*/
            var notes_ofUserAndFriends = noteRepository.GetAllQueryable().Where(
                                                                            x => x.Identyfication == "NOTE"
                                                                            &&
                                                                            (
                                                                                x.UserId == handle.UserId
                                                                                ||
                                                                                FriendsIds.Contains((int)x.UserId)
                                                                            )                                                                                
                                                                        ).ToList();

            List<int> NotesIds_ofUserAndFriends = new List<int>();
            if (notes_ofUserAndFriends != null)
                foreach (var note in notes_ofUserAndFriends)
                    if (note.NoteId != null)
                        if(!NotesIds_ofUserAndFriends.Contains((int)note.NoteId))
                            NotesIds_ofUserAndFriends.Add((int)note.NoteId);


            var notes_ofUserGroups = noteRepository.GetAllQueryable().Where(
                                                                    x => x.Identyfication == "NOTE_SHARED_IN_GROUP"
                                                                    &&
                                                                    (GroupsIds.Contains((int)x.GroupId))
                                                                    ).ToList();

            if (notes_ofUserGroups != null)
                foreach (var note in notes_ofUserGroups)
                    if(note.NoteId != null)
                        if(!NotesIds_ofUserAndFriends.Contains((int)note.NoteId))
                            notes_ofUserAndFriends.Add(note);

            result.Notes = Mapper.Map<IEnumerable<NoteDTO>>(notes_ofUserAndFriends);

            return result;
        }
    }
}
