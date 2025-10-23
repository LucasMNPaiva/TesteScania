using Application.Implementations.Dtos;
using Application.Implementations.Services;
using Application.Implementations.Services.Interfaces;
using ClienteApi.Helpers;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class ClientesController : ControllerBase
    {
        private readonly IClientAppService _clientAppSerice;

        public ClientesController(IClientAppService clientAppService)
        {
            _clientAppSerice = clientAppService;
        }

        // GET /api/clientes?page=1&pageSize=20
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> List([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            if (page <= 0 || pageSize <= 0 || pageSize > 200)
                return BadRequest("Use page>=1 e 1<=pageSize<=200");

            var items = _clientAppSerice.ListClient(page, pageSize);

            return Ok(items);
        }

        // GET /api/clientes/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Cliente> GetById([FromRoute] int id)
        {
            var cliente = _clientAppSerice.GetById(id);

            return cliente is not null ? Ok(cliente) : NotFound();
        }

        // POST /api/clientes
        [HttpPost]
        public ActionResult<Cliente> Create([FromBody] ClienteCreate dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            
            if (!EmailHelper.IsValidEmail(dto.Email))
                return BadRequest("Email inválido.");

            try
            {
                var cliente =  _clientAppSerice.CreateClient(dto);
                return CreatedAtAction(nameof(GetById), new { cliente.Id }, cliente);
            }
            catch (EmailHelper.DuplicateEmailException)
            {
                return Conflict("Email já existe.");
            }
        }

        // PUT /api/clientes/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ClienteUpdate dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            if (_clientAppSerice.GetById(id) is null)
                return NotFound();

            try
            {
                _clientAppSerice.UpdateClient(id,dto);               
                return NoContent();
            }
            catch
            {
                throw;
            }
        }

        // DELETE /api/clientes/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
          return _clientAppSerice.DeleteClient(id) ? NoContent() : BadRequest();

        }
    }
}
