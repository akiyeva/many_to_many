using ManyToMany.Models;

namespace ManyToMany.Services.Interfaces;

public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomersAsync();
    Task CreateCustomerAsync(Customer customer);
}