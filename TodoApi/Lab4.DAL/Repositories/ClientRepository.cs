using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Data;
using Lab4.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly SportComplexContext _context;

        public ClientRepository(SportComplexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientViewModel>> GetAllAsync()
        {
            return await _context.Clients
                .Select(c => new ClientViewModel
                {
                    Id = c.client_id,
                    FullName = c.client_full_name,
                    PhoneNumber = c.client_phone_number,
                    Gender = c.client_gender.HasValue ? (c.client_gender.Value ? "Чоловік" : "Жінка") : "Невідомо"
                })
                .ToListAsync();
        }

        public async Task<ClientViewModel> GetByIdAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return null;

            return new ClientViewModel
            {
                Id = client.client_id,
                FullName = client.client_full_name,
                PhoneNumber = client.client_phone_number,
                Gender = client.client_gender.HasValue ? (client.client_gender.Value ? "Чоловік" : "Жінка") : "Невідомо"
            };
        }

        public async Task AddAsync(ClientViewModel client)
        {
            var newClient = new Client
            {
                client_full_name = client.FullName,
                client_phone_number = client.PhoneNumber,
                client_gender = client.Gender == "Чоловік"
            };

            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClientViewModel client)
        {
            var existingClient = await _context.Clients.FindAsync(client.Id);
            if (existingClient == null) return;

            existingClient.client_full_name = client.FullName;
            existingClient.client_phone_number = client.PhoneNumber;
            existingClient.client_gender = client.Gender == "Чоловік";

            _context.Entry(existingClient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
