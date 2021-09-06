using System;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.DTO
{
    public class TimelineDTO : AizomeDTO
    {
        public int JeanForeignKey { get; set; }
        public int TimelineId { get; set; }

        public TimelineActions Action { get; set; }

        public DateTime TimelineDate { get; set; }
    }
}