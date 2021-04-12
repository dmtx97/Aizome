using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aizome.Core.DataAccess.Entities
{
    public class Blob : DbEntity
    {
        [Key]
        public string FileId { get; set; }

        public string ContainerName { get; set; }

        public int JeanForeignKey { get; set; }

        [ForeignKey("JeanForeignKey")]
        public Jean Jean { get; set; }
    }
}