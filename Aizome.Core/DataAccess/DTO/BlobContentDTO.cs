using System.IO;

namespace Aizome.Core.DataAccess.DTO
{
    public class BlobContentDTO : AizomeDTO
    { 
        public BlobContentDTO(Stream content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }

        public Stream Content { get; }
        public string ContentType { get; }
    }

    public class BlobDTO : AizomeDTO
    {
        public string FileId { get; set; }

        public string ContainerName { get; set; }

        public int JeanForeignKey { get; set; }
    }
}
