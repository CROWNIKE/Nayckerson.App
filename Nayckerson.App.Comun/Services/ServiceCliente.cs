using Microsoft.EntityFrameworkCore;
using Nayckerson.App.Comum.Data;
using Nayckerson.App.Comum.Models;
using Nayckerson.App.Comum.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Nayckerson.App.Comum.Services
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly Context _context;

        public ServiceCliente(Context context)
        {
            _context = context;
        }

        public void Create(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Cliente.Find(id);
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
        }

        public Cliente GetCliente(int id)
        {
            return _context.Cliente.Include(x => x.Contato)
                                   .Include(x => x.Endereco)
                                   .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Cliente.Include(x => x.Contato)
                                   .Include(x => x.Endereco)
                                   .ToList();
        }
    }
}
