using CQRS.Commands;

namespace CQRS.Implementation.Commands.Models
{
    public class SaveImageModel
    {
        public byte[] ImageBytes { get; set; }
        public string ImageBase64 { get; set; }
        public string Filename { get; set; }
    }
}
