using System;
using System.Linq;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;
using Aizome.Core.DataAccess.Repositories;
using AutoMapper;

namespace Aizome.Core.Services
{
    public class TimelineService : AizomeService<Timeline>, ITimelineService
    {
        private readonly ITimelineRepository _timelineRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Timeline> _baseRepository;
        public TimelineService(IMapper mapper, ITimelineRepository timelineRepository, IRepository<Timeline> baseRepository) : base(mapper, baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _timelineRepository = timelineRepository;
        }

        public Timeline AddTimeline(TimelineCreateDTO timelineCreateDto)
        {
            var timeline = ConvertToEntity(timelineCreateDto);
            timeline.PreviousTimeline = GetPreviousTimeline(timeline);
            _timelineRepository.Add(timeline);
            return _timelineRepository.SaveChanges() ? timeline : null;
        }

        public Timeline UpdateTimeline(TimelineDTO timelineDto)
        {
            var timeline = _timelineRepository.GetById(timelineDto.TimelineId);

            if (timeline == null) return null;

            var updatedTimeline = _mapper.Map(timelineDto, timeline);

            return _timelineRepository.SaveChanges()
                ? updatedTimeline
                : throw new ArgumentException("Unexpected error saving entity");
        }

        public Timeline GetPreviousTimeline(Timeline timeline) => _timelineRepository.GetAll().OrderByDescending(x => x.TimelineDate).First();
    }
}