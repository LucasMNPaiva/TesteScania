using Application.Implementations.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations.Services.Interfaces
{
    public interface IClientAppService
    {
        Cliente GetById(int id);
        IEnumerable<Cliente> ListClient(int page, int pageSize);
        Cliente CreateClient(ClienteCreate cliente);
        void UpdateClient(int id, ClienteUpdate cliente);
        bool DeleteClient(int id);
    }
}
