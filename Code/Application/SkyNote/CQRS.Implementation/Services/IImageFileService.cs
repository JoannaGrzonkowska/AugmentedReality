using CQRS.Implementation.Commands.Models;
using System.Collections.Generic;
using System.IO;

namespace CQRS.Implementation.Services
{
    public interface IImageFileService
    {
        FileStream Get(string fileName, string destinationPath);
        void SaveFile(byte[] bytes, string filePath);
        void SaveFilesList(IList<SaveImageModel> images, string destinationDirPath);
        void DeleteUnusedFiles(IList<string> usedFilenames, string destinationDirPath);
    }
}
