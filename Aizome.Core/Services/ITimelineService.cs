using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.Services
{
    public interface ITimelineService
    {
        public Task<Timeline> AddTimeline(TimelineCreateDTO timeline);
        public Task<Timeline> UpdateTimeline(TimelineDTO timeline);
        public Timeline GetPreviousTimeline(Timeline timeline);
        public Task<bool> DeleteTimeline(int timelineId);

    }
}