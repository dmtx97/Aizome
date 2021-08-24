﻿using System.Linq;
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

        public TimelineService(ITimelineRepository timelineRepository, IMapper mapper, IRepository<Timeline> baseRepository) : base(mapper, baseRepository)
        {
            _timelineRepository = timelineRepository;
        }

        public async Task<Timeline> AddTimeline(TimelineCreateDTO timelineCreateDto) => await Execute(_timelineRepository.Add, timelineCreateDto); 
        
        public async Task<Timeline> UpdateTimeline(TimelineDTO timelineDto)
        {
            var timeline = _timelineRepository.GetById(timelineDto.TimelineId);

            return timeline != null ? await Execute(_timelineRepository.Update, timelineDto) : null;
        }
        public Timeline GetPreviousTimeline(Timeline timeline) => _timelineRepository.GetAll().OrderBy(x => x.TimelineDate).First();
        
        public async Task<bool> DeleteTimeline(int timelineId) => await Execute(() => _timelineRepository.Remove(timelineId));
    }
}