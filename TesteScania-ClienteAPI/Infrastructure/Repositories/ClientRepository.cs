using Domain.Models;
using Domain.Services.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private static readonly ConcurrentDictionary<int, Cliente> _store = new();
        private static readonly ConcurrentDictionary<string, int> _emailToId = new(StringComparer.OrdinalIgnoreCase);
        private static int _id = 0;
        private static int NextId() => System.Threading.Interlocked.Increment(ref _id);

        public Cliente CreateClient(Cliente cliente)
        {
            var id = NextId();
            var novo = cliente with { Id = id };
            _store[id] = novo;
            return novo;
        }

        public bool DeleteClient(int id)
        {
            if (_store.TryRemove(id, out var removed))
            {
                if (_emailToId.TryRemove(removed.Email, out _))
                    return true;
            }
            return false;
        }

        public Cliente GetById(int id)
        {
            return _store.TryGetValue(id, out var c) ? c : null;
        }

        public IEnumerable<Cliente> ListClient(int page, int pageSize)
        {
            return _store.Values
             .OrderBy(c => c.Id)
             .Skip((page - 1) * pageSize)
             .Take(pageSize)
             .ToArray();
        }

        public void UpdateClient(int id, Cliente cliente)
        {
            _store[id] = cliente;
            _emailToId[cliente.Email] = id;
        }
    }
}
