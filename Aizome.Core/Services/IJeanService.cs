using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.Services
{
    public interface IJeanService
    {
        public Task<Jean> AddJean(JeanCreateDTO jean);
        public Task<Jean> UpdateJean(JeanDTO jean);
    }
}