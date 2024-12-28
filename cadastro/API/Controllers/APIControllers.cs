using Microsoft.AspNetCore.Mvc;
using API.Models;  // Certifique-se de importar o namespace correto onde está a classe Cadastro
using API.Data;    // Importando o namespace do seu contexto
using Microsoft.EntityFrameworkCore;

namespace APIControllers;  // Verifique se o namespace está correto

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly CadastroContext _context;

    public ClientesController(CadastroContext context)
    {
        _context = context;
    }

    // GET: api/Clientes
    [HttpGet]
    public IActionResult GetClientes()
    {
        var clientes = _context.Clientes.ToList();  // Mantendo a DbSet Clientes no contexto
        return Ok(clientes);
    }

    // GET: api/Clientes/5
    [HttpGet("{id}")]
    public IActionResult GetCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);  // Alterado para "Cadastro"
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    // POST: api/Clientes
    [HttpPost]
    public IActionResult PostCliente(Cadastro cliente)  // Usando Cadastro em vez de Cliente
    {
        _context.Clientes.Add(cliente);  // DbSet Clientes
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
    }

    // PUT: api/Clientes/5
    [HttpPut("{id}")]
    public IActionResult PutCliente(int id, Cadastro cliente)  // Usando Cadastro em vez de Cliente
    {
        if (id != cliente.Id)
        {
            return BadRequest();
        }

        _context.Entry(cliente).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Clientes/5
    [HttpDelete("{id}")]
    public IActionResult DeleteCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);  // Alterado para "Cadastro"
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);  // DbSet Clientes
        _context.SaveChanges();

        return NoContent();
    }
}