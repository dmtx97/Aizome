using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.Services
{
    public interface ITimelineService
    {
        public Timeline AddTimeline(TimelineCreateDTO timeline);
        public Timeline UpdateTimeline(TimelineDTO timeline);
        public Timeline GetPreviousTimeline(Timeline timeline);

    }
}