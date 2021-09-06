using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;
using Aizome.Core.DataAccess.Repositories;
using AutoMapper;

namespace Aizome.Core.Services
{
    public abstract class AizomeService<T1, T2> where T1 : DbEntity where T2 : AizomeDTO
    {
        private readonly IMapper _mapper;
        private readonly IRepository<T1> _repository;
        protected AizomeService(IMapper mapper, IRepository<T1> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<bool> Remove(int id)
        {
            return await Execute(() => _repository.Remove(id));
        }


        public async Task<T2> Execute(Action<T1> modelAction, AizomeDTO dto)
        {
            try
            {
                if (dto != null)
                {
                    var newEntity = ConvertToEntity(dto);
                    await Task.Run(() => modelAction(newEntity));
                    return _repository.SaveChanges() ? _mapper.Map<T2>(newEntity) : null;
                }

                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Unexpected error saving changes", e);
            }

            return null;
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
        protected T1 ConvertToEntity(AizomeDTO dto) => dto == null ? null : _mapper.Map<T1>(dto);
        protected T2 ConvertToDto(T1 entity) => entity == null ? null : _mapper.Map<T2>(entity);
    }
}
