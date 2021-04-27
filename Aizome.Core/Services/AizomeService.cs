using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;
using Aizome.Core.DataAccess.Repositories;
using AutoMapper;

namespace Aizome.Core.Services
{
    public abstract class AizomeService<T> where T : DbEntity
    {
        private readonly IMapper _mapper;
        private readonly IRepository<T> _repository;
        protected AizomeService(IMapper mapper, IRepository<T> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<bool> Remove(int id)
        {
            return await Execute(() => _repository.Remove(id));
        }

        public async Task<bool> Execute(Action modelFunc)
        {
            try
            {
                await Task.Run(() => (modelFunc));
                return _repository.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Unexpected error saving changes", e);
            }
            return false;
        }
        protected T ConvertToEntity(AizomeDTO dto) => dto == null ? null : _mapper.Map<T>(dto);
        protected AizomeDTO ConvertFromEntity(DbEntity entity) =>  entity == null ? null : _mapper.Map<AizomeDTO>(entity);
    }
}
