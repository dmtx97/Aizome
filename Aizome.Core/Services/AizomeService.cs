using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;
using AutoMapper;

namespace Aizome.Core.Services
{
    public class AizomeService<T> where T : DbEntity
    {
        private readonly IMapper _mapper;

        public AizomeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected T ConvertToEntity(AizomeDTO dto) => dto == null ? null : _mapper.Map<T>(dto);
    }
}
