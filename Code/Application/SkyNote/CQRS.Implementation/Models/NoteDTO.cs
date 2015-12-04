using CQRS.Implementation.Static;
using DataAccessDenormalized;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CQRS.Implementation.Models
{
    public class NoteDTO : BaseDTO<note>
    {
        public int Id { get; set; }
        public int? NoteId { get; set; }
        public int? UserId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public decimal? XCord { get; set; }
        public decimal? YCord { get; set; }
        public decimal? ZCord { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public int? GroupId { get; set; }
        public string GroupName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public IEnumerable<string> ImagesFilenames { get; set; }
        public string LocationAddress { get; set; }

        public static NoteDTO Build(note entity)
        {
            return new NoteDTO
            {
                Id = entity.NoteId.Value,
                NoteId = entity.NoteId,
                UserId = entity.UserId,
                Topic = entity.Topic,
                Content = entity.Content,
                Date = entity.Date,
                LocationId = (int)entity.LocationId,
                XCord = entity.XCord,
                YCord = entity.YCord,
                ZCord = entity.ZCord,
                Name = entity.Name,
                Login = entity.Login,
                Mail = entity.Mail,
                GroupId = entity.GroupId,
                GroupName = entity.GroupName,
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                TypeId = entity.TypeId,
                TypeName = entity.TypeName,
                ImagesFilenames = Enumerable.Empty<string>(),
                LocationAddress = entity.LocationAddress
            };
        }

        public void GetImagesFilenames(string filesDirPath)
        {
            var noteImagesDirectory = Path.Combine(filesDirPath, StaticData.NotesDirectory, NoteId.ToString());
            IEnumerable<string> imagesFilenames = Enumerable.Empty<string>();
            if (Directory.Exists(noteImagesDirectory))
            {
                imagesFilenames = Directory.GetFiles(noteImagesDirectory).Select(x => Path.GetFileName(x));
            }
            ImagesFilenames = imagesFilenames;
        }

        public override BaseDTO<note> BuildDTO(note entity)
        {
            return Build(entity);
        }
    }
}
