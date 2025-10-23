
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations.Dtos
{
    public record ClienteCreate([Required] string? Nome, [Required][EmailAddress] string? Email);
}
