using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public record Cliente
    {
        public int Id { get; init; }
        public string Nome { get; init; } = default!;
        public string Email { get; init; } = default!;
        public DateTime CriadoEm { get; init; } // UTC
    }
}
