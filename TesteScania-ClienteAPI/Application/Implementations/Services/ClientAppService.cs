
using Application.Implementations.Dtos;
using Application.Implementations.Services.Interfaces;
using Domain.Models;
using Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations.Services
{
    public class ClientAppService(IClientRepository clientRepository) : IClientAppService
    {
        public Cliente CreateClient(ClienteCreate clienteDTO)
        {
            var cliente = new Cliente
            {
                Nome = clienteDTO.Nome!.Trim(),
                Email = clienteDTO.Email!.Trim(),
                CriadoEm = DateTime.UtcNow
            };

            return clientRepository.CreateClient(cliente);
        }

        public bool DeleteClient(int id)
        {
            return clientRepository.DeleteClient(id);
        }

        public Cliente GetById(int id)
        {
            return clientRepository.GetById(id);
        }

        public IEnumerable<Cliente> ListClient(int page, int pageSize)
        {
            return clientRepository.ListClient(page, pageSize);
        }

        public void UpdateClient(int id, ClienteUpdate clienteDto)
        {
            var atual = clientRepository.GetById(id);
            if (atual == null)
                throw new KeyNotFoundException("Cliente não encontrado.");

            var novo = atual with
            {
                Nome = clienteDto.Nome!.Trim(),
                Email = clienteDto.Email!
            };

            clientRepository.UpdateClient(id, novo);
        }
    }
}
