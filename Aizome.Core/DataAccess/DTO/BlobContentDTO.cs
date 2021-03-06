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
}
