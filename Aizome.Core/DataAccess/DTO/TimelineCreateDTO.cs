using System;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.DTO
{
    public class TimelineCreateDTO : AizomeDTO
    {
        public TimelineActions Action { get; set; }

        public DateTime TimelineDate { get; set; }

        public int JeanForeignKey { get; set; }
    }
}