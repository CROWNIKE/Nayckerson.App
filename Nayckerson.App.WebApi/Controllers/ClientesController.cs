using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nayckerson.App.Comum.Models;
using Nayckerson.App.Comum.Services.Contracts;

namespace Nayckerson.App.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private readonly IServiceCliente service;

        public ClientesController(IServiceCliente service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return service.GetClientes();
        }

        [HttpGet, Route("{id}")]
        public Cliente Get(int id)
        {
            return service.GetCliente(id);
        }

        [HttpPost, Route("Create")]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                service.Create(cliente);
                return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut, Route("Update/{id}")]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                service.Update(cliente);
                return Ok();
            }
            else
            {
                return ValidationProblem(ModelState);
            }
        }

        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            
            return Ok();
        }
    }
}
