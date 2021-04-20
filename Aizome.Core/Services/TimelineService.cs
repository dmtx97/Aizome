using System;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;
using Aizome.Core.DataAccess.Repositories;
using AutoMapper;

namespace Aizome.Core.Services
{
    public class TimelineService : AizomeService<Timeline>, ITimelineService
    {
        private readonly ITimelineRepository _timelineRepository;
        public TimelineService(IMapper mapper, ITimelineRepository timelineRepository) : base(mapper)
        {
            _timelineRepository = timelineRepository;
        }

        public Timeline AddTimeline(TimelineCreateDTO timelineCreateDto)
        {
            var timeline = ConvertToEntity(timelineCreateDto);
            _timelineRepository.Add(timeline);

            return _timelineRepository.SaveChanges() ? timeline : null;
        }
    }
}