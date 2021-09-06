using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aizome.Core.Controllers
{
    [Route("api/timeline")]
    [ApiController]
    public class TimelineController : ControllerBase
    {
        private readonly ITimelineService _timelineService;
        public TimelineController(ITimelineService timelineService)
        {
            _timelineService = timelineService;
        }

        [HttpPost("{jeanId}", Name ="AddTimelineToJean")]
        public async Task<ActionResult<TimelineDTO>> AddTimelineToJean(TimelineCreateDTO timelineCreateDto, int jeanId)
        {
            var createdTimeline = await _timelineService.AddTimeline(timelineCreateDto);

            return createdTimeline == null
                ? BadRequest()
                : CreatedAtRoute(nameof(AddTimelineToJean), new {jeanId = createdTimeline.JeanForeignKey});
        }

    }
}