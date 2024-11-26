using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IServices
{
    public interface IClientService
    {
        Task<IEnumerable<ClientViewModel>> GetAllClientsAsync();
        Task<ClientViewModel> GetClientByIdAsync(int id);
        Task AddClientAsync(ClientViewModel clientViewModel);
        Task UpdateClientAsync(ClientViewModel clientViewModel);
        Task DeleteClientAsync(int id);
    }
}