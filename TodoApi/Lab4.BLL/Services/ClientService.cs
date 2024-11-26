using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.IServices;
using Lab4.Abstraction.ViewModels;

namespace Lab4.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClientViewModel>> GetAllClientsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ClientViewModel> GetClientByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddClientAsync(ClientViewModel clientViewModel)
        {
            await _repository.AddAsync(clientViewModel);
        }

        public async Task UpdateClientAsync(ClientViewModel clientViewModel)
        {
            await _repository.UpdateAsync(clientViewModel);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
