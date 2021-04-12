using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aizome.Core.DataAccess.Entities
{
    public class Jean : DbEntity
    {
        public Jean()
        {
            Timelines = new List<Timeline>();
            Blobs = new List<Blob>();
        }

        [Key]
        public int JeanId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public ICollection<Blob> Blobs { get; set; }

        public ICollection<Timeline> Timelines { get; set; }
        public int UserForeignKey { get; set; }

        [ForeignKey("UserForeignKey")]
        public User User { get; set; }
    }
}
