using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interface
{
    public interface IClientRepository
    {
        Cliente GetById(int id);
        IEnumerable<Cliente> ListClient(int page, int pageSize);
        Cliente CreateClient(Cliente cliente);
        void UpdateClient(int id, Cliente cliente);
        bool DeleteClient(int id);
    }
}
