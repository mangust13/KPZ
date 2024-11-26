using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IRepository
{
    public interface IClientRepository
    {
        Task<IEnumerable<ClientViewModel>> GetAllAsync();
        Task<ClientViewModel> GetByIdAsync(int id);
        Task AddAsync(ClientViewModel client);
        Task UpdateAsync(ClientViewModel client);
        Task DeleteAsync(int id);
    }
}
