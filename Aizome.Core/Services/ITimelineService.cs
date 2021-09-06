using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.Services
{
    public interface ITimelineService
    {
        public Task<TimelineDTO> AddTimeline(TimelineCreateDTO timeline);
        public Task<TimelineDTO> UpdateTimeline(TimelineDTO timeline);
        public TimelineDTO GetPreviousTimeline(Timeline timeline);
        public Task<bool> DeleteTimeline(int timelineId);

    }
}