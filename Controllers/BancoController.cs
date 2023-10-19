using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using boletos_banco.Data;
using boletos_banco.Data.Models;
using System;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace boletos_banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BancoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo banco")]
        [SwaggerResponse(StatusCodes.Status201Created, "Banco criado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<IActionResult> CreateBanco([FromBody] Banco banco)
        {
            if (banco == null)
            {
                return BadRequest("Requisição inválida. Verifique os dados do banco.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {                
                _context.Bancos.Add(banco);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBanco), new { id = banco.Id }, banco);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao criar o banco: " + ex.Message);
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter todos os bancos")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de bancos retornada com sucesso")]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBancos()
        {
            return await _context.Bancos.ToListAsync();
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obter detalhes do banco pelo ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Detalhes do banco retornado com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Banco não encontrado")]
        public async Task<ActionResult<Banco>> GetBanco(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);
            if (banco == null)
            {
                return NotFound();
            }
            
            return banco;
        }
    }
}
