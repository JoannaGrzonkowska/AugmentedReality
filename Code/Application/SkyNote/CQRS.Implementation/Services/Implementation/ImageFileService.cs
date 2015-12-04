using CQRS.Implementation.Commands.Models;
using CQRS.Implementation.Static;
using System;
using System.Collections.Generic;
using System.IO;

namespace CQRS.Implementation.Services.Implementation
{
    public class ImageFileService : IImageFileService
    {
        public FileStream Get(string fileName, string destinationPath)
        {
            if (!Directory.Exists(destinationPath))
            {
                throw new DirectoryNotFoundException("Missing directory for keeping files");
            }

            var serverPath = Path.Combine(destinationPath, fileName);

            return File.OpenRead(serverPath);
        }

        public void SaveFile(byte[] bytes, string filePath)
        {
            CreateDirIfNotExsists(filePath);
            File.WriteAllBytes(filePath, bytes);
        }

        public void SaveFilesList(IList<SaveImageModel> images, string destinationDirPath)
        {
            for (int i = 0; i < images.Count; i++)
            {
                var image = images[i];
                var serverPath = Path.Combine(destinationDirPath, Guid.NewGuid() + StaticData.FilesExtension);
                SaveFile(image.ImageBytes, serverPath);
            };
        }

        public void DeleteUnusedFiles(IList<string> usedFilenames, string destinationDirPath)
        {
            if (Directory.Exists(destinationDirPath))
            {
                var files = Directory.GetFiles(destinationDirPath);
                foreach (var file in files)
                {
                    if (!usedFilenames.Contains(Path.GetFileName(file)))
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        private void CreateDirIfNotExsists(string filePath)
        {
            var dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
