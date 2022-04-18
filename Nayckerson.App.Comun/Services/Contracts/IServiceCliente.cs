using Nayckerson.App.Comum.Models;
using System.Collections.Generic;

namespace Nayckerson.App.Comum.Services.Contracts
{
    public interface IServiceCliente
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
        Cliente GetCliente(int id);
        IEnumerable<Cliente> GetClientes();
    }
}
