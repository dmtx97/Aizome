using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aizome.Core.DataAccess.Entities
{
    public class Timeline : DbEntity
    {
        [Required]
        public TimelineActions Action { get; set; }

        public DateTime TimelineDate { get; set; }

        public int JeanForeignKey { get; set; }

        [ForeignKey("JeanForeignKey")]
        public Jean Jean { get; set; }
    }

    public enum TimelineActions
    {
    }
}